using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(CrmLinkAccPayvastSetting_LangMetadata))]
public class CrmLinkAccPayvastSetting_Lang
{
	public int CrmLinkAccPayvastSettingLangID { get; set; }

	public int LinkAccPayvastSettingId { get; set; }

	public int LanguageID { get; set; }

	public string PartDescription { get; set; }

	public string PartLabelTitle { get; set; }

	public string Description { get; set; }

	public virtual CrmLinkAccPayvastSetting CrmLinkAccPayvastSetting { get; set; }

	public virtual Languages Languages { get; set; }
}
