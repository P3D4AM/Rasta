using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(CrmDyFormFieldValues_LangMetadata))]
public class CrmDyFormFieldValues_Lang
{
	public int CrmDyFormFieldValueLangID { get; set; }

	public int FieldValueId { get; set; }

	public string Value { get; set; }

	public int LanguageID { get; set; }

	public virtual CrmDyFormFieldValues CrmDyFormFieldValues { get; set; }

	public virtual Languages Languages { get; set; }
}
