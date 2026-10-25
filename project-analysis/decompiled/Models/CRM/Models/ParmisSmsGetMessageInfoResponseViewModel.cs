using System;

namespace CRM.Models;

public class ParmisSmsGetMessageInfoResponseViewModel
{
	public long MsgID { get; set; }

	public string Body { get; set; }

	public DateTime? SendDate { get; set; }

	public string Sender { get; set; }

	public string Receiver { get; set; }

	public long? FirstLocation { get; set; }

	public long? CurrentLocation { get; set; }

	public long? Parts { get; set; }

	public long? RecCount { get; set; }

	public long? RecFailed { get; set; }

	public long? RecSuccess { get; set; }

	public bool? IsUnicode { get; set; }
}
