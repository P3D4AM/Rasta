using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(CrmLinkAccHolooSettingDetails_LangMetadata))]
public class CrmLinkAccHolooSettingDetails_Lang
{
	public int CrmLinkAccHolooSettingDetailLangID { get; set; }

	public int LinkAccHolooSettingDetailId { get; set; }

	public int LanguageID { get; set; }

	public string Description { get; set; }

	public virtual CrmLinkAccHolooSettingDetails CrmLinkAccHolooSettingDetails { get; set; }

	public virtual Languages Languages { get; set; }
}
