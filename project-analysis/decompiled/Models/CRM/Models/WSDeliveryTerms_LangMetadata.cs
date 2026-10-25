using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

public class WSDeliveryTerms_LangMetadata
{
	[Key]
	public int WSDeliveryTermLangID { get; set; }

	public int DeliveryTermId { get; set; }

	public int LanguageID { get; set; }

	public string DeliveryTerm { get; set; }
}
