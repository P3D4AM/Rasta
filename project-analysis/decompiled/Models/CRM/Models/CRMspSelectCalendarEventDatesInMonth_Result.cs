using System;

namespace CRM.Models;

public class CRMspSelectCalendarEventDatesInMonth_Result
{
	public int CalendarEventID { get; set; }

	public int? MonthNum { get; set; }

	public int? DayNum { get; set; }

	public string Description { get; set; }

	public int? LanguageID { get; set; }

	public string RelatedLanguageID { get; set; }

	public bool? IsClosed { get; set; }

	public DateTime? MiladiDate { get; set; }

	public int? MiladiYear { get; set; }

	public int? MiladiMonth { get; set; }

	public int? MiladiDay { get; set; }

	public int? JalaliYear { get; set; }

	public int? JalaliMonth { get; set; }

	public int? JalaliDay { get; set; }

	public int? QamariYear { get; set; }

	public int? QamariMonth { get; set; }

	public int? QamariDay { get; set; }

	public string MiladiDesc { get; set; }

	public string JalaliDesc { get; set; }

	public string QamariDesc { get; set; }

	public int? MiladiDayOfWeek { get; set; }
}
