using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(Country_LangMetadata))]
public class Country_Lang
{
	public int CountryLangID { get; set; }

	public int CountryID { get; set; }

	public int LanguageID { get; set; }

	public string Country { get; set; }

	public string CountryDescription { get; set; }

	public virtual Country Country1 { get; set; }

	public virtual Languages Languages { get; set; }
}
