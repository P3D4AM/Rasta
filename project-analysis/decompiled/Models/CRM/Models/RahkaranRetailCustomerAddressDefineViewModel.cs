namespace CRM.Models;

public class RahkaranRetailCustomerAddressDefineViewModel
{
	public string Details { get; set; }

	public string Email { get; set; }

	public string Tel { get; set; }

	public string Fax { get; set; }

	public bool? IsDefault { get; set; }

	public RahkaranRetailCustomerAddressLocationDefineViewModel Location { get; set; }

	public string Name { get; set; }

	public string ZipCode { get; set; }

	public string RegionalDivisionName { get; set; }

	public int? RegionalDivisionRef { get; set; }
}
