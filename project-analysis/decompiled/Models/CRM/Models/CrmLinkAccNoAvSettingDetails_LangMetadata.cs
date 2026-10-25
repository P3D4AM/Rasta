using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

public class CrmLinkAccNoAvSettingDetails_LangMetadata
{
	[Key]
	public int CrmLinkAccNoAvSettingDetailLangID { get; set; }

	public int LinkAccNoAvSettingDetailId { get; set; }

	public int LanguageID { get; set; }

	public string Description { get; set; }
}
