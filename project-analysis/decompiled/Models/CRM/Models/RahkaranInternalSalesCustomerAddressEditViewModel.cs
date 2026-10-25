namespace CRM.Models;

public class RahkaranInternalSalesCustomerAddressEditViewModel
{
	public long AddressRef { get; set; }

	public bool IsDeleted { get; set; }

	public RahkaranInternalSalesCustomerActionEditViewModel<long> CityRef { get; set; }

	public RahkaranInternalSalesCustomerActionEditViewModel<string> Details { get; set; }

	public RahkaranInternalSalesCustomerActionEditViewModel<string> Email { get; set; }

	public RahkaranInternalSalesCustomerActionEditViewModel<string> Fax { get; set; }

	public RahkaranInternalSalesCustomerActionEditViewModel<string> Latitude { get; set; }

	public RahkaranInternalSalesCustomerActionEditViewModel<string> Longitude { get; set; }

	public RahkaranInternalSalesCustomerActionEditViewModel<string> Name { get; set; }

	public RahkaranInternalSalesCustomerActionEditViewModel<string> Tel { get; set; }

	public RahkaranInternalSalesCustomerActionEditViewModel<int> Type { get; set; }

	public RahkaranInternalSalesCustomerActionEditViewModel<string> ZipCode { get; set; }
}
