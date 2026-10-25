using System;

namespace CRM.Models;

public class CrmLeaveStatusMetadata
{
	public int LeaveStatusID { get; set; }

	public string LeaveStatus { get; set; }

	public Guid? GUId { get; set; }

	public string AppType { get; set; }
}
