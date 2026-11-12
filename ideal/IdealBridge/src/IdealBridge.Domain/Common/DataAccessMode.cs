namespace IdealBridge.Domain.Common;

/// <summary>
/// حالت مؤثر دسترسی به دادهٔ یک موجودیت.
/// از فاز ۱۱: اجرای Stored Procedure به‌کلی از کد حذف شده است؛
/// تنها حالت اجرایی «Table» است و «Blocked» یعنی دادهٔ جدولِ پشتیبان در دسترس نیست.
/// </summary>
public enum DataAccessMode
{
    /// <summary>خواندن مستقیم پارامتری از جدول هسته (تنها مسیر اجرایی مجاز).</summary>
    Table,

    /// <summary>ذخیرهٔ آینده — در این نسخه هیچ مسیر اجرایی برای آن وجود ندارد.</summary>
    Sp,

    /// <summary>جدول پشتیبان مفقود/ناقص است — درخواست باید با خطای شفاف رد شود.</summary>
    Blocked
}

/// <summary>حالت دسترسی یک موجودیت به‌همراه دلیل (برای گزارش سلامت و خطاها).</summary>
public sealed class EntityAccessInfo
{
    public DataAccessMode Mode { get; init; }
    public string Reason { get; init; } = string.Empty;

    public override string ToString() => Mode == DataAccessMode.Blocked ? $"Blocked: {Reason}" : Mode.ToString();
}

/// <summary>
/// دسترسی به یک موجودیت ممکن نیست (جدول مفقود/ناقص یا مسیر پشتیبانی‌نشده).
/// برخلاف «آرایهٔ خالی بی‌صدا»، این خطا همیشه به کلاینت با پیام مشخص گزارش می‌شود.
/// </summary>
public sealed class DataAccessUnavailableException : Exception
{
    public string Entity { get; }

    public DataAccessUnavailableException(string entity, string reason)
        : base($"دسترسی به دادهٔ «{entity}» ممکن نیست: {reason}")
        => Entity = entity;
}
