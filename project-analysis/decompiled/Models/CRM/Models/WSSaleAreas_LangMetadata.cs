using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

public class WSSaleAreas_LangMetadata
{
	[Key]
	public int WSSaleAreaLangID { get; set; }

	public int SaleAreaId { get; set; }

	public int LanguageID { get; set; }

	public string SaleAreaName { get; set; }
}
