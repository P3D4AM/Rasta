using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

public class CrmLinkAccHamrahanSettingDetails_LangMetadata
{
	[Key]
	public int CrmLinkAccHamrahanSettingDetailLangID { get; set; }

	public int LinkAccHamrahanSettingDetailId { get; set; }

	public int LanguageID { get; set; }

	public string Description { get; set; }
}
