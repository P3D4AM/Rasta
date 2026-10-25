using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

public class CrmLinkAccArpaSetting_LangMetadata
{
	[Key]
	public int CrmLinkAccArpaSettingLangID { get; set; }

	public int LinkAccArpaSettingId { get; set; }

	public int LanguageID { get; set; }

	public string PartDescription { get; set; }

	public string PartLabelTitle { get; set; }

	public string Description { get; set; }
}
