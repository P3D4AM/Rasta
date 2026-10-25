using System;

namespace CRM.Models;

public class SmsReceiveViewModel
{
	public long? OrderNum { get; set; }

	public string SmsNumber { get; set; }

	public string SmsDesc { get; set; }

	public string GetId { get; set; }

	public string FromNumber { get; set; }

	public DateTime? ReceiveDate { get; set; }

	public string ReceiveDatePersian { get; set; }

	public string ReceiveDatePersianPreview { get; set; }

	public DateTime? SendDate { get; set; }

	public string SendDatePersian { get; set; }

	public string SendDatePersianPreview { get; set; }

	public string ReceiveDay { get; set; }

	public string ReceiveTime { get; set; }
}
