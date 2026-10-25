using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(Province_LangMetadata))]
public class Province_Lang
{
	public int ProvinceLangID { get; set; }

	public int LanguageID { get; set; }

	public int ProvinceID { get; set; }

	public string Province { get; set; }

	public string Description { get; set; }

	public virtual Languages Languages { get; set; }

	public virtual Province Province1 { get; set; }
}
