using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(CrmProjectCategory_LangMetadata))]
public class CrmProjectCategory_Lang
{
	public int CrmProjectCategoryLangID { get; set; }

	public int ProjectCategoryId { get; set; }

	public int LanguageID { get; set; }

	public string CategoryName { get; set; }

	public virtual CrmProjectCategory CrmProjectCategory { get; set; }

	public virtual Languages Languages { get; set; }
}
