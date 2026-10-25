using System;

namespace CRM.Models;

public class SmsGSMSendingTankMetadata
{
	public int ID { get; set; }

	public string Number { get; set; }

	public string Body { get; set; }

	public bool? Sended { get; set; }

	public long? RefId { get; set; }

	public string Info { get; set; }

	public int? SendDetailId { get; set; }

	public int? SendUserId { get; set; }

	public string RequestTime { get; set; }

	public string RequestDate { get; set; }

	public Guid? GUId { get; set; }

	public string AppType { get; set; }
}
