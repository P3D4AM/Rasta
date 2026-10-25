using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

public class CrmLinkAccTarazSettingDetails_LangMetadata
{
	[Key]
	public int CrmLinkAccTarazSettingDetailLangID { get; set; }

	public int LinkAccTarazSettingDetailId { get; set; }

	public int LanguageID { get; set; }

	public string Description { get; set; }
}
