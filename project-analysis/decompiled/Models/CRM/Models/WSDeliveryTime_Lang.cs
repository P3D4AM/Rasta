using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(WSDeliveryTime_LangMetadata))]
public class WSDeliveryTime_Lang
{
	public int WSDeliveryTimeLangID { get; set; }

	public int DeliveryTimeID { get; set; }

	public int LanguageID { get; set; }

	public string DeliveryTime { get; set; }

	public virtual Languages Languages { get; set; }

	public virtual WSDeliveryTime WSDeliveryTime { get; set; }
}
