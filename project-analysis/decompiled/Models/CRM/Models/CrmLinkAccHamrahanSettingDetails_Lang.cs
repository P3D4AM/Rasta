using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(CrmLinkAccHamrahanSettingDetails_LangMetadata))]
public class CrmLinkAccHamrahanSettingDetails_Lang
{
	public int CrmLinkAccHamrahanSettingDetailLangID { get; set; }

	public int LinkAccHamrahanSettingDetailId { get; set; }

	public int LanguageID { get; set; }

	public string Description { get; set; }

	public virtual CrmLinkAccHamrahanSettingDetails CrmLinkAccHamrahanSettingDetails { get; set; }

	public virtual Languages Languages { get; set; }
}
