using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

public class CrmLinkAccByViewSetting_LangMetadata
{
	[Key]
	public int CrmLinkAccByViewSettingLangID { get; set; }

	public int LinkAccByViewSettingId { get; set; }

	public int LanguageID { get; set; }

	public string PartDescription { get; set; }

	public string PartLabelTitle { get; set; }

	public string Description { get; set; }
}
