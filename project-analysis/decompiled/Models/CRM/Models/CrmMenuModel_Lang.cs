using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(CrmMenuModel_LangMetadata))]
public class CrmMenuModel_Lang
{
	public int MenuModelLangID { get; set; }

	public int LanguageID { get; set; }

	public int MenuModelID { get; set; }

	public string Title { get; set; }

	public virtual CrmMenuModel CrmMenuModel { get; set; }

	public virtual Languages Languages { get; set; }
}
