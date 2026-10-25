namespace CRM.Models;

public class WSspSelectLinkedProductsWithPrice_Result
{
	public string ProductName { get; set; }

	public string ProductCode { get; set; }

	public string ProductSecondGroup { get; set; }

	public int PrdId { get; set; }

	public int LinkedPrdId { get; set; }

	public int? ProductIdForLoad { get; set; }

	public int LinkedProductId { get; set; }

	public double? LinkedPrdQuantity { get; set; }

	public bool? LinkedPrdNotVisible { get; set; }

	public bool? LinkedPrdNotInSum { get; set; }

	public bool? LinkedPrdAddQuantity { get; set; }

	public bool? LinkedPrdAddPrice { get; set; }

	public bool? LinkedPrdAddDiscount { get; set; }

	public bool? LinkedPrdIsSelect { get; set; }

	public double? PrdPrice { get; set; }

	public decimal? PrdDiscount { get; set; }

	public decimal? PrdDiscountPrecent { get; set; }
}
