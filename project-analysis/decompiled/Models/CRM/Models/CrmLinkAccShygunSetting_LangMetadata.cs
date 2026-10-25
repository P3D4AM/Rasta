using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

public class CrmLinkAccShygunSetting_LangMetadata
{
	[Key]
	public int CrmLinkAccShygunSettingLangID { get; set; }

	public int LinkAccShygunSettingId { get; set; }

	public int LanguageID { get; set; }

	public string PartDescription { get; set; }

	public string PartLabelTitle { get; set; }

	public string Description { get; set; }
}
