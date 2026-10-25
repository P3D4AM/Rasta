namespace CRM.Models;

public class WSspRpt_HourlySale_Result
{
	public int? StartHour { get; set; }

	public int? EndHour { get; set; }

	public string HourRange { get; set; }

	public int SaleCount { get; set; }

	public int ReturnedOrderCount { get; set; }

	public int TotalCount { get; set; }

	public decimal SumSaleAmount { get; set; }

	public decimal SumReturnedOrderAmount { get; set; }

	public decimal TotalAmount { get; set; }
}
