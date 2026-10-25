using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(CrmLinkAccSettingDetails_LangMetadata))]
public class CrmLinkAccSettingDetails_Lang
{
	public int CrmLinkAccSettingDetailLangID { get; set; }

	public int LinkAccSettingDetailId { get; set; }

	public int LanguageID { get; set; }

	public string Description { get; set; }

	public virtual CrmLinkAccSettingDetails CrmLinkAccSettingDetails { get; set; }

	public virtual Languages Languages { get; set; }
}
