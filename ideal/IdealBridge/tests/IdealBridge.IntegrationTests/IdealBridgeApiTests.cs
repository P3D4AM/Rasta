using System.Data;
using System.Net;
using System.Net.Http.Json;
using System.Text.Json;
using IdealBridge.Infrastructure.Database;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Xunit;

namespace IdealBridge.IntegrationTests;

/// <summary>
/// تست‌های یکپارچهٔ IdealBridge با دوقلوی آزمونشی ADO.NET (بدون SQL Server واقعی).
/// محدودیت صریح: اتصال واقعی به SQL Server در محیط توسعه در دسترس نبود؛
/// این تست‌ها رفتار HTTP، احراز هویت، صفحه‌بندی و مدیریت خطا را با دادهٔ ساختگیِ «خواندنی» بررسی می‌کنند.
/// اثبات فقط-خواندنی: الف) گارد دستور در سطح کد (تست واحد) ب) فهرست سفید SP ج) هیچ مسیر اجرایی
/// برای دستور نوشتنی وجود ندارد (بررسی ساختاری) — لایهٔ مجوز SQL Server هنگام استقرار واقعی اعمال می‌شود.
/// </summary>
public class IdealBridgeApiTests : IClassFixture<IdealBridgeApiFactory>
{
    private readonly IdealBridgeApiFactory _factory;
    private readonly HttpClient _client;
    private readonly string _token;

    public IdealBridgeApiTests(IdealBridgeApiFactory factory)
    {
        _factory = factory;
        _client = factory.CreateClient();
        // توکن از طریق ساخت مستقیم سرویس (فایل موقت تست)
        _token = factory.TestToken;
    }

    private void Auth() => _client.DefaultRequestHeaders.Add("X-API-Key", _token);

    // ─── احراز هویت ───

    [Fact]
    public async Task WithoutToken_Returns401()
    {
        var resp = await _client.GetAsync("/api/v1/companies");
        Assert.Equal(HttpStatusCode.Unauthorized, resp.StatusCode);
    }

    [Fact]
    public async Task InvalidToken_Returns401()
    {
        _client.DefaultRequestHeaders.Add("X-API-Key", "ibk_invalid-token-value");
        var resp = await _client.GetAsync("/api/v1/companies");
        Assert.Equal(HttpStatusCode.Unauthorized, resp.StatusCode);
    }

    [Fact]
    public async Task ValidToken_Returns200_WithUniformEnvelope()
    {
        Auth();
        var resp = await _client.GetAsync("/api/v1/companies?page=1&pageSize=10");
        Assert.Equal(HttpStatusCode.OK, resp.StatusCode);
        var json = JsonDocument.Parse(await resp.Content.ReadAsStringAsync()).RootElement;
        Assert.True(json.TryGetProperty("data", out _));
        Assert.True(json.TryGetProperty("status", out var st));
        Assert.Equal("Success", st.GetString());
        Assert.True(json.TryGetProperty("message", out _));
        Assert.True(json.TryGetProperty("pagination", out _));
    }

    [Fact]
    public async Task ExpiredToken_Returns401()
    {
        var expired = _factory.CreateExpiredToken();
        _client.DefaultRequestHeaders.Add("X-API-Key", expired);
        var resp = await _client.GetAsync("/api/v1/companies");
        Assert.Equal(HttpStatusCode.Unauthorized, resp.StatusCode);
    }

    [Fact]
    public async Task RevokedToken_Returns401()
    {
        var revoked = _factory.CreateAndRevokeToken();
        _client.DefaultRequestHeaders.Add("X-API-Key", revoked);
        var resp = await _client.GetAsync("/api/v1/companies");
        Assert.Equal(HttpStatusCode.Unauthorized, resp.StatusCode);
    }

    // ─── داده: مشتریان ───

    [Fact]
    public async Task Companies_List_Returns_Data()
    {
        Auth();
        var resp = await _client.GetAsync("/api/v1/companies?page=1&pageSize=2");
        Assert.True(resp.IsSuccessStatusCode);
        var json = JsonDocument.Parse(await resp.Content.ReadAsStringAsync()).RootElement;
        var data = json.GetProperty("data");
        Assert.Equal(JsonValueKind.Array, data.ValueKind);
        Assert.Equal(2, data.GetArrayLength());
        var first = data[0];
        Assert.Equal(1, first.GetProperty("id").GetInt32());
        Assert.Equal("شرکت آلفا", first.GetProperty("name").GetString());
        Assert.Equal(35.123m, decimal.Parse(first.GetProperty("latitude").GetString()!, System.Globalization.CultureInfo.InvariantCulture));
    }

    [Fact]
    public async Task Companies_GetById_Works()
    {
        Auth();
        var resp = await _client.GetAsync("/api/v1/companies/1");
        Assert.True(resp.IsSuccessStatusCode);
        var json = JsonDocument.Parse(await resp.Content.ReadAsStringAsync()).RootElement;
        Assert.Equal("شرکت آلفا", json.GetProperty("data").GetProperty("name").GetString());
    }

    [Fact]
    public async Task Companies_GetById_Missing_Returns404_WithEnvelope()
    {
        Auth();
        var resp = await _client.GetAsync("/api/v1/companies/999");
        Assert.Equal(HttpStatusCode.NotFound, resp.StatusCode);
        var json = JsonDocument.Parse(await resp.Content.ReadAsStringAsync()).RootElement;
        Assert.Equal("Fail", json.GetProperty("status").GetString());
    }

    [Fact]
    public async Task Companies_Keyset_Pagination_Works()
    {
        Auth();
        var page1 = await _client.GetFromJsonAsync<JsonElement>("/api/v1/companies?afterId=0&pageSize=2");
        Assert.True(page1.GetProperty("pagination").GetProperty("hasMore").GetBoolean());
        var nextId = page1.GetProperty("pagination").GetProperty("nextAfterId").GetInt32();
        Assert.Equal(2, nextId);
        var page2 = await _client.GetFromJsonAsync<JsonElement>($"/api/v1/companies?afterId={nextId}&pageSize=2");
        var data2 = page2.GetProperty("data");
        Assert.Equal(1, data2.GetArrayLength()); // فقط رکورد سوم (آخر) می‌ماند
        Assert.Equal(3, data2[0].GetProperty("id").GetInt32());
        Assert.False(page2.GetProperty("pagination").GetProperty("hasMore").GetBoolean());
    }

    [Fact]
    public async Task Companies_NameFilter_PassesFilterToQuery()
    {
        Auth();
        var resp = await _client.GetAsync("/api/v1/companies?name=آلفا");
        Assert.True(resp.IsSuccessStatusCode);
        Assert.Contains(_factory.Fake.ExecutedCommands, c => c.Contains("cmpName LIKE"));
    }

    // ─── داده: کاربران (بدون رمز) ───

    [Fact]
    public async Task Users_List_Contains_No_Password_Field()
    {
        Auth();
        var body = await _client.GetStringAsync("/api/v1/users");
        Assert.DoesNotContain("password", body, StringComparison.OrdinalIgnoreCase);
        var json = JsonDocument.Parse(body).RootElement;
        Assert.Equal(2, json.GetProperty("data").GetArrayLength());
        Assert.Equal("مدیر سیستم", json.GetProperty("data")[0].GetProperty("fullName").GetString());
        Assert.True(json.GetProperty("data")[0].GetProperty("isAdmin").GetBoolean());
    }

    [Fact]
    public async Task Users_GetById_Works()
    {
        Auth();
        var resp = await _client.GetAsync("/api/v1/users/1");
        Assert.True(resp.IsSuccessStatusCode);
        var json = JsonDocument.Parse(await resp.Content.ReadAsStringAsync()).RootElement;
        Assert.Equal("admin", json.GetProperty("data").GetProperty("userName").GetString());
    }

    // ─── داده: اشخاص و مکالمات ───

    [Fact]
    public async Task Persons_List_Works()
    {
        Auth();
        var json = await _client.GetFromJsonAsync<JsonElement>("/api/v1/persons?companyId=1");
        Assert.Equal(1, json.GetProperty("data").GetArrayLength());
        Assert.Equal("علی رضایی", json.GetProperty("data")[0].GetProperty("fullName").GetString());
    }

    [Fact]
    public async Task Conversations_List_Works()
    {
        Auth();
        var json = await _client.GetFromJsonAsync<JsonElement>("/api/v1/conversations?companyId=1");
        Assert.True(json.GetProperty("data").GetArrayLength() >= 1);
        Assert.Equal("تماس اول", json.GetProperty("data")[0].GetProperty("subject").GetString());
    }

    // ─── همگام‌سازی ───

    [Fact]
    public async Task Sync_Companies_Keyset_Resume()
    {
        Auth();
        var page1 = await _client.GetFromJsonAsync<JsonElement>("/api/v1/sync/companies?afterId=0&limit=2");
        Assert.True(page1.GetProperty("pagination").GetProperty("hasMore").GetBoolean());
        var url = page1.GetProperty("pagination").GetProperty("nextPageUrl").GetString();
        Assert.NotNull(url);
        var page2 = await _client.GetFromJsonAsync<JsonElement>(url);
        Assert.Equal(3, page2.GetProperty("data")[0].GetProperty("id").GetInt32());
        Assert.False(page2.GetProperty("pagination").GetProperty("hasMore").GetBoolean());
    }

    // ─── سلامت و خطا ───

    [Fact]
    public async Task Health_Live_Is_Anonymous()
    {
        var resp = await _client.GetAsync("/health/live");
        Assert.True(resp.IsSuccessStatusCode);
    }

    [Fact]
    public async Task Health_Db_Reports_Schema()
    {
        Auth();
        var json = await _client.GetFromJsonAsync<JsonElement>("/health/db");
        Assert.Equal("Success", json.GetProperty("status").GetString());
        var report = json.GetProperty("data");
        Assert.Equal("IdealDb", report.GetProperty("databaseName").GetString());
        // از فاز ۱۱: هر موجودیت {mode, reason} دارد و mode همیشه Table است (SP غیرفعال)
        var companies = report.GetProperty("entityModes").GetProperty("Companies");
        Assert.Equal("Table", companies.GetProperty("mode").GetString());
        Assert.False(string.IsNullOrEmpty(companies.GetProperty("reason").GetString()));
    }

    [Fact]
    public async Task Database_Failure_Returns_503_Without_Internal_Details()
    {
        Auth();
        _factory.Fake.FailWhenSqlContains = "FROM dbo.Users U";
        try
        {
            var resp = await _client.GetAsync("/api/v1/users");
            Assert.Equal(HttpStatusCode.ServiceUnavailable, resp.StatusCode);
            var body = await resp.Content.ReadAsStringAsync();
            Assert.DoesNotContain("SIMULATED_SQL_FAILURE", body);      // جزئیات داخلی افشا نشود
            Assert.DoesNotContain("StackTrace", body, StringComparison.OrdinalIgnoreCase);
        }
        finally
        {
            _factory.Fake.FailWhenSqlContains = null;
        }
    }

    [Fact]
    public async Task Connection_Failure_Returns_503()
    {
        Auth();
        _factory.Fake.FailOnOpen = new SimulatedDbException("connection refused");
        try
        {
            var resp = await _client.GetAsync("/api/v1/companies");
            Assert.Equal(HttpStatusCode.ServiceUnavailable, resp.StatusCode);
        }
        finally
        {
            _factory.Fake.FailOnOpen = null;
        }
    }

    [Fact]
    public async Task Empty_Data_Returns_Empty_Array_With_Success()
    {
        Auth();
        _factory.Fake.ScriptHandler = sql => new DataTable();   // نتیجهٔ خالی برای همه
        try
        {
            var resp = await _client.GetAsync("/api/v1/companies");
            Assert.True(resp.IsSuccessStatusCode);
            var json = JsonDocument.Parse(await resp.Content.ReadAsStringAsync()).RootElement;
            Assert.Equal(JsonValueKind.Array, json.GetProperty("data").ValueKind);
            Assert.Equal(0, json.GetProperty("data").GetArrayLength());
            Assert.Equal("Success", json.GetProperty("status").GetString());
        }
        finally
        {
            _factory.RestoreDefaultScript();
        }
    }

    // ─── مدیریت توکن (کلید ادمین) ───

    // ─── سیاست دسترسی (فاز ۱۱) ───

    [Fact]
    public async Task No_StoredProcedure_Command_Is_Ever_Executed()
    {
        // اثبات رفتاری: پس از چند درخواست موفق، هیچ دستوری از نوع StoredProcedure اجرا نشده است
        Auth();
        await _client.GetAsync("/api/v1/companies?page=1&pageSize=5");
        await _client.GetAsync("/api/v1/users");
        await _client.GetAsync("/api/v1/persons");
        await _client.GetAsync("/health/db");
        Assert.NotEmpty(_factory.Fake.ExecutedCommandTypes);
        Assert.All(_factory.Fake.ExecutedCommandTypes, t => Assert.Equal(CommandType.Text, t));
    }

    [Fact]
    public async Task Missing_Core_Table_Blocks_Entity_With_Clear_503_Not_Empty_Data()
    {
        // جدول CrmCompany از کاوش حذف می‌شود → /health/db سیاست را تازه می‌کند → Companies مسدود
        // انتظار: 503 با پیام شفاف — هرگز پاسخ 200 با آرایهٔ خالی (باگ تاریخی فاز‌های قبل)
        Auth();
        var originalHandler = _factory.Fake.ScriptHandler;
        try
        {
            _factory.Fake.ScriptHandler = sql =>
            {
                if (sql.Contains("@@SERVERNAME"))
                {
                    var t = MakeQuery(("a", typeof(string)), ("b", typeof(string)), ("c", typeof(string)));
                    t.Rows.Add("FAKESERVER", "IdealDb", "Microsoft SQL Server 2019 Fake");
                    return t;
                }
                if (sql.Contains("sys.tables") && sql.Contains("sys.columns"))
                {
                    // هیچ جدولی موجود نیست → همهٔ موجودیت‌ها Blocked
                    return MakeQuery(("t", typeof(string)), ("c", typeof(string)));
                }
                if (sql.Contains("sys.procedures") && sql.Contains("COUNT"))
                {
                    var t = MakeQuery(("cnt", typeof(int)));
                    t.Rows.Add(0);
                    return t;
                }
                return null;
            };

            var health = await _client.GetAsync("/health/db");
            Assert.True(health.IsSuccessStatusCode);   // کاوش موفق؛ فقط سیاست تازه شده

            var resp = await _client.GetAsync("/api/v1/companies");
            Assert.Equal(HttpStatusCode.ServiceUnavailable, resp.StatusCode);
            var json = JsonDocument.Parse(await resp.Content.ReadAsStringAsync()).RootElement;
            Assert.Equal("Error", json.GetProperty("status").GetString());
            var msg = json.GetProperty("message").GetString()!;
            Assert.Contains("CrmCompany", msg, StringComparison.Ordinal);
            Assert.Contains("یافت نشد", msg, StringComparison.Ordinal);
        }
        finally
        {
            _factory.Fake.ScriptHandler = originalHandler;
            // برگرداندن سیاست سالم برای تست‌های بعدی
            await _client.GetAsync("/health/db");
        }
    }

    [Fact]
    public void DataAccessMode_Sp_Fails_Startup_With_Clear_Error()
    {
        // پیکربندی Sp باید ساخت هاست را با پیام واضح متوقف کند — نه اجرای SP و نه سکوت
        using var factory = _factory.WithWebHostBuilder(b => b.ConfigureAppConfiguration((_, cfg) =>
            cfg.AddInMemoryCollection(new Dictionary<string, string?> { ["IdealBridge:DataAccessMode"] = "Sp" })));
        var ex = Record.Exception(() => factory.Server);
        Assert.NotNull(ex);
        Assert.Contains("Stored Procedure", FlattenMessages(ex), StringComparison.OrdinalIgnoreCase);
    }

    private static string FlattenMessages(Exception ex)
    {
        var sb = new System.Text.StringBuilder();
        for (var e = ex; e is not null; e = e.InnerException)
            sb.AppendLine(e.Message);
        return sb.ToString();
    }

    private static DataTable MakeQuery(params (string name, Type type)[] cols)
    {
        var t = new DataTable();
        foreach (var (name, type) in cols) t.Columns.Add(name, type);
        return t;
    }

    [Fact]
    public async Task Tokens_Create_Requires_AdminKey()
    {
        var resp = await _client.PostAsJsonAsync("/api/v1/tokens", new { name = "X" });
        Assert.Equal(HttpStatusCode.Unauthorized, resp.StatusCode);

        _client.DefaultRequestHeaders.Add("X-Admin-Key", "wrong-key");
        resp = await _client.PostAsJsonAsync("/api/v1/tokens", new { name = "X" });
        Assert.Equal(HttpStatusCode.Unauthorized, resp.StatusCode);
    }

    [Fact]
    public async Task Tokens_Create_With_AdminKey_Returns_Token_Once()
    {
        _client.DefaultRequestHeaders.Add("X-Admin-Key", IdealBridgeApiFactory.AdminKey);
        var resp = await _client.PostAsJsonAsync("/api/v1/tokens", new { name = "MedPad-New", expiresInDays = 30 });
        Assert.True(resp.IsSuccessStatusCode);
        var json = JsonDocument.Parse(await resp.Content.ReadAsStringAsync()).RootElement;
        var token = json.GetProperty("data").GetProperty("token").GetString();
        Assert.StartsWith("ibk_", token);

        // توکن تازه واقعاً کار می‌کند
        var c2 = _factory.CreateClient();
        c2.DefaultRequestHeaders.Add("X-API-Key", token!);
        var ok = await c2.GetAsync("/api/v1/companies");
        Assert.True(ok.IsSuccessStatusCode);
    }
}

/// <summary>WebApplicationFactory با جایگزینی اتصال SQL واقعی با دوقلوی ساختگی.</summary>
public class IdealBridgeApiFactory : WebApplicationFactory<Program>
{
    public const string AdminKey = "test-admin-key-123";
    public FakeDbConnection Fake => ((FakeDbConnectionFactory)Services.GetRequiredService<IDbConnectionFactory>()).Connection;
    private string? _testToken;
    public string TestToken => _testToken ??= Services.GetRequiredService<IdealBridge.Security.TokenService>()
        .Create("IntegrationTest-Default", 1).PlainToken;
    public List<string> ScriptedCalls => Fake.ExecutedCommands;

    protected override void ConfigureWebHost(Microsoft.AspNetCore.Hosting.IWebHostBuilder builder)
    {
        builder.UseEnvironment("Testing");
        builder.ConfigureAppConfiguration((_, config) =>
        {
            config.AddInMemoryCollection(new Dictionary<string, string?>
            {
                ["IdealBridge:ConnectionString"] = "Server=fake;Database=IdealDb;User Id=ibk_reader;Password=fake;",
                ["IdealBridge:AdminKey"] = AdminKey,
                ["IdealBridge:TokenStorePath"] = Path.Combine(Path.GetTempPath(), "ibk-it-tokens-" + Guid.NewGuid().ToString("N") + ".json"),
                ["IdealBridge:DataAccessMode"] = "Table",
            });
        });
        builder.ConfigureServices(services =>
        {
            // جایگزینی کارخانهٔ اتصال واقعی با ساختگی — پیش از هر چیز ثبت‌شدهٔ SqlConnectionFactory حذف می‌شود
            services.RemoveAll<IDbConnectionFactory>();
            services.AddSingleton<IDbConnectionFactory>(new FakeDbConnectionFactory { Connection = CreateScriptedConnection() });
        });
    }

    public string CreateExpiredToken()
    {
        var path = Path.Combine(Path.GetTempPath(), "ibk-exp-" + Guid.NewGuid().ToString("N") + ".json");
        var svc = new IdealBridge.Security.TokenService(path);
        var created = svc.Create("Expired", 1);
        var json = File.ReadAllText(path).Replace("\"ExpiresAt\": \"", "\"ExpiresAt\": \"2000-01-01T00:00:00Z\"");
        File.WriteAllText(path, json);
        return created.PlainToken;
    }

    public string CreateAndRevokeToken()
    {
        var svc = Services.GetRequiredService<IdealBridge.Security.TokenService>();
        var created = svc.Create("ToRevoke", 1);
        svc.Revoke(created.Record.Id, "test");
        return created.PlainToken;
    }

    public void RestoreDefaultScript() => Fake.ScriptHandler = CreateScriptedConnection().ScriptHandler;

    // ─── دادهٔ ساختگی فقط-خواندنی (شبیه‌سازی خروجی جدول‌های Ideal) ───

    private static FakeDbConnection CreateScriptedConnection()
    {
        var companyCols = new (string name, Type type)[]
        {
            ("CompanyID", typeof(int)), ("cmpNumber", typeof(int)), ("cmpCode", typeof(string)), ("cmpName", typeof(string)),
            ("cmpNameEng", typeof(string)), ("cmpNameOfficial", typeof(string)), ("cmpFame", typeof(string)), ("cmpActivityType", typeof(string)),
            ("cmpTitleId", typeof(int)), ("CompanyTitle", typeof(string)),
            ("cmpGroupId", typeof(int)), ("GroupName", typeof(string)),
            ("cmpSubGroupId", typeof(int)), ("SubGroupName", typeof(string)),
            ("cmpGroupIdII", typeof(int)), ("GroupIIName", typeof(string)),
            ("cmpGroupIdIII", typeof(int)), ("GroupIIIName", typeof(string)),
            ("cmpGroupIdIV", typeof(int)), ("GroupIVName", typeof(string)),
            ("cmpTypeId", typeof(int)), ("CompanyTypeName", typeof(string)),
            ("cmpPresentationId", typeof(int)), ("Presentation", typeof(string)),
            ("cmpPreTel", typeof(string)), ("cmpTel", typeof(string)), ("cmpTelUpTo", typeof(string)), ("cmpTelDesc", typeof(string)),
            ("cmpPreTelII", typeof(string)), ("cmpTelII", typeof(string)), ("cmpTelUpToII", typeof(string)), ("cmpTelIIDesc", typeof(string)),
            ("cmpMobile", typeof(string)), ("cmpFax", typeof(string)), ("cmpFaxDesc", typeof(string)),
            ("cmpCountryId", typeof(int)), ("Country", typeof(string)), ("cmpProvinceId", typeof(int)), ("Province", typeof(string)),
            ("cmpCityId", typeof(int)), ("City", typeof(string)),
            ("cmpAddress", typeof(string)), ("cmpAddressDesc", typeof(string)), ("cmpZipCode", typeof(string)), ("cmpPostBox", typeof(string)),
            ("cmpWebSite", typeof(string)), ("cmpEmail", typeof(string)),
            ("cmpCoordinateLatitude", typeof(string)), ("cmpCoordinateLongitude", typeof(string)),
            ("cmpCoordinateZoomLevel", typeof(int)), ("cmpCoordinateLastDate", typeof(DateTime)),
            ("cmpRegistrationNumber", typeof(string)), ("cmpEconomicCode", typeof(string)), ("cmpNationalCode", typeof(string)),
            ("cmpBuyLimit", typeof(string)), ("cmpAccountNumber", typeof(string)),
            ("cmpReferUserId", typeof(int)), ("ReferUser", typeof(string)),
            ("LastEditUserId", typeof(int)), ("LastEditUser", typeof(string)),
            ("FirstRegisterUserId", typeof(int)), ("FirstRegisterUser", typeof(string)),
            ("cmpMainPersonId", typeof(int)), ("MainPersonName", typeof(string)),
            ("cmpIsDraft", typeof(bool)), ("cmpKind", typeof(int)),
            ("RegisterDate", typeof(DateTime)), ("RegisterDatePersian", typeof(string)), ("FirstRegisterDate", typeof(DateTime)),
            ("ImportDate", typeof(string)), ("ImportDateTime", typeof(DateTime)),
            ("cmpInteresting", typeof(string)), ("cmpSpecialPoint", typeof(string)), ("cmpDescription", typeof(string)),
        };

        DataTable CompanyTable()
        {
            var t = MakeTable(companyCols);
            void Row(int id, int number, string code, string name, string tel, string mobile, string country, string province, string city, string address, string lat, string lng, int? referUid, string? referUser, bool isDraft, DateTime regDate)
            {
                var r = t.NewRow();
                r["CompanyID"] = id; r["cmpNumber"] = number; r["cmpCode"] = code; r["cmpName"] = name;
                r["cmpNameEng"] = DBNull.Value; r["cmpNameOfficial"] = DBNull.Value; r["cmpFame"] = DBNull.Value; r["cmpActivityType"] = DBNull.Value;
                r["cmpTitleId"] = 1; r["CompanyTitle"] = "شرکتی"; r["cmpGroupId"] = 1; r["GroupName"] = "گروه یک";
                r["cmpSubGroupId"] = DBNull.Value; r["SubGroupName"] = DBNull.Value; r["cmpGroupIdII"] = DBNull.Value; r["GroupIIName"] = DBNull.Value;
                r["cmpGroupIdIII"] = DBNull.Value; r["GroupIIIName"] = DBNull.Value; r["cmpGroupIdIV"] = DBNull.Value; r["GroupIVName"] = DBNull.Value;
                r["cmpTypeId"] = DBNull.Value; r["CompanyTypeName"] = DBNull.Value; r["cmpPresentationId"] = DBNull.Value; r["Presentation"] = DBNull.Value;
                r["cmpPreTel"] = "021"; r["cmpTel"] = tel; r["cmpTelUpTo"] = DBNull.Value; r["cmpTelDesc"] = DBNull.Value;
                r["cmpPreTelII"] = "021"; r["cmpTelII"] = tel; r["cmpTelUpToII"] = DBNull.Value; r["cmpTelIIDesc"] = DBNull.Value;
                r["cmpMobile"] = mobile; r["cmpFax"] = DBNull.Value; r["cmpFaxDesc"] = DBNull.Value;
                r["cmpCountryId"] = 1; r["Country"] = country; r["cmpProvinceId"] = 8; r["Province"] = province; r["cmpCityId"] = 823; r["City"] = city;
                r["cmpAddress"] = address; r["cmpAddressDesc"] = DBNull.Value; r["cmpZipCode"] = "1234567890"; r["cmpPostBox"] = DBNull.Value;
                r["cmpWebSite"] = DBNull.Value; r["cmpEmail"] = DBNull.Value;
                r["cmpCoordinateLatitude"] = lat; r["cmpCoordinateLongitude"] = lng; r["cmpCoordinateZoomLevel"] = 12; r["cmpCoordinateLastDate"] = DBNull.Value;
                r["cmpRegistrationNumber"] = "REG-" + id; r["cmpEconomicCode"] = "ECO-" + id; r["cmpNationalCode"] = DBNull.Value;
                r["cmpBuyLimit"] = DBNull.Value; r["cmpAccountNumber"] = DBNull.Value;
                r["cmpReferUserId"] = referUid.HasValue ? referUid.Value : DBNull.Value;
                r["ReferUser"] = (object?)referUser ?? DBNull.Value;
                r["LastEditUserId"] = 3; r["LastEditUser"] = "کاربر نمونه"; r["FirstRegisterUserId"] = 3; r["FirstRegisterUser"] = "کاربر نمونه";
                r["cmpMainPersonId"] = DBNull.Value; r["MainPersonName"] = DBNull.Value;
                r["cmpIsDraft"] = isDraft; r["cmpKind"] = 1;
                r["RegisterDate"] = regDate; r["RegisterDatePersian"] = "14031120"; r["FirstRegisterDate"] = regDate;
                r["ImportDate"] = "14031120"; r["ImportDateTime"] = regDate;
                r["cmpInteresting"] = DBNull.Value; r["cmpSpecialPoint"] = DBNull.Value; r["cmpDescription"] = DBNull.Value;
                t.Rows.Add(r);
            }
            Row(1, 1001, "C-001", "شرکت آلفا", "77889900", "0912xxx", "ایران", "تهران", "تهران", "خیابان نمونه ۱", "35.123", "51.456", 3, "کاربر نمونه", false, new DateTime(2025, 1, 10));
            Row(2, 1002, "C-002", "شرکت بتا", "66778899", "0935xxx", "ایران", "تهران", "تهران", "خیابان نمونه ۲", "35.2", "51.5", 4, "کاربر نمونه ۲", false, new DateTime(2025, 2, 1));
            Row(3, 1003, "C-003", "شرکت گاما", "55667788", "0919xxx", "ایران", "اصفهان", "اصفهان", "خیابان نمونه ۳", "32.6", "51.6", null, null, true, new DateTime(2025, 3, 5));
            return t;
        }

        DataTable UsersTable()
        {
            var t = MakeTable(("UserId", typeof(int)), ("Row", typeof(int)), ("FName", typeof(string)), ("LName", typeof(string)), ("PersCode", typeof(string)), ("UserName", typeof(string)), ("IsAdmin", typeof(string)), ("IsActive", typeof(bool)), ("UserIsActiveInWinApp", typeof(bool)), ("UserIsActiveInWebApp", typeof(bool)), ("UserIsActiveInMobApp", typeof(bool)), ("Mobile", typeof(string)), ("MobileII", typeof(string)), ("Tel", typeof(string)), ("PositionId", typeof(int)), ("UserGroupId", typeof(int)), ("NationalCode", typeof(string)), ("StartDate", typeof(DateTime)), ("ExpireDate", typeof(DateTime)), ("Description", typeof(string)));
            var r1 = t.NewRow();
            r1["UserId"] = 1; r1["Row"] = 1; r1["FName"] = "مدیر"; r1["LName"] = "سیستم"; r1["PersCode"] = "P-1"; r1["UserName"] = "admin";
            r1["IsAdmin"] = "True"; r1["IsActive"] = true; r1["UserIsActiveInWinApp"] = true; r1["UserIsActiveInWebApp"] = true; r1["UserIsActiveInMobApp"] = true;
            r1["Mobile"] = "0912..."; r1["MobileII"] = DBNull.Value; r1["Tel"] = "021..."; r1["PositionId"] = 1; r1["UserGroupId"] = 1;
            r1["NationalCode"] = "0011111111"; r1["StartDate"] = new DateTime(2024, 1, 1); r1["ExpireDate"] = DBNull.Value; r1["Description"] = "مدیر کل";
            t.Rows.Add(r1);
            var r2 = t.NewRow();
            r2["UserId"] = 2; r2["Row"] = 2; r2["FName"] = "بازاریاب"; r2["LName"] = "نمونه"; r2["PersCode"] = "P-2"; r2["UserName"] = "sales1";
            r2["IsAdmin"] = "False"; r2["IsActive"] = true; r2["UserIsActiveInWinApp"] = true; r2["UserIsActiveInWebApp"] = true; r2["UserIsActiveInMobApp"] = false;
            r2["Mobile"] = "0935..."; r2["MobileII"] = DBNull.Value; r2["Tel"] = "021..."; r2["PositionId"] = 2; r2["UserGroupId"] = 1;
            r2["NationalCode"] = "0022222222"; r2["StartDate"] = new DateTime(2024, 2, 1); r2["ExpireDate"] = DBNull.Value; r2["Description"] = DBNull.Value;
            t.Rows.Add(r2);
            return t;
        }

        DataTable PersonsTable()
        {
            var t = MakeTable(("CompanyPersonID", typeof(int)), ("prsCompanyId", typeof(int)), ("CompanyName", typeof(string)), ("prsFName", typeof(string)), ("prsLName", typeof(string)), ("prsTitleId", typeof(int)), ("PersonTitle", typeof(string)), ("prsJobId", typeof(int)), ("Job", typeof(string)), ("prsTypeId", typeof(int)), ("PersonType", typeof(string)), ("prsGroupId", typeof(int)), ("PersonGroup", typeof(string)), ("prsSexId", typeof(int)), ("Sex", typeof(string)), ("prsEducationId", typeof(int)), ("Education", typeof(string)), ("prsDepartmentId", typeof(int)), ("Department", typeof(string)), ("prsPreTel", typeof(string)), ("prsTel", typeof(string)), ("prsTelUpTo", typeof(string)), ("prsTelDesc", typeof(string)), ("prsTelII", typeof(string)), ("prsFax", typeof(string)), ("prsMobile", typeof(string)), ("prsWebSite", typeof(string)), ("prsEmail", typeof(string)), ("prsEmailII", typeof(string)), ("prsCountryId", typeof(int)), ("Country", typeof(string)), ("prsProvinceId", typeof(int)), ("Province", typeof(string)), ("prsCityId", typeof(int)), ("City", typeof(string)), ("prsAddress", typeof(string)), ("prsZipCode", typeof(string)), ("prsPostBox", typeof(string)), ("prsNationalCode", typeof(string)), ("prsIdentityNumber", typeof(string)), ("prsFatherName", typeof(string)), ("prsBirthDate", typeof(string)), ("prsBirthPlace", typeof(string)), ("prsIsMarried", typeof(bool)), ("prsMarriageDate", typeof(string)), ("prsSkill", typeof(string)), ("prsStudyField", typeof(string)), ("prsInteresting", typeof(string)), ("prsSpecialPoint", typeof(string)), ("prsDescription", typeof(string)), ("ImportDate", typeof(string)), ("prsStopSendSms", typeof(bool)), ("prsWorkingOut", typeof(bool)));
            var r = t.NewRow();
            r["CompanyPersonID"] = 5; r["prsCompanyId"] = 1; r["CompanyName"] = "شرکت آلفا"; r["prsFName"] = "علی"; r["prsLName"] = "رضایی";
            r["prsTitleId"] = 1; r["PersonTitle"] = "جناب"; r["prsJobId"] = 1; r["Job"] = "مدیر فروش"; r["prsTypeId"] = 1; r["PersonType"] = "مدیر";
            r["prsGroupId"] = DBNull.Value; r["PersonGroup"] = DBNull.Value; r["prsSexId"] = 1; r["Sex"] = "مرد";
            r["prsEducationId"] = DBNull.Value; r["Education"] = DBNull.Value; r["prsDepartmentId"] = DBNull.Value; r["Department"] = DBNull.Value;
            r["prsPreTel"] = "021"; r["prsTel"] = "77889900"; r["prsTelUpTo"] = "10"; r["prsTelDesc"] = DBNull.Value;
            r["prsTelII"] = "021"; r["prsFax"] = DBNull.Value; r["prsMobile"] = "0912xxx"; r["prsWebSite"] = DBNull.Value; r["prsEmail"] = "ali@example"; r["prsEmailII"] = DBNull.Value;
            r["prsCountryId"] = 1; r["Country"] = "ایران"; r["prsProvinceId"] = 8; r["Province"] = "تهران"; r["prsCityId"] = 823; r["City"] = "تهران";
            r["prsAddress"] = "آدرس شخص"; r["prsZipCode"] = "1234567890"; r["prsPostBox"] = DBNull.Value;
            r["prsNationalCode"] = "1111111111"; r["prsIdentityNumber"] = "22222"; r["prsFatherName"] = "پدرعلی";
            r["prsBirthDate"] = "13700101"; r["prsBirthPlace"] = "تهران"; r["prsIsMarried"] = true; r["prsMarriageDate"] = "13950505";
            r["prsSkill"] = DBNull.Value; r["prsStudyField"] = DBNull.Value; r["prsInteresting"] = DBNull.Value; r["prsSpecialPoint"] = DBNull.Value; r["prsDescription"] = DBNull.Value;
            r["ImportDate"] = "14031120"; r["prsStopSendSms"] = false; r["prsWorkingOut"] = false;
            t.Rows.Add(r);
            return t;
        }

        DataTable ConversationsTable()
        {
            var t = MakeTable(("ConversationID", typeof(int)), ("cnvsProjectId", typeof(int)), ("cnvsCompanyId", typeof(int)), ("CompanyName", typeof(string)), ("cnvsDateTime", typeof(DateTime)), ("cnvsDate", typeof(string)), ("cnvsDay", typeof(string)), ("cnvsTime", typeof(string)), ("cnvsTopicId", typeof(int)), ("TopicName", typeof(string)), ("cnvsSubject", typeof(string)), ("cnvsPersonId", typeof(int)), ("cnvsUserId", typeof(int)), ("UserName", typeof(string)), ("cnvsReferUserId", typeof(int)), ("ReferUserName", typeof(string)), ("cnvsReferDesc", typeof(string)), ("cnvsStatusId", typeof(int)), ("ConversationStatus", typeof(string)), ("cnvsPriorityId", typeof(int)), ("cnvsRemindDateTime", typeof(DateTime)), ("cnvsRemindOk", typeof(bool)), ("cnvsIsBookMark", typeof(bool)), ("cnvsIsTicket", typeof(bool)), ("cnvsIsTicketNew", typeof(bool)), ("RegisterDate", typeof(DateTime)), ("RegisterDatePersian", typeof(string)), ("FirstRegisterDate", typeof(DateTime)));
            var r = t.NewRow();
            r["ConversationID"] = 10; r["cnvsProjectId"] = DBNull.Value; r["cnvsCompanyId"] = 1; r["CompanyName"] = "شرکت آلفا";
            r["cnvsDateTime"] = new DateTime(2025, 4, 1, 10, 30, 0); r["cnvsDate"] = "14040112"; r["cnvsDay"] = "یکشنبه"; r["cnvsTime"] = "10:30";
            r["cnvsTopicId"] = 1; r["TopicName"] = "تماس تلفنی"; r["cnvsSubject"] = "تماس اول"; r["cnvsPersonId"] = 5;
            r["cnvsUserId"] = 1; r["UserName"] = "مدیر سیستم"; r["cnvsReferUserId"] = 1; r["ReferUserName"] = "مدیر سیستم"; r["cnvsReferDesc"] = DBNull.Value;
            r["cnvsStatusId"] = 1; r["ConversationStatus"] = "انجام‌شده"; r["cnvsPriorityId"] = 1; r["cnvsRemindDateTime"] = new DateTime(2025, 4, 2);
            r["cnvsRemindOk"] = true; r["cnvsIsBookMark"] = false; r["cnvsIsTicket"] = false; r["cnvsIsTicketNew"] = false;
            r["RegisterDate"] = new DateTime(2025, 4, 1); r["RegisterDatePersian"] = "14040112"; r["FirstRegisterDate"] = new DateTime(2025, 4, 1);
            t.Rows.Add(r);
            return t;
        }

        var conn = new FakeDbConnection
        {
            ScriptHandler = sql =>
            {
                // ۱) کاوش سرور
                if (sql.Contains("@@SERVERNAME")) { var t = MakeTable(("a", typeof(string)), ("b", typeof(string)), ("c", typeof(string))); t.Rows.Add("FAKESERVER", "IdealDb", "Microsoft SQL Server 2019 (RTM-CU8) Fake"); return t; }
                // ۲) کاوش ستون‌ها
                if (sql.Contains("sys.tables") && sql.Contains("sys.columns"))
                {
                    var t = MakeTable(("t", typeof(string)), ("c", typeof(string)));
                    foreach (var (tbl, cols) in SchemaProbe.RequiredTableColumns)
                        foreach (var col in cols)
                            t.Rows.Add(tbl, col);
                    return t;
                }
                // ۳) وجود SP
                if (sql.Contains("sys.procedures") && sql.Contains("COUNT")) { var t = MakeTable(("cnt", typeof(int))); t.Rows.Add(0); return t; }
                // ۴) لیست مشتریان
                if (sql.Contains("FROM dbo.CrmCompany CC")) return CompanyTable();
                // ۵) کاربران
                if (sql.Contains("FROM dbo.Users U")) return UsersTable();
                // ۶) اشخاص
                if (sql.Contains("FROM dbo.CrmCompanyPersons P")) return PersonsTable();
                // ۷) مکالمات
                if (sql.Contains("FROM dbo.CrmConversation C")) return ConversationsTable();
                return null;
            }
        };
        return conn;
    }

    private static DataTable MakeTable(params (string name, Type type)[] cols)
    {
        var t = new DataTable();
        foreach (var (name, type) in cols) t.Columns.Add(name, type);
        return t;
    }
}
