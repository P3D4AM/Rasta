using System.Collections.Generic;

namespace CRM.Models;

public class RahkaranRetailCustomerDefineViewModel
{
	public List<RahkaranRetailCustomerAddressDefineViewModel> Addresss { get; set; }

	public int CurrencyRef { get; set; }

	public string DeclarationDate { get; set; }

	public string EconomicCode { get; set; }

	public string ExchangeCode { get; set; }

	public bool IsExportCustomer { get; set; }

	public string Number { get; set; }

	public RahkaranRetailCustomerPartyDefineViewModel Party { get; set; }

	public string SalesOfficeIDs { get; set; }

	public string SecondCode { get; set; }

	public int Type { get; set; }
}
