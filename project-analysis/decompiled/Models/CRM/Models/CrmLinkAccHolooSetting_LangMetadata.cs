using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

public class CrmLinkAccHolooSetting_LangMetadata
{
	[Key]
	public int CrmLinkAccHolooSettingLangID { get; set; }

	public int LinkAccHolooSettingId { get; set; }

	public int LanguageID { get; set; }

	public string PartDescription { get; set; }

	public string PartLabelTitle { get; set; }

	public string Description { get; set; }
}
