namespace CRM.Models;

public class WSfnReturnProductPrice_Result
{
	public int PrdId { get; set; }

	public string DocDate { get; set; }

	public string DocNumber { get; set; }

	public decimal Price { get; set; }

	public decimal? CurrencyPrice { get; set; }

	public int? CurrencyUnitId { get; set; }

	public string CurrencyUnit { get; set; }

	public string CurrencyUnitEn { get; set; }

	public decimal? CooperationPrice { get; set; }

	public decimal? PricePercent { get; set; }

	public decimal? DiscountPrecent { get; set; }

	public decimal? Discount { get; set; }

	public decimal? OtherPrice { get; set; }
}
