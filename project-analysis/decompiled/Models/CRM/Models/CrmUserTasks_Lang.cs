using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(CrmUserTasks_LangMetadata))]
public class CrmUserTasks_Lang
{
	public int CrmUserTasksLangID { get; set; }

	public int UserTaskId { get; set; }

	public int LanguageID { get; set; }

	public string UserTaskTitle { get; set; }

	public string UserTaskDescription { get; set; }

	public virtual CrmUserTasks CrmUserTasks { get; set; }

	public virtual Languages Languages { get; set; }
}
