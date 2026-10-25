using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(CrmCmsWidgets_LangMetadata))]
public class CrmCmsWidgets_Lang
{
	public int CrmCmsWidgetLangID { get; set; }

	public int WidgetId { get; set; }

	public int LanguageID { get; set; }

	public string WidgetTitle { get; set; }

	public string WidgetBody { get; set; }

	public virtual CrmCmsWidgets CrmCmsWidgets { get; set; }

	public virtual Languages Languages { get; set; }
}
