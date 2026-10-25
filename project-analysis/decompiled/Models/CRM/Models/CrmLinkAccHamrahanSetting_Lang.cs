using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(CrmLinkAccHamrahanSetting_LangMetadata))]
public class CrmLinkAccHamrahanSetting_Lang
{
	public int CrmLinkAccHamrahanSettingLangID { get; set; }

	public int LinkAccHamrahanSettingId { get; set; }

	public int LanguageID { get; set; }

	public string PartDescription { get; set; }

	public string PartLabelTitle { get; set; }

	public string Description { get; set; }

	public virtual CrmLinkAccHamrahanSetting CrmLinkAccHamrahanSetting { get; set; }

	public virtual Languages Languages { get; set; }
}
