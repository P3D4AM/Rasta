using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

public class CrmLinkAccShygunIISetting_LangMetadata
{
	[Key]
	public int CrmLinkAccShygunIISettingLangID { get; set; }

	public int LinkAccShygunIISettingId { get; set; }

	public int LanguageID { get; set; }

	public string PartDescription { get; set; }

	public string PartLabelTitle { get; set; }

	public string Description { get; set; }
}
