using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

public class CrmCmsNewsGroups_LangMetadata
{
	[Key]
	public int CrmCmsNewsGroupLangID { get; set; }

	public int NewsGroupId { get; set; }

	public int LanguageID { get; set; }

	public string GroupName { get; set; }
}
