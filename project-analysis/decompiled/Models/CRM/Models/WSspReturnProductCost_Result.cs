using System;

namespace CRM.Models;

public class WSspReturnProductCost_Result
{
	public int PrdId { get; set; }

	public string DocDate { get; set; }

	public DateTime? DocDateTime { get; set; }

	public string DocNumber { get; set; }

	public decimal Cost { get; set; }

	public decimal? CurrencyCost { get; set; }

	public int? CurrencyUnitId { get; set; }

	public string CurrencyUnit { get; set; }

	public string CurrencyUnitEn { get; set; }

	public decimal? TransportCost { get; set; }

	public decimal? ReleasingCost { get; set; }

	public decimal? SlagCost { get; set; }

	public decimal? OtherCost { get; set; }

	public double? CurrencyRate { get; set; }

	public bool? IsDecimal { get; set; }
}
