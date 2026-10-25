namespace CRM.Models;

public class LocalStorageViewModel
{
	public string typeReminder { get; set; }

	public int ConversationID { get; set; }

	public int cnvsCompanyId { get; set; }

	public int? cnvsPersonId { get; set; }

	public int? cnvsProjectId { get; set; }

	public string cnvsRemindDate { get; set; }

	public string cnvsRemindTime { get; set; }

	public string UserTaskTime { get; set; }

	public int UserTaskId { get; set; }

	public string UserTaskDatePersian { get; set; }

	public string UserTaskTitle { get; set; }

	public string UserTaskDescription { get; set; }

	public int? UserTaskPriorityId { get; set; }

	public int? UserTaskGroupId { get; set; }

	public int? UserTaskShowAllarm { get; set; }

	public bool? UserTaskDidIt { get; set; }

	public string UserTaskRemindTime { get; set; }

	public string UserTaskRemindDate { get; set; }

	public string TaskPriorityColor { get; set; }

	public int UserID { get; set; }
}
