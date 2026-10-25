using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

public class CrmCmsWidgets_LangMetadata
{
	[Key]
	public int CrmCmsWidgetLangID { get; set; }

	public int WidgetId { get; set; }

	public int LanguageID { get; set; }

	public string WidgetTitle { get; set; }

	public string WidgetBody { get; set; }
}
