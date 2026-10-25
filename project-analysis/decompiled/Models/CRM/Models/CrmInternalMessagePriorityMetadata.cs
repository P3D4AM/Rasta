using System;

namespace CRM.Models;

public class CrmInternalMessagePriorityMetadata
{
	public int InternalMessagePriorityID { get; set; }

	public string InternalMessagePriority { get; set; }

	public int? UserId { get; set; }

	public short? Year1 { get; set; }

	public short? Month1 { get; set; }

	public DateTime? RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	public string AppType { get; set; }

	public Guid? GUId { get; set; }
}
