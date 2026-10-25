using System;

namespace CRM.Models;

public class CandooGetMessageInfoResponseViewModel
{
	public long? messageId { get; set; }

	public string serviceNumber { get; set; }

	public string mobileNumber { get; set; }

	public string message { get; set; }

	public DateTime? receivedDate { get; set; }
}
