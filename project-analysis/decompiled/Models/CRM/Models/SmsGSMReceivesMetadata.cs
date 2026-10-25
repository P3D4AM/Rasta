using System;

namespace CRM.Models;

public class SmsGSMReceivesMetadata
{
	public int Id { get; set; }

	public int? Folder { get; set; }

	public int? Location { get; set; }

	public string ReceiveNumber { get; set; }

	public string ReceiveText { get; set; }

	public DateTime ReceiveTime { get; set; }

	public string ConcatenatedInfo { get; set; }

	public int? Coding { get; set; }

	public int? Status { get; set; }

	public Guid? GUId { get; set; }

	public string AppType { get; set; }
}
