using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(WSSaleCenters_LangMetadata))]
public class WSSaleCenters_Lang
{
	public int WSSaleCenterLangID { get; set; }

	public int SaleCenterId { get; set; }

	public int LanguageID { get; set; }

	public string SaleCenterName { get; set; }

	public string SaleCenterTitle { get; set; }

	public virtual Languages Languages { get; set; }

	public virtual WSSaleCenters WSSaleCenters { get; set; }
}
