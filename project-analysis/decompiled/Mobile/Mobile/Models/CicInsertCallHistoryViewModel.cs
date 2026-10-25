using System;

namespace Mobile.Models;

public class CicInsertCallHistoryViewModel
{
	public string TelNumber { get; set; }

	public string Duration { get; set; }

	public int UserId { get; set; }

	public int CallType { get; set; }

	public DateTime? CallDateTime { get; set; }

	public int? LanguageId { get; set; }
}
