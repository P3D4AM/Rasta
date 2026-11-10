using IdealBridge.Domain.Common;

namespace IdealBridge.Domain.Dto;

/// <summary>فیلترهای درخواست لیست مشتریان.</summary>
public class CompanyListQuery : Common.PagedQuery
{
    /// <summary>فیلتر دقیق یا جست‌وجوی پیشوندی کد مشتری.</summary>
    public string? Code { get; set; }

    /// <summary>جست‌وجوی بخشی از نام مشتری (LIKE %value%).</summary>
    public string? Name { get; set; }

    /// <summary>شمارهٔ مشتری (تطابق دقیق).</summary>
    public int? Number { get; set; }

    /// <summary>از تاریخ ثبت (میلادی) — معادل FromRegisterDate در API قدیم.</summary>
    public DateTime? RegisteredFrom { get; set; }

    /// <summary>تا تاریخ ثبت (میلادی) — معادل ToRegisterDate.</summary>
    public DateTime? RegisteredTo { get; set; }

    /// <summary>از تاریخ ثبت اولیه (FirstRegisterDate).</summary>
    public DateTime? FirstRegisteredFrom { get; set; }

    /// <summary>تا تاریخ ثبت اولیه.</summary>
    public DateTime? FirstRegisteredTo { get; set; }

    /// <summary>شناسهٔ بازاریاب/معرف (cmpReferUserId).</summary>
    public int? ReferUserId { get; set; }

    /// <summary>نقطهٔ شروع پیمایش Keyset: فقط رکوردهای با شناسهٔ بزرگ‌تر (پارامتر afterId).</summary>
    public new int? AfterId { get => base.AfterId; set => base.AfterId = value; }

    /// <summary>فقط پیش‌نویس‌ها (cmpIsDraft=1) یا فقط نهایی‌ها (false).</summary>
    public bool? IsDraft { get; set; }
}

public class PersonListQuery : Common.PagedQuery
{
    public int? CompanyId { get; set; }
    public string? Name { get; set; }
    public string? Mobile { get; set; }
    public bool? WorkingOut { get; set; }
}

public class ConversationListQuery : Common.PagedQuery
{
    public int? CompanyId { get; set; }
    public int? ProjectId { get; set; }
    public int? UserId { get; set; }
    public DateTime? FromDate { get; set; }
    public DateTime? ToDate { get; set; }
}

public class ProjectListQuery : Common.PagedQuery
{
    public int? CompanyId { get; set; }
    public string? Title { get; set; }
    public DateTime? RegisteredFrom { get; set; }
    public DateTime? RegisteredTo { get; set; }
    public bool? IsFinished { get; set; }
}

public class ReminderListQuery : Common.PagedQuery
{
    public int UserId { get; set; }
    public DateTime? FromDate { get; set; }
    public DateTime? ToDate { get; set; }
    public bool? IncludeDone { get; set; }
}

public class ProductListQuery : Common.PagedQuery
{
    public string? Code { get; set; }
    public string? Name { get; set; }
    public int? GroupId { get; set; }
    public DateTime? RegisteredFrom { get; set; }
    public DateTime? RegisteredTo { get; set; }
}

public class OrderListQuery : Common.PagedQuery
{
    public long? Number { get; set; }
    public int? CompanyId { get; set; }
    public DateTime? FromDate { get; set; }        // ordDateTime
    public DateTime? ToDate { get; set; }
    public DateTime? RegisteredFrom { get; set; }  // RegisterDate
    public DateTime? RegisteredTo { get; set; }
    public bool? IsVerified { get; set; }
}

public class PreOrderListQuery : Common.PagedQuery
{
    public long? Number { get; set; }
    public int? CompanyId { get; set; }
    public DateTime? FromDate { get; set; }
    public DateTime? ToDate { get; set; }
    public bool? IsVerified { get; set; }
}

/// <summary>پارامترهای همگام‌سازی افزایشی/اسنپ‌شات (سند ۱۰).</summary>
public class SyncQuery
{
    /// <summary>شروع بازهٔ ثبت (میلادی) — برای دریافت مشتریان تازه‌ثبت‌شده.</summary>
    public DateTime? RegisteredFrom { get; set; }

    public DateTime? RegisteredTo { get; set; }

    /// <summary>ادامه از این شناسه (Keyset) — بعد از قطع ارتباط، از آخرین شناسهٔ موفق ادامه دهید.</summary>
    public int? AfterId { get; set; }

    /// <summary>حداکثر رکورد در هر پاسخ (۱ تا ۵۰۰).</summary>
    public int Limit { get; set; } = 100;
}
