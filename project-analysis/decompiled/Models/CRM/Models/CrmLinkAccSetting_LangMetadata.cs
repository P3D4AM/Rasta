using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

public class CrmLinkAccSetting_LangMetadata
{
	[Key]
	public int CrmLinkAccSettingLangID { get; set; }

	public int LinkAccSettingId { get; set; }

	public int LanguageID { get; set; }

	public string PartDescription { get; set; }

	public string PartLabelTitle { get; set; }

	public string Description { get; set; }
}
