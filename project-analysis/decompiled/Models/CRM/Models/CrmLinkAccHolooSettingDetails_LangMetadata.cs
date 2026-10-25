using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

public class CrmLinkAccHolooSettingDetails_LangMetadata
{
	[Key]
	public int CrmLinkAccHolooSettingDetailLangID { get; set; }

	public int LinkAccHolooSettingDetailId { get; set; }

	public int LanguageID { get; set; }

	public string Description { get; set; }
}
