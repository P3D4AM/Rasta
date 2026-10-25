using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(Education_LangMetadata))]
public class Education_Lang
{
	public int EducationLangID { get; set; }

	public int EducationID { get; set; }

	public int LanguageID { get; set; }

	public string Education { get; set; }

	public virtual Education Education1 { get; set; }

	public virtual Languages Languages { get; set; }
}
