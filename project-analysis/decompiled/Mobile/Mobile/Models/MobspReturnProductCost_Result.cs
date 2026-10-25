using System;

namespace Mobile.Models;

public class MobspReturnProductCost_Result
{
	public int ProductCostID { get; set; }

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

	public int? ProductCostGroupId { get; set; }

	public DateTime RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	public long? rn { get; set; }
}
