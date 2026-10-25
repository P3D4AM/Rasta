using System;

namespace CRM.Models;

public class CrmCallTypeMetadata
{
	public int CallTypeID { get; set; }

	public string CallType { get; set; }

	public Guid? GUId { get; set; }

	public string AppType { get; set; }
}
