using System;

namespace Mobile.Models;

public class MobspSelectProductPrice_Result
{
	public int PrdPriceID { get; set; }

	public int PrdId { get; set; }

	public string DocDate { get; set; }

	public DateTime? DocDateTime { get; set; }

	public string DocNumber { get; set; }

	public decimal Price { get; set; }

	public decimal? CurrencyPrice { get; set; }

	public int? CurrencyUnitId { get; set; }

	public string CurrencyUnit { get; set; }

	public string CurrencyUnitEn { get; set; }

	public bool? CurrencyIsDecimal { get; set; }

	public decimal? CooperationPrice { get; set; }

	public decimal? PricePercent { get; set; }

	public decimal? DiscountPrecent { get; set; }

	public decimal? Discount { get; set; }

	public decimal? OtherPrice { get; set; }

	public int? ProductPriceGroupId { get; set; }

	public DateTime RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	public long? rn { get; set; }

	public decimal? TaxIndex { get; set; }
}
