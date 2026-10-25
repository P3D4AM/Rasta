using System;

namespace CRM.Models;

public class CrmInternalMessageSelectReceiverMetadata
{
	public int crmUserId { get; set; }

	public bool? Selector { get; set; }

	public int UserId { get; set; }

	public string Val { get; set; }

	public Guid? GUId { get; set; }

	public string AppType { get; set; }
}
