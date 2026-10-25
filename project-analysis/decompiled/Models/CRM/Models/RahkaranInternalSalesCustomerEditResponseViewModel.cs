using System.Collections.Generic;

namespace CRM.Models;

public class RahkaranInternalSalesCustomerEditResponseViewModel
{
	public List<RahkaranInternalSalesCustomerAddressEditResponseViewModel> Addresses { get; set; }

	public long? CurrencyRef { get; set; }

	public string DeclarationDate { get; set; }

	public string ExchangeCode { get; set; }

	public long? ID { get; set; }

	public bool IsExportCustomer { get; set; }

	public bool? IsRepresentative { get; set; }

	public string Number { get; set; }

	public int Type { get; set; }
}
