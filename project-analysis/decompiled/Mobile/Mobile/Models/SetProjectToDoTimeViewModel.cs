namespace Mobile.Models;

public class SetProjectToDoTimeViewModel
{
	public int ProjectId { get; set; }

	public int ConversationId { get; set; }

	public int? ToDoYear { get; set; }

	public int? ToDoMonth { get; set; }

	public int? ToDoDay { get; set; }

	public int? ToDoHour { get; set; }

	public int? ToDoMinute { get; set; }

	public int CnvsReferUserId { get; set; }

	public int? CnvsPriorityId { get; set; }

	public string CnvsReferUserDesc { get; set; }

	public bool? IsUpdate { get; set; }

	public int? LanguageId { get; set; }

	public int? CenterId { get; set; }
}
