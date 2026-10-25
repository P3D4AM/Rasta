namespace CRM.Models;

public class CRMspReturnLeaveSummary_Result
{
	public int? MonthlyDailySum { get; set; }

	public int? MonthlyHourlySumInMin { get; set; }

	public string MonthlyHourlySumTxt { get; set; }

	public int? YearlyDailySum { get; set; }

	public int? YearlyHourlySumInMin { get; set; }

	public int? TotallyDailySum { get; set; }

	public int? TotallyHourlySumInMin { get; set; }

	public string TotallyHourlySumTxt { get; set; }

	public string YearlyHourlySumTxt { get; set; }
}
