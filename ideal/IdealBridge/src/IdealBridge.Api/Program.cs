using System.Threading.RateLimiting;
using IdealBridge.Application.Interfaces;
using IdealBridge.Infrastructure.Database;
using IdealBridge.Infrastructure.Repositories;
using IdealBridge.Security;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.RateLimiting;

var builder = WebApplication.CreateBuilder(args);

// ─── گزینه‌ها ───
builder.Services.Configure<IdealBridgeOptions>(builder.Configuration.GetSection(IdealBridgeOptions.SectionName));
var options = builder.Configuration.GetSection(IdealBridgeOptions.SectionName).Get<IdealBridgeOptions>() ?? new IdealBridgeOptions();

// ─── لایهٔ زیرساخت (اتصال فقط-خواندنی به Ideal) ───
builder.Services.AddSingleton<IDbConnectionFactory>(sp =>
{
    // خطای تنظیمات هنگام راه‌اندازی واضح است تا در هر درخواست پنهان بماند
    return new SqlConnectionFactory(sp.GetRequiredService<Microsoft.Extensions.Options.IOptions<IdealBridgeOptions>>().Value);
});
builder.Services.AddSingleton<IdealDb>();
builder.Services.AddSingleton<SchemaModeProvider>();
builder.Services.AddSingleton<ISchemaProbe, SchemaProbe>();
builder.Services.AddSingleton<DataAccessModeSelector>();

builder.Services.AddScoped<ICompanyRepository, CompanyRepository>();
builder.Services.AddScoped<IPersonRepository, PersonRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IConversationRepository, ConversationRepository>();
builder.Services.AddScoped<IProjectRepository, ProjectRepository>();
builder.Services.AddScoped<IReminderRepository, ReminderRepository>();
builder.Services.AddScoped<IWarehouseRepository, WarehouseRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<IBaseInfoRepository, BaseInfoRepository>();

// ─── امنیت مستقل ───
builder.Services.AddSingleton<TokenService>(sp =>
{
    var path = options.TokenStorePath;
    if (!Path.IsPathRooted(path))
        path = Path.Combine(builder.Environment.ContentRootPath, path);
    return new TokenService(path);
});
builder.Services.AddAuthentication(IdealBridgeAuthHandler.SchemeName)
    .AddScheme<IdealBridgeAuthOptions, IdealBridgeAuthHandler>(IdealBridgeAuthHandler.SchemeName, _ => { });
builder.Services.AddAuthorization();

// ─── Rate Limiting (پنجرهٔ ثابت + صف) ───
builder.Services.AddRateLimiter(rl =>
{
    rl.RejectionStatusCode = StatusCodes.Status429TooManyRequests;
    rl.AddPolicy("api", ctx => RateLimitPartition.GetFixedWindowLimiter(
        ctx.User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value ?? ctx.Connection.RemoteIpAddress?.ToString() ?? "anon",
        _ => new FixedWindowRateLimiterOptions
        {
            PermitLimit = 120,
            Window = TimeSpan.FromMinutes(1),
            QueueLimit = 30,
            QueueProcessingOrder = QueueProcessingOrder.OldestFirst,
        }));
    rl.AddPolicy("admin", ctx => RateLimitPartition.GetFixedWindowLimiter(
        "admin:" + (ctx.Connection.RemoteIpAddress?.ToString() ?? "?"),
        _ => new FixedWindowRateLimiterOptions { PermitLimit = 20, Window = TimeSpan.FromMinutes(1) }));
});

// ─── کنترلرها + Swagger ───
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Title = "IdealBridge API",
        Version = "v1",
        Description = "سرویس پل فقط-خواندنی بین دیتابیس Ideal CRM و MedPad — احراز هویت با هدر X-API-Key",
    });
    c.AddSecurityDefinition("X-API-Key", new Microsoft.OpenApi.Models.OpenApiSecurityScheme
    {
        Type = Microsoft.OpenApi.Models.SecuritySchemeType.ApiKey,
        In = Microsoft.OpenApi.Models.ParameterLocation.Header,
        Name = "X-API-Key",
        Description = "توکن IdealBridge (الگوی ibk_...)",
    });
    c.AddSecurityRequirement(new Microsoft.OpenApi.Models.OpenApiSecurityRequirement
    {
        { new Microsoft.OpenApi.Models.OpenApiSecurityScheme { Reference = new Microsoft.OpenApi.Models.OpenApiReference { Type = Microsoft.OpenApi.Models.ReferenceType.SecurityScheme, Id = "X-API-Key" } }, Array.Empty<string>() }
    });
});

var app = builder.Build();

// کاوش اسکیما در راه‌اندازی + تنظیم حالت‌ها (خرابی = گزارش، نه توقف)
try
{
    var probe = app.Services.GetRequiredService<ISchemaProbe>();
    var report = await probe.ProbeAsync();
    app.Services.GetRequiredService<SchemaModeProvider>().SetAll(report.EntityModes);
    var logger = app.Services.GetRequiredService<ILogger<Program>>();
    logger.LogInformation("Schema probe: ConnectionOk={Ok} DB={Db} Modes={Modes}",
        report.ConnectionOk, report.DatabaseName, string.Join(",", report.EntityModes.Select(kv => kv.Key + "=" + kv.Value)));
    if (!report.ConnectionOk)
        logger.LogWarning("اتصال به دیتابیس Ideal برقرار نشد ({Err}) — سرویس بالا می‌آید ولی endpointهای داده خطای 503 می‌دهند تا اتصال اصلاح شود.", report.ConnectionError);
    if (report.TablesMissing.Count > 0)
        logger.LogWarning("جدول‌های مفقود: {Tables} | ستون‌های مفقود: {Cols}",
            string.Join(", ", report.TablesMissing),
            string.Join("; ", report.ColumnsMissing.Select(kv => kv.Key + ": " + string.Join(",", kv.Value))));
}
catch (Exception ex)
{
    app.Services.GetRequiredService<ILogger<Program>>().LogError(ex, "Schema probe threw during startup (service continues)");
}

// ─── میان‌افزارها ───
app.UseMiddleware<IdealBridge.Api.Middleware.ErrorHandlingMiddleware>();
app.UseMiddleware<IdealBridge.Api.Middleware.RequestLoggingMiddleware>();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "IdealBridge v1"));
}
else
{
    // Swagger در Production هم در دسترس است (سرویس داخلی شبکه)؛ در صورت نیاز با IdealBridge:EnableSwagger=false خاموش کنید.
    if (app.Configuration.GetValue("IdealBridge:EnableSwagger", true))
    {
        app.UseSwagger();
        app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "IdealBridge v1"));
    }
}

app.UseRateLimiter();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers().RequireRateLimiting("api");

app.Run();

/// <summary>برای WebApplicationFactory تست‌های یکپارچه.</summary>
public partial class Program { }
