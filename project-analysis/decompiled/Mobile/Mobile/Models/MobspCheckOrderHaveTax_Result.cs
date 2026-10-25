namespace Mobile.Models;

public class MobspCheckOrderHaveTax_Result
{
	public decimal? ordTax { get; set; }

	public decimal? ordItemsTax { get; set; }

	public int? OrderOprID { get; set; }

	public bool? Taxable { get; set; }

	public int ordCompanyId { get; set; }
}
