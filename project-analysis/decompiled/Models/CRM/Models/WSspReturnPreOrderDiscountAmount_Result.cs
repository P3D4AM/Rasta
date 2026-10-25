namespace CRM.Models;

public class WSspReturnPreOrderDiscountAmount_Result
{
	public decimal? SumPriceAmount { get; set; }

	public decimal? pordDisPercent { get; set; }

	public decimal? pordDisAmount { get; set; }

	public decimal? DisStDisPercent { get; set; }

	public decimal? SumDisAmount { get; set; }

	public decimal? RemainDisAmount { get; set; }

	public bool? MnBgIsReturn { get; set; }

	public int? MnBgExpireDay { get; set; }
}
