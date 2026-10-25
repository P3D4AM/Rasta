namespace CRM.Models;

public class WSspChartSalesTargetDistributionReport_Result
{
	public string DistributionItemId { get; set; }

	public string DistributionItemName { get; set; }

	public decimal? TargetCount { get; set; }

	public decimal? TargetAmount { get; set; }

	public decimal? ActualAmount { get; set; }

	public decimal? ActualCount { get; set; }

	public decimal? AchievementPercentAmount { get; set; }

	public decimal? AchievementPercentCount { get; set; }

	public decimal TotalTargetAmountPercent { get; set; }

	public decimal TotalActualAmountPercent { get; set; }

	public decimal TotalTargetCountPercent { get; set; }

	public decimal TotalActualCountPercent { get; set; }
}
