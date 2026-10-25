namespace Mobile.Models;

public class DistributeDiscountViewModel
{
	public int MasterId { get; set; }

	public string ItemIds { get; set; }

	public decimal? Discount { get; set; }

	public decimal? DiscountPercent { get; set; }

	public int? LanguageId { get; set; }

	public bool AddToDiscount { get; set; }

	public int DiscountCodeId { get; set; }

	public int? CenterId { get; set; }
}
