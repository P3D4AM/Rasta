using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(CrmLinkAccSetting_LangMetadata))]
public class CrmLinkAccSetting_Lang
{
	public int CrmLinkAccSettingLangID { get; set; }

	public int LinkAccSettingId { get; set; }

	public int LanguageID { get; set; }

	public string PartDescription { get; set; }

	public string PartLabelTitle { get; set; }

	public string Description { get; set; }

	public string PreUsedHint { get; set; }

	public virtual CrmLinkAccSetting CrmLinkAccSetting { get; set; }

	public virtual Languages Languages { get; set; }
}
