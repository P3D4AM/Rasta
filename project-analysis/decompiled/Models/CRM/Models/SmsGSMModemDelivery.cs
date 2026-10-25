using System;
using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(SmsGSMModemDeliveryMetadata))]
public class SmsGSMModemDelivery
{
	public int Id { get; set; }

	public int? SendReference { get; set; }

	public string Number { get; set; }

	public string DTime { get; set; }

	public string DeliveryFaDateTime { get; set; }

	public int? StatusId { get; set; }

	public int? DStatus { get; set; }

	public int? Folder { get; set; }

	public int? Location { get; set; }

	public string RegisterDatePersian { get; set; }

	public Guid? GUId { get; set; }

	public string AppType { get; set; }

	public int? LanguageID { get; set; }

	public int? FirstRegisterUserId { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public DateTime? FirstRegisterDate { get; set; }

	public virtual Languages Languages { get; set; }

	public virtual Users Users { get; set; }
}
