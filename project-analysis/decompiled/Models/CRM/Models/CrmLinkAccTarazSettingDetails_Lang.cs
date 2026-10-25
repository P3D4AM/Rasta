using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(CrmLinkAccTarazSettingDetails_LangMetadata))]
public class CrmLinkAccTarazSettingDetails_Lang
{
	public int CrmLinkAccTarazSettingDetailLangID { get; set; }

	public int LinkAccTarazSettingDetailId { get; set; }

	public int LanguageID { get; set; }

	public string Description { get; set; }

	public virtual CrmLinkAccTarazSettingDetails CrmLinkAccTarazSettingDetails { get; set; }

	public virtual Languages Languages { get; set; }
}
