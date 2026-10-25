using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(CrmDyFormFieldTypes_LangMetadata))]
public class CrmDyFormFieldTypes_Lang
{
	public int CrmDyFormFieldTypeLangID { get; set; }

	public int FieldTypeId { get; set; }

	public string TypeName { get; set; }

	public int LanguageID { get; set; }

	public virtual CrmDyFormFieldTypes CrmDyFormFieldTypes { get; set; }

	public virtual Languages Languages { get; set; }
}
