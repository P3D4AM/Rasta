using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

public class WSDeliverySchedule_LangMetadata
{
	[Key]
	public int WSDeliveryScheduleLangID { get; set; }

	public int DeliveryScheduleId { get; set; }

	public int LanguageID { get; set; }

	public string Title { get; set; }
}
