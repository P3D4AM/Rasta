using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(SmsDeliveryStatusMetadata))]
public class SmsDeliveryStatus
{
	public int ID { get; set; }

	public int WebServiceID { get; set; }

	public string DeliveryStatus { get; set; }

	public bool IsFinal { get; set; }

	public Guid? GUId { get; set; }

	public string AppType { get; set; }

	public int? LanguageID { get; set; }

	public int? FirstRegisterUserId { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public DateTime? FirstRegisterDate { get; set; }

	public virtual Languages Languages { get; set; }

	public virtual ICollection<SmsDeliveryStatus_Lang> SmsDeliveryStatus_Lang { get; set; }

	public virtual Users Users { get; set; }

	public SmsDeliveryStatus()
	{
		SmsDeliveryStatus_Lang = (ICollection<SmsDeliveryStatus_Lang>)new HashSet<SmsDeliveryStatus_Lang>();
	}
}
