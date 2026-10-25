namespace CRM.Models;

public class HolooInvoiceDetailListViewModel
{
	public long? Row { get; set; }

	public string ProductCode { get; set; }

	public string ProductName { get; set; }

	public string ProductErpCode { get; set; }

	public double? Few { get; set; }

	public double? Karton { get; set; }

	public decimal? Price { get; set; }

	public decimal? SumPrice { get; set; }

	public decimal? Levy { get; set; }

	public decimal? Scot { get; set; }

	public decimal? PersentDiscount { get; set; }

	public decimal? Discount { get; set; }
}
