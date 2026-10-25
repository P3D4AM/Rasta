using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(CrmLinkAccShygunSetting_LangMetadata))]
public class CrmLinkAccShygunSetting_Lang
{
	public int CrmLinkAccShygunSettingLangID { get; set; }

	public int LinkAccShygunSettingId { get; set; }

	public int LanguageID { get; set; }

	public string PartDescription { get; set; }

	public string PartLabelTitle { get; set; }

	public string Description { get; set; }

	public virtual CrmLinkAccShygunSetting CrmLinkAccShygunSetting { get; set; }

	public virtual Languages Languages { get; set; }
}
