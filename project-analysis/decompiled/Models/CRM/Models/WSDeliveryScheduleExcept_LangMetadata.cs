using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

public class WSDeliveryScheduleExcept_LangMetadata
{
	[Key]
	public int WSDeliveryScheduleExceptLangID { get; set; }

	public int DeliveryScheduleExceptId { get; set; }

	public int LanguageID { get; set; }

	public string ExDesc { get; set; }
}
