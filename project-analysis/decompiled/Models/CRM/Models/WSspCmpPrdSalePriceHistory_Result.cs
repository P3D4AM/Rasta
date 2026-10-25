using System;

namespace CRM.Models;

public class WSspCmpPrdSalePriceHistory_Result
{
	public int? cmpId { get; set; }

	public decimal? LastCmpPrice { get; set; }

	public double? LastCmpQuantity { get; set; }

	public string DateP { get; set; }

	public DateTime? DateTimeM { get; set; }

	public decimal? cmpMinPrice { get; set; }

	public decimal? cmpMaxPrice { get; set; }

	public decimal? cmpAvePrice { get; set; }
}
