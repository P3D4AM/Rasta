using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(CrmProjectGroupsMultiI_LangMetadata))]
public class CrmProjectGroupsMultiI_Lang
{
	public int ProjectGroupsMultiILangID { get; set; }

	public int ProjectGroupsMultiIId { get; set; }

	public int LanguageID { get; set; }

	public string ProjectGroupsMultiIName { get; set; }

	public string ProjectGroupsMultiIDesc { get; set; }

	public virtual CrmProjectGroupsMultiI CrmProjectGroupsMultiI { get; set; }

	public virtual Languages Languages { get; set; }
}
