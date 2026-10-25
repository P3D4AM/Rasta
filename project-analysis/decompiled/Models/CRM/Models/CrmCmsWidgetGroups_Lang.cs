using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(CrmCmsWidgetGroups_LangMetadata))]
public class CrmCmsWidgetGroups_Lang
{
	public int CrmCmsWidgetGroupLangID { get; set; }

	public int WidgetGroupId { get; set; }

	public int LanguageID { get; set; }

	public string WidgetGroupTitle { get; set; }

	public virtual CrmCmsWidgetGroups CrmCmsWidgetGroups { get; set; }

	public virtual Languages Languages { get; set; }
}
