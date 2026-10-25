namespace Mobile.Models;

public class LeaveSummaryViewModel
{
	public int MonthlyDailySum { get; set; }

	public int MonthlyHourlySumInMin { get; set; }

	public string MonthlyHourlySumTxt { get; set; }

	public int YearlyDailySum { get; set; }

	public int YearlyHourlySumInMin { get; set; }

	public string YealyHourlySumTxt { get; set; }

	public int TotallyDailySum { get; set; }

	public int TotallyHourlySumInMin { get; set; }

	public string TotallyHourlySumTxt { get; set; }

	public string MonthlyLeaveStr { get; set; }

	public string YearlyLeaveStr { get; set; }

	public string TotallyLeaveStr { get; set; }
}
