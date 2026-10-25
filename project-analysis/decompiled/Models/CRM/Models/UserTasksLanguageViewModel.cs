using System;
using System.ComponentModel.DataAnnotations;
using CRM.Resources;

namespace CRM.Models;

public class UserTasksLanguageViewModel
{
	[Key]
	public int UserTaskId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "UserTaskDate")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	[RegularExpression("(\\d{4})[-\\/](\\d{2})[-\\/](\\d{2})$", ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorNotCorrent")]
	public string UserTaskDatePersian { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "UserTaskDate")]
	public DateTime UserTaskDate { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "UserTaskTime")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	[RegularExpression("^([0-9]|0[0-9]|1[0-9]|2[0-3]):[0-5][0-9]$", ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorNotCorrent")]
	public string UserTaskTime { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "UserTaskTitle")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	[MaxLength(100, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(100, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string UserTaskTitle { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "UserTaskDescription")]
	[MaxLength(2000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(2000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string UserTaskDescription { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "UserTaskPriorityId")]
	public int? UserTaskPriorityId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "UserTaskGroupId")]
	public int? UserTaskGroupId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "UserTaskShowAllarm")]
	public int? UserTaskShowAllarm { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "UserTaskDidIt")]
	public bool? UserTaskDidIt { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cReminderUser")]
	public int UserId { get; set; }

	public short Year1 { get; set; }

	public short Month1 { get; set; }

	public DateTime RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "UserTaskRemindDate")]
	[RegularExpression("(\\d{4})[-\\/](\\d{2})[-\\/](\\d{2})$", ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorNotCorrent")]
	public string UserTaskRemindDate { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "UserTaskRemindTime")]
	[RegularExpression("^([0-9]|0[0-9]|1[0-9]|2[0-3]):[0-5][0-9]$", ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorNotCorrent")]
	public string UserTaskRemindTime { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "UserTaskIsPublic")]
	public bool? UserTaskIsPublic { get; set; }

	public Guid? GUId { get; set; }

	public string AppType { get; set; }

	public int? LanguageID { get; set; }

	public int? FirstRegisterUserId { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public DateTime? FirstRegisterDate { get; set; }

	public DateTime? UserTaskRemindDateTime { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "UserTaskTimeEnd")]
	[RegularExpression("^([0-9]|0[0-9]|1[0-9]|2[0-3]):[0-5][0-9]$", ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorNotCorrent")]
	public string UserTaskTimeEnd { get; set; }

	public int? WeekdayNum { get; set; }

	public int? UserTaskTimeEndHour { get; set; }

	public int? UserTaskTimeEndMinute { get; set; }

	public int? ObjectTypeId { get; set; }

	public int? ObjectId { get; set; }

	public string Object { get; set; }

	public bool? UserTaskRepeatDaily { get; set; }

	public bool? UserTaskRepeatWeekly { get; set; }

	public bool? UserTaskRepeatMonthly { get; set; }

	public bool? UserTaskRepeatYearly { get; set; }

	public bool? UserTaskRemindRepeatDaily { get; set; }

	public bool? UserTaskRemindRepeatWeekly { get; set; }

	public bool? UserTaskRemindRepeatMonthly { get; set; }

	public bool? UserTaskRemindRepeatYearly { get; set; }

	public bool? UserTaskNoTimeOverlap { get; set; }

	public string UserTaskCompanyIds { get; set; }

	public string UserTaskCompanys { get; set; }

	public string TaskPriorityColor { get; set; }

	public int? Type { get; set; }

	public string UserTaskTitle_Lang { get; set; }

	public string UserTaskDescription_Lang { get; set; }

	public DateTime? UserTaskDateEnd { get; set; }

	public string UserTaskDateEndPersian { get; set; }

	public string UserTaskLinkIdStr { get; set; }

	public bool? SendToOutlook { get; set; }

	public DateTime? UserTaskDidItDate { get; set; }

	public string UserTaskDidItDatePersian { get; set; }
}
