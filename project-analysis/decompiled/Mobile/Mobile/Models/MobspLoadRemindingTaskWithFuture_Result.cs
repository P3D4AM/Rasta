using System;

namespace Mobile.Models;

public class MobspLoadRemindingTaskWithFuture_Result
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

	public int UserId { get; set; }

	public int Val1 { get; set; }

	public int Val2 { get; set; }

	public int Val3 { get; set; }
}
