using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

public class CrmLinkAccShomaranSetting_LangMetadata
{
	[Key]
	public int CrmLinkAccShomaranSettingLangID { get; set; }

	public int LinkAccShomaranSettingId { get; set; }

	public int LanguageID { get; set; }

	public string PartDescription { get; set; }

	public string PartLabelTitle { get; set; }

	public string Description { get; set; }
}
