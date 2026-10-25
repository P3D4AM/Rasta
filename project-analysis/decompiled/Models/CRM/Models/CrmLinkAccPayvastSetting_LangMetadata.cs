using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

public class CrmLinkAccPayvastSetting_LangMetadata
{
	[Key]
	public int CrmLinkAccPayvastSettingLangID { get; set; }

	public int LinkAccPayvastSettingId { get; set; }

	public int LanguageID { get; set; }

	public string PartDescription { get; set; }

	public string PartLabelTitle { get; set; }

	public string Description { get; set; }
}
