namespace CRM.Models;

public class StockSupplyIdKeyValueDblViewModel
{
	public int Id { get; set; }

	public int Type { get; set; }

	public string Tag { get; set; }

	public double Value { get; set; }

	public bool? IsUsed { get; set; }

	public decimal? Cost { get; set; }

	public int? CostGroupId { get; set; }

	public double? PriceCurrencyRate { get; set; }
}
