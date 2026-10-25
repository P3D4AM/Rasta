using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

public class CrmLinkAccChamberCommerceSetting_LangMetadata
{
	[Key]
	public int CrmLinkAccChamberCommerceSettingLangID { get; set; }

	public int LinkAccChamberCommerceSettingId { get; set; }

	public int LanguageID { get; set; }

	public string PartDescription { get; set; }

	public string PartLabelTitle { get; set; }

	public string Description { get; set; }
}
