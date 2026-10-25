using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(CrmProjectFieldTitle_LangMetadata))]
public class CrmProjectFieldTitle_Lang
{
	public int CrmProjectFieldTitleLangID { get; set; }

	public int ProjectFieldTitleId { get; set; }

	public int LanguageID { get; set; }

	public string FieldTitle { get; set; }

	public string Description { get; set; }

	public virtual CrmProjectFieldTitle CrmProjectFieldTitle { get; set; }

	public virtual Languages Languages { get; set; }
}
