using System;

namespace CRM.Models;

public class TspOrdMessageViewModel
{
	public bool IsError { get; set; }

	public string Message { get; set; }

	public DateTime? MsgDate { get; set; }

	public string MsgDatePersian { get; set; }

	public string ErrorCode { get; set; }
}
