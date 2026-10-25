using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(WSSaleAreas_LangMetadata))]
public class WSSaleAreas_Lang
{
	public int WSSaleAreaLangID { get; set; }

	public int SaleAreaId { get; set; }

	public int LanguageID { get; set; }

	public string SaleAreaName { get; set; }

	public virtual Languages Languages { get; set; }

	public virtual WSSaleAreas WSSaleAreas { get; set; }
}
