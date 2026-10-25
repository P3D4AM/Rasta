using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(CrmLinkAccShomaranSetting_LangMetadata))]
public class CrmLinkAccShomaranSetting_Lang
{
	public int CrmLinkAccShomaranSettingLangID { get; set; }

	public int LinkAccShomaranSettingId { get; set; }

	public int LanguageID { get; set; }

	public string PartDescription { get; set; }

	public string PartLabelTitle { get; set; }

	public string Description { get; set; }

	public virtual CrmLinkAccShomaranSetting CrmLinkAccShomaranSetting { get; set; }

	public virtual Languages Languages { get; set; }
}
