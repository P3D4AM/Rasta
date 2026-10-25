using System;

namespace CRM.Models;

public class CRMspLkSepWSSelectBuyOrderFromSep_Result
{
	public int? InventoryPurchaseInvoiceID { get; set; }

	public int? VendorDLRef { get; set; }

	public string Vendor { get; set; }

	public int? Number { get; set; }

	public int? InvoiceNumber { get; set; }

	public DateTime? Date { get; set; }

	public decimal? TotalPrice { get; set; }

	public decimal? TotalPriceInBaseCurrency { get; set; }

	public decimal? TotalTax { get; set; }

	public decimal? TotalDuty { get; set; }

	public decimal? TotalTransportPrice { get; set; }

	public decimal? TotalNetPrice { get; set; }

	public decimal? TotalNetPriceInBaseCurrency { get; set; }

	public decimal? TotalWithHoldingTaxAmount { get; set; }

	public decimal? TotalInsuranceAmount { get; set; }

	public int? FiscalYearRef { get; set; }

	public DateTime? CreationDate { get; set; }

	public DateTime? LastModificationDate { get; set; }

	public int? PaymentHeaderRef { get; set; }

	public int? AccountingVoucherRef { get; set; }

	public int? VoucherNumber { get; set; }

	public int? ItemCount { get; set; }

	public int? BuyOrderId { get; set; }

	public long? RowNumber { get; set; }

	public int? AllPage { get; set; }
}
