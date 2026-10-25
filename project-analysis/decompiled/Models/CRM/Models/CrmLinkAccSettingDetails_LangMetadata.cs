using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

public class CrmLinkAccSettingDetails_LangMetadata
{
	[Key]
	public int CrmLinkAccSettingDetailLangID { get; set; }

	public int LinkAccSettingDetailId { get; set; }

	public int LanguageID { get; set; }

	public string Description { get; set; }
}
