using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

public class CrmLinkAccNoAvSetting_LangMetadata
{
	[Key]
	public int CrmLinkAccNoAvSettingLangID { get; set; }

	public int LinkAccNoAvSettingId { get; set; }

	public int LanguageID { get; set; }

	public string PartDescription { get; set; }

	public string PartLabelTitle { get; set; }

	public string Description { get; set; }
}
