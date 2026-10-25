using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(CrmSystemParts_LangMetadata))]
public class CrmSystemParts_Lang
{
	public int CrmSystemPartLangID { get; set; }

	public int SystemPartId { get; set; }

	public string PartTitle { get; set; }

	public int LanguageID { get; set; }

	public virtual CrmSystemParts CrmSystemParts { get; set; }

	public virtual Languages Languages { get; set; }
}
