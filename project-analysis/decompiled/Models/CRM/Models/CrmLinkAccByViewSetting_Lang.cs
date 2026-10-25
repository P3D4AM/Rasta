using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(CrmLinkAccByViewSetting_LangMetadata))]
public class CrmLinkAccByViewSetting_Lang
{
	public int CrmLinkAccByViewSettingLangID { get; set; }

	public int LinkAccByViewSettingId { get; set; }

	public int LanguageID { get; set; }

	public string PartDescription { get; set; }

	public string PartLabelTitle { get; set; }

	public string Description { get; set; }

	public virtual CrmLinkAccByViewSetting CrmLinkAccByViewSetting { get; set; }

	public virtual Languages Languages { get; set; }
}
