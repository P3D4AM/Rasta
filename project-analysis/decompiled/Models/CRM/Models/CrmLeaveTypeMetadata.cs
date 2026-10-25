using System;

namespace CRM.Models;

public class CrmLeaveTypeMetadata
{
	public int LeaveTypeID { get; set; }

	public string LeaveType { get; set; }

	public Guid? GUId { get; set; }

	public string AppType { get; set; }
}
