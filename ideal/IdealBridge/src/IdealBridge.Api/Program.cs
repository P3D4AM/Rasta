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
builder.Services.AddSingleton(options);

// ─── لایهٔ زیرساخت (اتصال فقط-خواندنی به Ideal) ───
builder.Services.AddSingleton<IDbConnectionFactory>(sp =>
{
    // خطای تنظیمات هنگام راه‌اندازی واضح است تا در هر درخواست پنهان بماند
    return new SqlConnectionFactory(sp.GetRequiredService<Microsoft.Extensions.Options.IOptions<IdealBridgeOptions>>().Value);
});
builder.Services.AddSingleton<IdealDb>();

// سیاست مرکزی و یکپارچهٔ دسترسی به داده (فاز ۱۱: SP غیرفعال، پیش‌فرض Table، Blocked = خطای شفاف)
// مقدار نامعتبر یا Sp در همین‌جا با پیام واضح ساخت هاست را متوقف می‌کند.
builder.Services.AddSingleton<IdealBridge.Infrastructure.Repositories.IDataAccessPolicy>(
    new IdealBridge.Infrastructure.Repositories.DataAccessPolicy(options));

builder.Services.AddSingleton<ISchemaProbe, SchemaProbe>();

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
builder.Services.AddControllers().AddJsonOptions(o =>
{
    // Status به‌صورت رشته («Success»/«Fail»/«Error») — هم‌خوان با API قدیمی Ideal
    o.JsonSerializerOptions.Converters.Add(new System.Text.Json.Serialization.JsonStringEnumConverter());
});
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

// ─── گارد فقط-خواندنی در Production غیرقابل خاموش‌کردن است (سیاست مستند فاز ۱۱) ───
if (builder.Environment.IsProduction() && !options.EnforceReadOnlyGuard)
{
    options.EnforceReadOnlyGuard = true;
    app.Logger.LogWarning("IdealBridge:EnforceReadOnlyGuard=false در Production نادیده گرفته شد — گارد فقط-خواندنی همیشه فعال است.");
}
options.EnforceReadOnlyGuard = IdealBridge.Infrastructure.Database.ReadOnlyGuardPolicy.Effective(options.EnforceReadOnlyGuard, builder.Environment.IsProduction());

// ─── اعتبارسنجی پیکربندی — شکست زودهنگام و شفاف (شکست = توقف با پیام دقیق) ───
// از کانفیگ نهایی خوانده می‌شود (شامل Environment Variable و منابع تزریقی تست).
IdealBridge.Infrastructure.Repositories.DataAccessPolicy.NormalizeConfiguredMode(
    app.Configuration.GetSection(IdealBridgeOptions.SectionName)[nameof(IdealBridgeOptions.DataAccessMode)]);

// کاوش اسکیما در راه‌اندازی + اعمال سیاست دسترسی (خرابی = گزارش، نه توقف)
try
{
    var probe = app.Services.GetRequiredService<ISchemaProbe>();
    var report = await probe.ProbeAsync();
    var policy = app.Services.GetRequiredService<IdealBridge.Infrastructure.Repositories.IDataAccessPolicy>();
    policy.ApplySchemaReport(report);
    report.EntityModes = new Dictionary<string, IdealBridge.Domain.Common.EntityAccessInfo>(policy.CurrentModes());
    var logger = app.Services.GetRequiredService<ILogger<Program>>();
    logger.LogInformation("Schema probe: ConnectionOk={Ok} DB={Db} Modes={Modes} SpExecution={Sp}",
        report.ConnectionOk, report.DatabaseName,
        string.Join(",", report.EntityModes.Select(kv => kv.Key + "=" + kv.Value)),
        policy.StoredProceduresSupported);
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
