using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(CrmsysDBObjects_LangMetadata))]
public class CrmsysDBObjects_Lang
{
	public int CrmsysDBObjectsLangID { get; set; }

	public int DBObjectId { get; set; }

	public int LanguageID { get; set; }

	public string FieldTitle { get; set; }

	public string FieldRegEx { get; set; }

	public string FieldTitleCustom { get; set; }

	public string FieldDescription { get; set; }

	public virtual CrmsysDBObjects CrmsysDBObjects { get; set; }

	public virtual Languages Languages { get; set; }
}
