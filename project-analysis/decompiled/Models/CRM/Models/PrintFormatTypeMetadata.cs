using System;

namespace CRM.Models;

public class PrintFormatTypeMetadata
{
	public int PrintFormatTypeID { get; set; }

	public string PrintFormatType1 { get; set; }

	public string Description { get; set; }

	public int UserId { get; set; }

	public short Month1 { get; set; }

	public DateTime RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	public Guid? GUId { get; set; }

	public string AppType { get; set; }
}
