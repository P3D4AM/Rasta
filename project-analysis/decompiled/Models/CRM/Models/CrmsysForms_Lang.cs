using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(CrmsysForms_LangMetadata))]
public class CrmsysForms_Lang
{
	public int CrmsysFormsLangID { get; set; }

	public int ID { get; set; }

	public int LanguageID { get; set; }

	public string FormPersianName { get; set; }

	public virtual CrmsysForms CrmsysForms { get; set; }

	public virtual Languages Languages { get; set; }
}
