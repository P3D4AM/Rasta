using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(CrmProjectGroupsMulti_LangMetadata))]
public class CrmProjectGroupsMulti_Lang
{
	public int ProjectGroupsMultiLangID { get; set; }

	public int ProjectGroupsMultiId { get; set; }

	public int LanguageID { get; set; }

	public string ProjectGroupsMultiName { get; set; }

	public string ProjectGroupsMultiDesc { get; set; }

	public virtual CrmProjectGroupsMulti CrmProjectGroupsMulti { get; set; }

	public virtual Languages Languages { get; set; }
}
