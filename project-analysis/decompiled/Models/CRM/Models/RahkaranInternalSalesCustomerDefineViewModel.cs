using System.Collections.Generic;

namespace CRM.Models;

public class RahkaranInternalSalesCustomerDefineViewModel
{
	public List<RahkaranInternalSalesCustomerAddressDefineViewModel> Addresses { get; set; }

	public long CurrencyRef { get; set; }

	public string DeclarationDate { get; set; }

	public string EconomicCode { get; set; }

	public string ExchangeCode { get; set; }

	public bool IsExportCustomer { get; set; }

	public string Number { get; set; }

	public RahkaranInternalSalesCustomerPartyDefineViewModel Party { get; set; }

	public int Type { get; set; }
}
