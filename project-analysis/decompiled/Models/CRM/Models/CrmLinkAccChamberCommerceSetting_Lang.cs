using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(CrmLinkAccChamberCommerceSetting_LangMetadata))]
public class CrmLinkAccChamberCommerceSetting_Lang
{
	public int CrmLinkAccChamberCommerceSettingLangID { get; set; }

	public int LinkAccChamberCommerceSettingId { get; set; }

	public int LanguageID { get; set; }

	public string PartDescription { get; set; }

	public string PartLabelTitle { get; set; }

	public string Description { get; set; }

	public virtual CrmLinkAccChamberCommerceSetting CrmLinkAccChamberCommerceSetting { get; set; }

	public virtual Languages Languages { get; set; }
}
