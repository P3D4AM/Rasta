namespace CRM.Models;

public class RahkaranInternalSalesCustomerAddressDefineViewModel
{
	public string Details { get; set; }

	public string Email { get; set; }

	public string Fax { get; set; }

	public bool? IsDefault { get; set; }

	public RahkaranInternalSalesCustomerAddressLocationDefineViewModel Location { get; set; }

	public string Name { get; set; }

	public string ZipCode { get; set; }

	public long? RegionalDivisionRef { get; set; }

	public string Tel { get; set; }

	public int? Type { get; set; }

	public string TypeTitle { get; set; }
}
