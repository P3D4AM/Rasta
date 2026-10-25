using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(CrmLinkAccNoAvSettingDetails_LangMetadata))]
public class CrmLinkAccNoAvSettingDetails_Lang
{
	public int CrmLinkAccNoAvSettingDetailLangID { get; set; }

	public int LinkAccNoAvSettingDetailId { get; set; }

	public int LanguageID { get; set; }

	public string Description { get; set; }

	public virtual CrmLinkAccNoAvSettingDetails CrmLinkAccNoAvSettingDetails { get; set; }

	public virtual Languages Languages { get; set; }
}
