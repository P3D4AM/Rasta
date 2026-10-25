using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(CrmLinkAccHolooSetting_LangMetadata))]
public class CrmLinkAccHolooSetting_Lang
{
	public int CrmLinkAccHolooSettingLangID { get; set; }

	public int LinkAccHolooSettingId { get; set; }

	public int LanguageID { get; set; }

	public string PartDescription { get; set; }

	public string PartLabelTitle { get; set; }

	public string Description { get; set; }

	public virtual CrmLinkAccHolooSetting CrmLinkAccHolooSetting { get; set; }

	public virtual Languages Languages { get; set; }
}
