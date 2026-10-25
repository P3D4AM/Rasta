using System;

namespace Mobile.Models;

public class MobSpSelectProductPriceByIds_Result
{
	public int PrdId { get; set; }

	public int? ProductPriceGroupId { get; set; }

	public decimal PrdPrice { get; set; }

	public int? CurrencyUnitId { get; set; }

	public string CurrencyUnit { get; set; }

	public string CurrencyUnitEn { get; set; }

	public decimal? PrdDiscountPrecent { get; set; }

	public decimal? PrdDiscount { get; set; }

	public decimal? PrePaymentPrice { get; set; }

	public decimal? PrdPriceAfterDiscount { get; set; }

	public decimal? TaxIndex { get; set; }

	public long? RowNumber { get; set; }

	public int? CId { get; set; }

	public DateTime? DocDateTime { get; set; }

	public string DocDate { get; set; }

	public int PrdPriceID { get; set; }
}
