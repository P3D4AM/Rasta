using System;

namespace Mobile.Models;

public class MobspLoadRemindingTask_Result
{
	public int Type { get; set; }

	public int UserTaskId { get; set; }

	public string UserTaskTitle { get; set; }

	public string UserTaskTime { get; set; }

	public string UserTaskDatePersian { get; set; }

	public DateTime? UserTaskDate { get; set; }

	public string UserTaskRemindTime { get; set; }

	public string UserTaskRemindDate { get; set; }

	public DateTime? UserTaskRemindDateTime { get; set; }

	public int? cnvsReferUserId { get; set; }

	public int? cnvsCompanyId { get; set; }

	public int? cnvsPersonId { get; set; }

	public int? cnvsProjectId { get; set; }

	public bool? IsRecurringTask { get; set; }
}
