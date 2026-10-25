using System;

namespace CRM.Models;

public class CRMspLkSepWSSelectPreOrderFromSep_Result
{
	public int? QuotationId { get; set; }

	public int? CustomerPartyRef { get; set; }

	public string CustomerParty { get; set; }

	public int? PartyAddressRef { get; set; }

	public int? Number { get; set; }

	public DateTime? Date { get; set; }

	public DateTime? ExpirationDate { get; set; }

	public int? CurrencyRef { get; set; }

	public decimal? Price { get; set; }

	public decimal? Discount { get; set; }

	public decimal? Addition { get; set; }

	public decimal? Tax { get; set; }

	public decimal? Duty { get; set; }

	public decimal? NetPrice { get; set; }

	public DateTime? CreationDate { get; set; }

	public DateTime? LastModificationDate { get; set; }

	public int? FiscalYearRef { get; set; }

	public int? ItemCount { get; set; }

	public int? PreOrderId { get; set; }

	public long? RowNumber { get; set; }

	public int? AllPage { get; set; }
}
