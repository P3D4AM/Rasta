using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(City_LangMetadata))]
public class City_Lang
{
	public int CityLangID { get; set; }

	public int CityID { get; set; }

	public int LanguageID { get; set; }

	public string City { get; set; }

	public string Description { get; set; }

	public virtual City City1 { get; set; }

	public virtual Languages Languages { get; set; }
}
