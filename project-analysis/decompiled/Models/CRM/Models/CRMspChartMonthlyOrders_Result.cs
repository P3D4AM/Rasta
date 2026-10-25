namespace CRM.Models;

public class CRMspChartMonthlyOrders_Result
{
	public string DateValue { get; set; }

	public string DateText { get; set; }

	public decimal? SaleOrderAmount { get; set; }

	public decimal? ReturnOrderAmount { get; set; }

	public decimal? NetOrderAmount { get; set; }

	public decimal? SaleOrderCount { get; set; }

	public decimal? ReturnOrderCount { get; set; }

	public decimal? NetOrderCount { get; set; }

	public decimal? NetOrderDiscountAmount { get; set; }

	public int? GroupFieldValue { get; set; }

	public string GroupFieldText { get; set; }
}
