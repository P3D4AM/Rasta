using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(CrmLinkAccPayvastSettingDetails_LangMetadata))]
public class CrmLinkAccPayvastSettingDetails_Lang
{
	public int CrmLinkAccPayvastSettingDetailLangID { get; set; }

	public int LinkAccPayvastSettingDetailId { get; set; }

	public int LanguageID { get; set; }

	public string Description { get; set; }

	public virtual CrmLinkAccPayvastSettingDetails CrmLinkAccPayvastSettingDetails { get; set; }

	public virtual Languages Languages { get; set; }
}
