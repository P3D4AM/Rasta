namespace Mobile.Models;

public class ChangePreOrderItemPriceViewModel
{
	public int PreOrderId { get; set; }

	public string ItemIds { get; set; }

	public decimal? Amount { get; set; }

	public decimal? PricePercent { get; set; }

	public int? Mode { get; set; }

	public int? LanguageId { get; set; }

	public int? CenterId { get; set; }
}
