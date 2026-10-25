using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(CrmLinkAccShygunIISettingDetails_LangMetadata))]
public class CrmLinkAccShygunIISettingDetails_Lang
{
	public int CrmLinkAccShygunIISettingDetailLangID { get; set; }

	public int LinkAccShygunIISettingDetailId { get; set; }

	public int LanguageID { get; set; }

	public string Description { get; set; }

	public virtual CrmLinkAccShygunIISettingDetails CrmLinkAccShygunIISettingDetails { get; set; }

	public virtual Languages Languages { get; set; }
}
