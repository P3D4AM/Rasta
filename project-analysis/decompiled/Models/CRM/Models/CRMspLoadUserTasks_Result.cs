using System;

namespace CRM.Models;

public class CRMspLoadUserTasks_Result
{
	public string UserTaskTime { get; set; }

	public int UserTaskId { get; set; }

	public string UserTaskDatePersian { get; set; }

	public string UserTaskTitle { get; set; }

	public string UserTaskDescription { get; set; }

	public int? UserTaskPriorityId { get; set; }

	public int? UserTaskGroupId { get; set; }

	public int? UserTaskShowAllarm { get; set; }

	public bool? UserTaskDidIt { get; set; }

	public string TaskPriorityColor { get; set; }

	public int UserID { get; set; }

	public DateTime UserTaskDate { get; set; }
}
