using System;

namespace CRM.Models;

public class CRMspSelectUserTasks_Result
{
	public int UserTaskId { get; set; }

	public string UserTaskDatePersian { get; set; }

	public DateTime UserTaskDate { get; set; }

	public string UserTaskTime { get; set; }

	public string UserTaskTitle { get; set; }

	public string UserTaskDescription { get; set; }

	public int? UserTaskPriorityId { get; set; }

	public int? UserTaskGroupId { get; set; }

	public int? UserTaskShowAllarm { get; set; }

	public bool? UserTaskDidIt { get; set; }

	public int UserId { get; set; }

	public short Year1 { get; set; }

	public short Month1 { get; set; }

	public DateTime RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	public string UserTaskRemindDate { get; set; }

	public string UserTaskRemindTime { get; set; }

	public DateTime? UserTaskRemindDateTime { get; set; }

	public bool? UserTaskIsPublic { get; set; }

	public Guid? GUId { get; set; }

	public string AppType { get; set; }

	public int? LanguageID { get; set; }

	public int? FirstRegisterUserId { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public DateTime? FirstRegisterDate { get; set; }
}
