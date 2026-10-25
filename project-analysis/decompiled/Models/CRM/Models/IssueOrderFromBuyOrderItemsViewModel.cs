namespace CRM.Models;

public class IssueOrderFromBuyOrderItemsViewModel
{
	public int BordItemId { get; set; }

	public double? PrdQty { get; set; }

	public decimal? PrdPrice { get; set; }

	public int? PrdPriceGroupId { get; set; }

	public int? PrdId { get; set; }

	public int? WhId { get; set; }

	public string LinkAccWHIdStr { get; set; }

	public string PrdTracing { get; set; }

	public int? OrdItemId { get; set; }

	public double? PriceCurrencyRate { get; set; }

	public int? LinkAccSettingDBId { get; set; }
}
