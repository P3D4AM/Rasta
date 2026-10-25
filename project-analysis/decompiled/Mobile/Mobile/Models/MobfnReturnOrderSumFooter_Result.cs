namespace Mobile.Models;

public class MobfnReturnOrderSumFooter_Result
{
	public decimal? SumPriceAmount { get; set; }

	public decimal? SumPrice { get; set; }

	public decimal? SumQuantity { get; set; }

	public decimal? SumDiscount { get; set; }

	public decimal? SumDiscountI { get; set; }

	public decimal? SumTax { get; internal set; }

	public decimal? SumFCR { get; set; }

	public decimal? SumFCRI { get; set; }

	public decimal? SumRound { get; set; }

	public decimal? TotalPriceSum { get; set; }

	public decimal? TotalDiscountSum { get; set; }

	public decimal? TotalDiscountISum { get; internal set; }

	public decimal? TotalTaxSum { get; set; }

	public decimal? TotalPriceSumWithoutDiscount { get; set; }
}
