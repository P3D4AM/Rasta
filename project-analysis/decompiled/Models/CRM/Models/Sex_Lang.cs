using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(Sex_LangMetadata))]
public class Sex_Lang
{
	public int SexLangID { get; set; }

	public int LanguageID { get; set; }

	public int SexID { get; set; }

	public string SexType { get; set; }

	public virtual Languages Languages { get; set; }

	public virtual Sex Sex { get; set; }
}
