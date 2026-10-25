using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(SmsDeliveryStatus_LangMetadata))]
public class SmsDeliveryStatus_Lang
{
	public int SmsDeliveryStatusLangID { get; set; }

	public int ID { get; set; }

	public int LanguageID { get; set; }

	public string DeliveryStatus { get; set; }

	public virtual Languages Languages { get; set; }

	public virtual SmsDeliveryStatus SmsDeliveryStatus { get; set; }
}
