namespace CRM.Models;

public class RahkaranRetailCustomerAddressInfoViewModel
{
	public long? id { get; set; }

	public string name { get; set; }

	public long? customerAddressId { get; set; }

	public long? cityId { get; set; }

	public string details { get; set; }

	public string zipCode { get; set; }

	public string phone { get; set; }

	public string fax { get; set; }

	public string email { get; set; }

	public bool? isDefault { get; set; }

	public string addressType { get; set; }
}
