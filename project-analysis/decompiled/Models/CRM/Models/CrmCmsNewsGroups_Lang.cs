using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(CrmCmsNewsGroups_LangMetadata))]
public class CrmCmsNewsGroups_Lang
{
	public int CrmCmsNewsGroupLangID { get; set; }

	public int NewsGroupId { get; set; }

	public int LanguageID { get; set; }

	public string GroupName { get; set; }

	public virtual CrmCmsNewsGroups CrmCmsNewsGroups { get; set; }

	public virtual Languages Languages { get; set; }
}
