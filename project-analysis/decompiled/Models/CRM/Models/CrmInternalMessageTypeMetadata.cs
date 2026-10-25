using System;

namespace CRM.Models;

public class CrmInternalMessageTypeMetadata
{
	public int InternalMessageTypeID { get; set; }

	public string MessageType { get; set; }

	public Guid? GUId { get; set; }

	public string AppType { get; set; }
}
