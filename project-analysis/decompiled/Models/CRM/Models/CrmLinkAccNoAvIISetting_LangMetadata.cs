using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

public class CrmLinkAccNoAvIISetting_LangMetadata
{
	[Key]
	public int CrmLinkAccNoAvIISettingLangID { get; set; }

	public int LinkAccNoAvIISettingId { get; set; }

	public int LanguageID { get; set; }

	public string PartDescription { get; set; }

	public string PartLabelTitle { get; set; }

	public string Description { get; set; }
}
