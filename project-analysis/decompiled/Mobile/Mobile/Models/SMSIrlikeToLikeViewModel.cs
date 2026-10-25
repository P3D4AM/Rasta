using System;

namespace Mobile.Models;

public class SMSIrlikeToLikeViewModel
{
	public string[] messageTexts { get; set; }

	public string[] mobiles { get; set; }

	public long lineNumber { get; set; }

	public DateTime? senddatetime { get; set; }
}
