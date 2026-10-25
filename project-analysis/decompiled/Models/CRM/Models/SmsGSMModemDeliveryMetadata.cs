using System;

namespace CRM.Models;

public class SmsGSMModemDeliveryMetadata
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
}
