using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

public class CrmLinkAccShygunSettingDetails_LangMetadata
{
	[Key]
	public int CrmLinkAccShygunSettingDetailLangID { get; set; }

	public int LinkAccShygunSettingDetailId { get; set; }

	public int LanguageID { get; set; }

	public string Description { get; set; }
}
