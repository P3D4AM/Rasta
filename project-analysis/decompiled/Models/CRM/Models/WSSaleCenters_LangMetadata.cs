using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

public class WSSaleCenters_LangMetadata
{
	[Key]
	public int WSSaleCenterLangID { get; set; }

	public int SaleCenterId { get; set; }

	public int LanguageID { get; set; }

	public string SaleCenterName { get; set; }
}
