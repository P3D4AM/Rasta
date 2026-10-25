using System;

namespace CRM.Models;

public class FieldValueChangeHistoryViewModel
{
	public int? FId { get; set; }

	public int? FFId { get; set; }

	public long? FFRId { get; set; }

	public int? TUId { get; set; }

	public string TUName { get; set; }

	public DateTime? TDate { get; set; }

	public string TDateStr { get; set; }
}
