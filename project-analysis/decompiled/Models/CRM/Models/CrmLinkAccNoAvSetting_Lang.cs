using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(CrmLinkAccNoAvSetting_LangMetadata))]
public class CrmLinkAccNoAvSetting_Lang
{
	public int CrmLinkAccNoAvSettingLangID { get; set; }

	public int LinkAccNoAvSettingId { get; set; }

	public int LanguageID { get; set; }

	public string PartDescription { get; set; }

	public string PartLabelTitle { get; set; }

	public string Description { get; set; }

	public virtual CrmLinkAccNoAvSetting CrmLinkAccNoAvSetting { get; set; }

	public virtual Languages Languages { get; set; }
}
