using System;

namespace Mobile.Models;

public class MobspSelectClosedCalendarEvents_Result
{
	public DateTime? SingleDate { get; set; }

	public string SingleDateEN { get; set; }

	public string SingleDateFA { get; set; }

	public string SingleDateAR { get; set; }

	public string DayName { get; set; }

	public int? IsClosed { get; set; }

	public string IsClosedDesc { get; set; }
}
