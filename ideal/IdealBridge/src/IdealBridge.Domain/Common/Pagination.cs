using System.Text.Json.Serialization;

namespace IdealBridge.Domain.Common;

/// <summary>پارامترهای صفحه‌بندی Keyset (afterId + limit) و صفحه‌ای (page/pageSize).</summary>
public class PagedQuery
{
    /// <summary>صفحهٔ درخواستی (۱-مبنا). صفر یا نامعتبر → ۱.</summary>
    public int Page { get; set; } = 1;

    /// <summary>اندازهٔ صفحه (۱ تا ۵۰۰). پیش‌فرض ۲۰.</summary>
    public int PageSize { get; set; } = 20;

    public const int MaxPageSize = 500;
    public const int DefaultPageSize = 20;

    public int Skip => (Math.Max(Page, 1) - 1) * Take;
    public int Take => Math.Clamp(PageSize <= 0 ? DefaultPageSize : PageSize, 1, MaxPageSize);

    /// <summary>شناسهٔ آخرین رکوردِ قبلی برای پیمایش Keyset (پایدار و قابل ازسرگیری).</summary>
    public int? AfterId { get; set; }

    /// <summary>اگر AfterId مقدار داشته باشد پیمایش Keyset فعال است.</summary>
    [JsonIgnore]
    public bool IsKeyset => AfterId.HasValue;
}

/// <summary>اطلاعات صفحه‌بندی که در پاسخ برمی‌گردد.</summary>
public class PaginationInfo
{
    /// <summary>شمارهٔ صفحهٔ فعلی (۱-مبا؛ در حالت Keyset برابر صفحهٔ محاسبه‌شدهٔ منطقی).</summary>
    public int Page { get; set; }

    public int PageSize { get; set; }

    /// <summary>تعداد کل رکوردهای منطبق (در حالت Keyset حداقلِ شمارش تا انتهای صفحهٔ جاری).</summary>
    public long? TotalCount { get; set; }

    /// <summary>آیا صفحهٔ بعدی وجود دارد؟</summary>
    public bool HasMore { get; set; }

    /// <summary>شناسهٔ آخرین رکورد این صفحه — برای فراخوانی بعدی به‌عنوان afterId.</summary>
    public int? NextAfterId { get; set; }

    /// <summary>آدرس نسبی صفحهٔ بعد (در صورت وجود) برای ادامهٔ دریافت.</summary>
    public string? NextPageUrl { get; set; }
}
