using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(CrmLinkAccShygunSettingDetails_LangMetadata))]
public class CrmLinkAccShygunSettingDetails_Lang
{
	public int CrmLinkAccShygunSettingDetailLangID { get; set; }

	public int LinkAccShygunSettingDetailId { get; set; }

	public int LanguageID { get; set; }

	public string Description { get; set; }

	public virtual CrmLinkAccShygunSettingDetails CrmLinkAccShygunSettingDetails { get; set; }

	public virtual Languages Languages { get; set; }
}
