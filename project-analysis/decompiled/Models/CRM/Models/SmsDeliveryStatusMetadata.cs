using System;

namespace CRM.Models;

public class SmsDeliveryStatusMetadata
{
	public int ID { get; set; }

	public int WebServiceID { get; set; }

	public string DeliveryStatus { get; set; }

	public bool IsFinal { get; set; }

	public Guid? GUId { get; set; }

	public string AppType { get; set; }
}
