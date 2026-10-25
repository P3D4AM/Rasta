using System.Collections.Generic;

namespace CRM.Models;

public class RahkaranInternalSalesCustomerEditViewModel
{
	public long ID { get; set; }

	public List<RahkaranInternalSalesCustomerAddressEditViewModel> Addresses { get; set; }

	public RahkaranInternalSalesCustomerActionEditViewModel<long> CurrencyRef { get; set; }

	public RahkaranInternalSalesCustomerActionEditViewModel<string> EconomicCode { get; set; }

	public RahkaranInternalSalesCustomerActionEditViewModel<string> ExchangeCode { get; set; }

	public RahkaranInternalSalesCustomerActionEditViewModel<bool> IsExportCustomer { get; set; }

	public RahkaranInternalSalesCustomerActionEditViewModel<int> Type { get; set; }
}
