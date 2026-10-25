using System;

namespace Mobile.Models;

public class FoPrintLogViewModel
{
	public int PrintLogId { get; set; }

	public int PrintFormatTypeId { get; set; }

	public string PrintFormatType { get; set; }

	public int ObjectId { get; set; }

	public DateTime? LogDateTime { get; set; }

	public string LogDate { get; set; }

	public int? LogUserId { get; set; }

	public string LogUser { get; set; }

	public int? LogCmpId { get; set; }

	public string LogCmp { get; set; }

	public string AppType { get; set; }

	public string PrintLogType { get; set; }

	public string PrintLogTypeTitle { get; set; }

	public long? RowNumber { get; set; }
}
