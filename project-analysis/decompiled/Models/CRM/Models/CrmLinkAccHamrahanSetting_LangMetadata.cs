using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

public class CrmLinkAccHamrahanSetting_LangMetadata
{
	[Key]
	public int CrmLinkAccHamrahanSettingLangID { get; set; }

	public int LinkAccHamrahanSettingId { get; set; }

	public int LanguageID { get; set; }

	public string PartDescription { get; set; }

	public string PartLabelTitle { get; set; }

	public string Description { get; set; }
}
