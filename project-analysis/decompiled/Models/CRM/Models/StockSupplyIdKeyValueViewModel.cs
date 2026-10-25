namespace CRM.Models;

public class StockSupplyIdKeyValueViewModel
{
	public string Id { get; set; }

	public int Type { get; set; }

	public string Tag { get; set; }

	public string Value { get; set; }

	public bool? IsUsed { get; set; }

	public string Cost { get; set; }

	public string CostGroupId { get; set; }

	public double? PriceCurrencyRate { get; set; }

	public string Quantity { get; set; }
}
