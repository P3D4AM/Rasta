using System;

namespace CRM.Models;

public class CRMspLkSepWSSelectOrderFromSep_Result
{
	public int? InvoiceId { get; set; }

	public int? QuotationRef { get; set; }

	public int? QuotationNumber { get; set; }

	public int? CustomerPartyRef { get; set; }

	public string CustomerParty { get; set; }

	public string CustomerRealName { get; set; }

	public int? PartyAddressRef { get; set; }

	public int? Number { get; set; }

	public DateTime? Date { get; set; }

	public int? CurrencyRef { get; set; }

	public decimal Price { get; set; }

	public decimal? Discount { get; set; }

	public decimal? Addition { get; set; }

	public decimal? Tax { get; set; }

	public decimal? Duty { get; set; }

	public decimal? NetPrice { get; set; }

	public DateTime? CreationDate { get; set; }

	public DateTime? LastModificationDate { get; set; }

	public int? FiscalYearRef { get; set; }

	public int? VoucherRef { get; set; }

	public int? VoucherNumber { get; set; }

	public int? ItemCount { get; set; }

	public int? OrderId { get; set; }

	public long? RowNumber { get; set; }

	public int? AllPage { get; set; }
}
