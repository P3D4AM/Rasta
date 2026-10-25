namespace CRM.Models;

public class TarazSaleCustomerViewModel
{
	public long? customerID { get; set; }

	public string customerCode { get; set; }

	public string customerDesc { get; set; }

	public string customerName { get; set; }

	public string tafsiliCode { get; set; }

	public string perComTitle { get; set; }

	public string perComFName { get; set; }

	public string perComLName { get; set; }

	public string perComAddress { get; set; }

	public decimal? remainCash { get; set; }

	public decimal? remainChq { get; set; }
}
