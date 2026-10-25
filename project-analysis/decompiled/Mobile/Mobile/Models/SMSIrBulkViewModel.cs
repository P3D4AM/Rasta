using System;

namespace Mobile.Models;

public class SMSIrBulkViewModel
{
	public string messageText { get; set; }

	public string[] mobiles { get; set; }

	public long lineNumber { get; set; }

	public DateTime? senddatetime { get; set; }
}
