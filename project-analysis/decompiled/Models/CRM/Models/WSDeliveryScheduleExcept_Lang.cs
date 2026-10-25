using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(WSDeliveryScheduleExcept_LangMetadata))]
public class WSDeliveryScheduleExcept_Lang
{
	public int WSDeliveryScheduleExceptLangID { get; set; }

	public int DeliveryScheduleExceptId { get; set; }

	public int LanguageID { get; set; }

	public string ExDesc { get; set; }

	public string ExTitle { get; set; }

	public virtual Languages Languages { get; set; }

	public virtual WSDeliveryScheduleExcept WSDeliveryScheduleExcept { get; set; }
}
