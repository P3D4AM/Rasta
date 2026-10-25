using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(CrmLinkAccTarazSetting_LangMetadata))]
public class CrmLinkAccTarazSetting_Lang
{
	public int CrmLinkAccTarazSettingLangID { get; set; }

	public int LinkAccTarazSettingId { get; set; }

	public int LanguageID { get; set; }

	public string PartDescription { get; set; }

	public string PartLabelTitle { get; set; }

	public string Description { get; set; }

	public virtual CrmLinkAccTarazSetting CrmLinkAccTarazSetting { get; set; }

	public virtual Languages Languages { get; set; }
}
