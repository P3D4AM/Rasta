using IdealBridge.Security;
using Xunit;

namespace IdealBridge.UnitTests;

public class TokenServiceTests : IDisposable
{
    private readonly string _path;
    private readonly TokenService _svc;

    public TokenServiceTests()
    {
        _path = Path.Combine(Path.GetTempPath(), "ibk-tests-" + Guid.NewGuid().ToString("N") + ".json");
        _svc = new TokenService(_path);
    }

    public void Dispose()
    {
        try { File.Delete(_path); } catch { }
    }

    [Fact]
    public void Create_Returns_PlainToken_And_Stores_Only_Hash()
    {
        var result = _svc.Create("MedPad-Test", 30);
        Assert.StartsWith("ibk_", result.PlainToken);
        Assert.NotEmpty(result.Record.TokenHash);
        Assert.DoesNotContain(result.PlainToken, result.Record.TokenHash);
        // مقدار خام توکن نباید در فایل ذخیره شود
        var fileContent = File.ReadAllText(_path);
        Assert.DoesNotContain(result.PlainToken, fileContent);
        Assert.Contains(result.Record.TokenHash, fileContent);
    }

    [Fact]
    public void Validate_Accepts_Created_Token()
    {
        var created = _svc.Create("MedPad-Test", 30);
        var validated = _svc.Validate(created.PlainToken);
        Assert.NotNull(validated);
        Assert.Equal("MedPad-Test", validated.Name);
        Assert.True(validated.IsActive);
    }

    [Fact]
    public void Validate_Rejects_Wrong_Token()
    {
        _svc.Create("MedPad-Test", 30);
        Assert.Null(_svc.Validate("ibk_totally-wrong-token"));
        Assert.Null(_svc.Validate(""));
        Assert.Null(_svc.Validate("garbage"));
    }

    [Fact]
    public void Revoke_Makes_Token_Invalid()
    {
        var created = _svc.Create("MedPad-Test", 30);
        Assert.NotNull(_svc.Validate(created.PlainToken));
        Assert.True(_svc.Revoke(created.Record.Id, "test revoke"));
        Assert.Null(_svc.Validate(created.PlainToken));
    }

    [Fact]
    public void Expired_Token_Is_Invalid()
    {
        var created = _svc.Create("MedPad-Test", 1);
        // دستکاری زمان انقضا به گذشته در فایل + ساخت سرویس جدید روی همان فایل
        var json = File.ReadAllText(_path);
        json = json.Replace("\"ExpiresAt\": \"", "\"ExpiresAt\": \"2000-01-01T00:00:00Z\"");
        File.WriteAllText(_path, json);
        var svc2 = new TokenService(_path);
        Assert.Null(svc2.Validate(created.PlainToken));
    }

    [Fact]
    public void Tokens_Persist_Across_Instances()
    {
        var created = _svc.Create("Persist-Test", 10);
        var svc2 = new TokenService(_path);
        Assert.NotNull(svc2.Validate(created.PlainToken));
    }

    [Fact]
    public void Create_Requires_Name()
    {
        Assert.Throws<ArgumentException>(() => _svc.Create("  ", 10));
        Assert.Throws<ArgumentException>(() => _svc.Create("", 10));
    }

    [Fact]
    public void List_Shows_Records_Without_PlainTokens()
    {
        var created = _svc.Create("Listed", 5);
        var all = _svc.List();
        Assert.Contains(all, t => t.Id == created.Record.Id);
        Assert.All(all, t => Assert.DoesNotContain("ibk_", t.TokenHash));
    }
}
