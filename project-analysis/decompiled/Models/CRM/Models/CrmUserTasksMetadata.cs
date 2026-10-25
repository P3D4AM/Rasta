using System;
using System.ComponentModel.DataAnnotations;
using CRM.Resources;

namespace CRM.Models;

public class CrmUserTasksMetadata
{
	[Key]
	public int UserTaskId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "UserTaskDate")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	[RegularExpression("(?:1[234]\\d{2})\\/(?:0?[1-9]|1[0-2])\\/(?:0?[1-9]|[12][0-9]|3[01])$", ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorNotCorrent")]
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

	public int UserId { get; set; }

	public short Year1 { get; set; }

	public short Month1 { get; set; }

	public DateTime RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "UserTaskRemindDate")]
	[RegularExpression("(?:1[234]\\d{2})\\/(?:0?[1-9]|1[0-2])\\/(?:0?[1-9]|[12][0-9]|3[01])$", ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorNotCorrent")]
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
}
