using System.ComponentModel.DataAnnotations;
using CRM.Resources;

namespace CRM.Models;

public class CrmUserTasksViewModel
{
	[Key]
	public int UserTaskId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "UserTaskDate")]
	public string UserTaskDatePersian { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "UserTaskTime")]
	public string UserTaskTime { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "UserTaskTitle")]
	public string UserTaskTitle { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "UserTaskDescription")]
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

	public string TaskPriorityColor { get; set; }
}
