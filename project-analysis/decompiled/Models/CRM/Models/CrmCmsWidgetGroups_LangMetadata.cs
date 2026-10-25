using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

public class CrmCmsWidgetGroups_LangMetadata
{
	[Key]
	public int CrmCmsWidgetGroupLangID { get; set; }

	public int WidgetGroupId { get; set; }

	public int LanguageID { get; set; }

	public string WidgetGroupTitle { get; set; }
}
