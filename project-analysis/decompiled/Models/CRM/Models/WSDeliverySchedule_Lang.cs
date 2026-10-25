using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(WSDeliverySchedule_LangMetadata))]
public class WSDeliverySchedule_Lang
{
	public int WSDeliveryScheduleLangID { get; set; }

	public int DeliveryScheduleId { get; set; }

	public int LanguageID { get; set; }

	public string Title { get; set; }

	public virtual Languages Languages { get; set; }

	public virtual WSDeliverySchedule WSDeliverySchedule { get; set; }
}
