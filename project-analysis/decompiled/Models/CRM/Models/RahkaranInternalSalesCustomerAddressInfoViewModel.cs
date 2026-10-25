namespace CRM.Models;

public class RahkaranInternalSalesCustomerAddressInfoViewModel
{
	public string Details { get; set; }

	public string Email { get; set; }

	public string Fax { get; set; }

	public long? ID { get; set; }

	public bool? IsDefault { get; set; }

	public RahkaranInternalSalesCustomerAddressLocationInfoViewModel Location { get; set; }

	public string Name { get; set; }

	public long? RegionalDivisionRef { get; set; }

	public string Tel { get; set; }

	public int? Type { get; set; }

	public string TypeTitle { get; set; }

	public string ZipCode { get; set; }
}
