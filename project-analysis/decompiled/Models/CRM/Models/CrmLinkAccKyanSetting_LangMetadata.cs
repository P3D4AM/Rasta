using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

public class CrmLinkAccKyanSetting_LangMetadata
{
	[Key]
	public int CrmLinkAccKyanSettingLangID { get; set; }

	public int LinkAccKyanSettingId { get; set; }

	public int LanguageID { get; set; }

	public string PartDescription { get; set; }

	public string PartLabelTitle { get; set; }

	public string Description { get; set; }
}
