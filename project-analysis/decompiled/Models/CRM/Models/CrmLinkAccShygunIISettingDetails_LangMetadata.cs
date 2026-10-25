using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

public class CrmLinkAccShygunIISettingDetails_LangMetadata
{
	[Key]
	public int CrmLinkAccShygunIISettingDetailLangID { get; set; }

	public int LinkAccShygunIISettingDetailId { get; set; }

	public int LanguageID { get; set; }

	public string Description { get; set; }
}
