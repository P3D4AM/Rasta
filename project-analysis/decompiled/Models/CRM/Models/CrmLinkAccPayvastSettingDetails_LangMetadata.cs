using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

public class CrmLinkAccPayvastSettingDetails_LangMetadata
{
	[Key]
	public int CrmLinkAccPayvastSettingDetailLangID { get; set; }

	public int LinkAccPayvastSettingDetailId { get; set; }

	public int LanguageID { get; set; }

	public string Description { get; set; }
}
