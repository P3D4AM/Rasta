using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(CrmUserTaskGroups_LangMetadata))]
public class CrmUserTaskGroups_Lang
{
	public int CrmUserTaskGroupsLangID { get; set; }

	public int UserTaskGroupId { get; set; }

	public int LanguageID { get; set; }

	public string UserTaskGroup { get; set; }

	public virtual CrmUserTaskGroups CrmUserTaskGroups { get; set; }

	public virtual Languages Languages { get; set; }
}
