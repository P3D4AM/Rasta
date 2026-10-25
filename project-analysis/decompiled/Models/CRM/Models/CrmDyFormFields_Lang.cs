using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(CrmDyFormFields_LangMetadata))]
public class CrmDyFormFields_Lang
{
	public int CrmDyFormFieldLangID { get; set; }

	public int FieldId { get; set; }

	public string FieldTitle { get; set; }

	public string RegularExpressionErrorTxt { get; set; }

	public string PlaceholderTxt { get; set; }

	public string MultiItems { get; set; }

	public string DefaultValue { get; set; }

	public int LanguageID { get; set; }

	public virtual CrmDyFormFields CrmDyFormFields { get; set; }

	public virtual Languages Languages { get; set; }
}
