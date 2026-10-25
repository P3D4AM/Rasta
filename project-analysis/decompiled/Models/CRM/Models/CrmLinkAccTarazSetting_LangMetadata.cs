using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

public class CrmLinkAccTarazSetting_LangMetadata
{
	[Key]
	public int CrmLinkAccTarazSettingLangID { get; set; }

	public int LinkAccTarazSettingId { get; set; }

	public int LanguageID { get; set; }

	public string PartDescription { get; set; }

	public string PartLabelTitle { get; set; }

	public string Description { get; set; }
}
