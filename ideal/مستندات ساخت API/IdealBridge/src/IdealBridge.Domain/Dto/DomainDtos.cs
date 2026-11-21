namespace IdealBridge.Domain.Dto;

/// <summary>مکالمه/پیگیری (CrmConversation) — سوابق ارتباط با مشتری.</summary>
public class ConversationDto
{
    public int Id { get; set; }                    // ConversationID
    public int? ProjectId { get; set; }            // cnvsProjectId
    public int? CompanyId { get; set; }            // cnvsCompanyId
    public string? CompanyName { get; set; }
    public DateTime? DateTimeUtcLike { get; set; } // cnvsDateTime (تاریخ میلادی ثبت)
    public string? Date { get; set; }              // cnvsDate (شمسی)
    public string? Day { get; set; }
    public string? Time { get; set; }
    public int? TopicId { get; set; }
    public string? Topic { get; set; }
    public string? Subject { get; set; }           // cnvsSubject
    public int? PersonId { get; set; }             // cnvsPersonId (شخص مرتبط)
    public int? UserId { get; set; }               // کاربر ثبت‌کننده/مسئول
    public string? User { get; set; }
    public int? ReferUserId { get; set; }          // ارجاع‌شده به
    public string? ReferUser { get; set; }
    public string? ReferDesc { get; set; }
    public int? StatusId { get; set; }
    public string? Status { get; set; }
    public int? PriorityId { get; set; }
    public string? Priority { get; set; }
    public string? RemindDate { get; set; }
    public string? RemindTime { get; set; }
    public DateTime? RemindDateTime { get; set; }
    public bool? RemindOk { get; set; }
    public bool? IsBookMark { get; set; }
    public bool? IsTicket { get; set; }
    public bool? IsTicketRead { get; set; }
    public DateTime? RegisterDate { get; set; }
    public string? RegisterDatePersian { get; set; }
    public DateTime? FirstRegisterDate { get; set; }
}

/// <summary>پروژهٔ مرتبط با مشتری (CrmProjects).</summary>
public class ProjectDto
{
    public int Id { get; set; }                    // ProjectID
    public int? CompanyId { get; set; }            // prjCompanyId
    public string? CompanyName { get; set; }
    public string? Title { get; set; }             // prjTitle
    public string? Subject { get; set; }           // prjSubject
    public string? Description { get; set; }       // prjDesc
    public DateTime? StartDateTime { get; set; }   // prjStartDateTime
    public string? StartDate { get; set; }         // prjStartDate (شمسی)
    public string? StartTime { get; set; }
    public int? StarterUserId { get; set; }
    public bool? IsFinished { get; set; }          // prjIsFinished
    public int? FinishedStatusId { get; set; }     // prjFinishedStatusId
    public string? FinishedDate { get; set; }
    public DateTime? FinishedDateTime { get; set; }
    public int? FinishedUserId { get; set; }
    public int? GradeId { get; set; }
    public string? Grade { get; set; }
    public int? PriorityId { get; set; }
    public string? Priority { get; set; }
    public int? GroupId { get; set; }
    public string? Group { get; set; }
    public int? StatusGroupId { get; set; }        // prjcnvsStatusGroupId
    public string? NumRef { get; set; }            // prjNumRef
    public long? NumR { get; set; }                // prjNumR
    public string? PostFix { get; set; }           // prjPostFix
    public int? ReferUserId { get; set; }
    public DateTime? RegisterDate { get; set; }
    public string? RegisterDatePersian { get; set; }
    public DateTime? FirstRegisterDate { get; set; }
    public int? LastEditUserId { get; set; }       // UserId
}

/// <summary>وظیفه/یادآوری کارتبل (CrmUserTasks).</summary>
public class ReminderDto
{
    public int Id { get; set; }                    // UserTaskId
    public int UserId { get; set; }                // مالک وظیفه
    public string? User { get; set; }
    public string? DatePersian { get; set; }       // UserTaskDatePersian
    public DateTime? Date { get; set; }            // UserTaskDate
    public string? Time { get; set; }              // UserTaskTime
    public string? TimeEnd { get; set; }           // UserTaskTimeEnd
    public string? Title { get; set; }
    public string? Description { get; set; }
    public int? PriorityId { get; set; }
    public string? Priority { get; set; }
    public int? GroupId { get; set; }
    public string? Group { get; set; }
    public bool? DidIt { get; set; }               // انجام‌شده
    public DateTime? DidItDate { get; set; }
    public string? RemindDate { get; set; }
    public string? RemindTime { get; set; }
    public DateTime? RemindDateTime { get; set; }
    public bool? IsPublic { get; set; }
    public int? ObjectTypeId { get; set; }         // ارتباط با شیء (مشتری/مکالمه/...)
    public int? ObjectId { get; set; }
    public string? Object { get; set; }
    public string? CompanyIds { get; set; }        // UserTaskCompanyIds (csv)
    public string? Companies { get; set; }
    public bool? RepeatDaily { get; set; }
    public bool? RepeatWeekly { get; set; }
    public bool? RepeatMonthly { get; set; }
    public bool? RepeatYearly { get; set; }
    public DateTime? RegisterDate { get; set; }
}

/// <summary>انبار (WsWareHouse).</summary>
public class WarehouseDto
{
    public int Id { get; set; }                    // WareHouseID
    public string? Name { get; set; }              // WrhsName
    public string? Code { get; set; }              // WrhsCode
    public string? Address { get; set; }
    public string? PreTel { get; set; }
    public string? Tel { get; set; }
    public string? Tel2 { get; set; }
    public string? Tel3 { get; set; }
    public string? Fax { get; set; }
    public string? Area { get; set; }
    public string? Person { get; set; }            // مسئول انبار
    public string? Description { get; set; }
    public bool? DeActive { get; set; }            // WrhsDeActive
    public int? OrderView { get; set; }
    public DateTime? RegisterDate { get; set; }
}

/// <summary>محصول (WSProducts) — زیرمجموعهٔ هسته.</summary>
public class ProductDto
{
    public int Id { get; set; }                    // ProductID
    public int? GroupId { get; set; }              // PrdGroupID
    public string? GroupName { get; set; }
    public string? Code { get; set; }              // PrdCode
    public string? Name { get; set; }              // PrdName
    public string? LatinName { get; set; }         // PrdLatinName
    public string? Type { get; set; }              // PrdType
    public string? Model { get; set; }
    public int? ColorId { get; set; }
    public string? Color { get; set; }
    public int? UnitId { get; set; }
    public string? Unit { get; set; }
    public string? FirstBarcode { get; set; }
    public bool? InActive { get; set; }            // PrdInActive
    public bool? InactiveInSale { get; set; }      // PrdInactiveInSale
    public bool? InactiveInBuy { get; set; }
    public int? MinQuantity { get; set; }
    public int? MaxQuantity { get; set; }
    public double? Weight { get; set; }
    public string? Description { get; set; }
    public DateTime? RegisterDate { get; set; }
    public DateTime? FirstRegisterDate { get; set; }
}

/// <summary>سفارش فروش (WSOrder) — زیرمجموعهٔ هسته.</summary>
public class OrderDto
{
    public int Id { get; set; }                    // OrderID
    public long? Number { get; set; }              // ordNumber
    public string? Title { get; set; }             // ordTitle
    public string? Date { get; set; }              // ordDate (شمسی)
    public DateTime? DateTime { get; set; }        // ordDateTime
    public int? CompanyId { get; set; }            // ordCompanyId
    public string? CompanyName { get; set; }
    public int? CompanyPersonId { get; set; }      // ordCompanyPersonId
    public int? ProjectId { get; set; }            // ordProjectId
    public string? Subject { get; set; }
    public int? ItemCount { get; set; }
    public decimal? ItemsAmount { get; set; }
    public decimal? Discount { get; set; }
    public decimal? SumAmount { get; set; }
    public decimal? Tax { get; set; }
    public decimal? TotalAmount { get; set; }
    public bool? IsVerified { get; set; }          // ordIsVerified
    public int? StatusId { get; set; }             // ordStatusId
    public string? Status { get; set; }
    public int? OprId { get; set; }                // OrderOprID (نوع سند)
    public string? Opr { get; set; }
    public int? ReferUserId { get; set; }          // ordReferUserId (بازاریاب)
    public string? ReferUser { get; set; }
    public int? SellerId { get; set; }             // ordSellerId
    public DateTime? RegisterDate { get; set; }
    public DateTime? FirstRegisterDate { get; set; }
    public DateTime? LastEditDate { get; set; }    // TspOrdLastEditDate — تنها ستون ویرایش قابل‌اتکا (سامانهٔ مالیات)
}

/// <summary>پیش‌سفارش (WSPreOrder) — زیرمجموعهٔ هسته.</summary>
public class PreOrderDto
{
    public int Id { get; set; }                    // PreOrderID
    public long? Number { get; set; }              // pordNumber
    public string? Title { get; set; }             // pordTitle
    public string? Date { get; set; }              // pordDate (شمسی)
    public DateTime? DateTime { get; set; }        // pordDateTime
    public int? CompanyId { get; set; }            // pordCompanyId
    public string? CompanyName { get; set; }
    public int? CompanyPersonId { get; set; }
    public int? ProjectId { get; set; }
    public string? Subject { get; set; }
    public int? ItemCount { get; set; }
    public decimal? ItemsAmount { get; set; }
    public decimal? Discount { get; set; }
    public decimal? SumAmount { get; set; }
    public decimal? Tax { get; set; }
    public decimal? TotalAmount { get; set; }
    public bool? IsVerified { get; set; }
    public int? StatusId { get; set; }
    public string? Status { get; set; }
    public int? OprId { get; set; }                // PreOrderOprID
    public string? Opr { get; set; }
    public int? ReferUserId { get; set; }
    public string? ReferUser { get; set; }
    public DateTime? RegisterDate { get; set; }
    public DateTime? FirstRegisterDate { get; set; }
    public DateTime? ChangeStatusDate { get; set; } // pordChangeStatusDate
}

/// <summary>آدرس‌های اضافهٔ مشتری (CrmCompanyAddresses).</summary>
public class CompanyAddressDto
{
    public int Id { get; set; }                    // CompanyAddressId
    public int CompanyId { get; set; }             // cmpaddCompanyId
    public int? TypeId { get; set; }               // cmpaddTypeId
    public string? Type { get; set; }
    public int? CityId { get; set; }
    public string? City { get; set; }
    public string? Address { get; set; }           // CompanyAddress
    public string? Description { get; set; }       // cmpaddDesc
    public string? ZipCode { get; set; }
    public string? PostBox { get; set; }
    public string? Latitude { get; set; }          // cmpaddCoordinateLatitude
    public string? Longitude { get; set; }
    public int? CoordinateZoomLevel { get; set; }
    public DateTime? CoordinateLastDate { get; set; }
    public DateTime? RegisterDate { get; set; }
}

/// <summary>آیتم اطلاعات پایه (عنوان/گروه/شهر/...).</summary>
public class BaseInfoDto
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Code { get; set; }
    public string? Description { get; set; }
    public int? ParentId { get; set; }
    public bool? IsActive { get; set; }
    public int? OrderView { get; set; }
}
