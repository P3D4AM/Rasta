using System;

namespace CRM.Models;

public class CRMspLkSepWSSelectOrderByOrdId_Result
{
	public int OrderID { get; set; }

	public int? OrderOprID { get; set; }

	public long ordNumber { get; set; }

	public string ordDate { get; set; }

	public int ordCompanyId { get; set; }

	public int? ordCompanyPersonId { get; set; }

	public int? ordProjectId { get; set; }

	public int? ordItemCount { get; set; }

	public decimal? ordItemsAmount { get; set; }

	public decimal? ordInstallAmount { get; set; }

	public decimal? ordDiscount { get; set; }

	public decimal? ordSumAmount { get; set; }

	public decimal? ordTax { get; set; }

	public decimal? ordTaxIndex { get; set; }

	public bool? ordCalculateTax { get; set; }

	public decimal? ordTotalAmount { get; set; }

	public string ordTotalAmountStr { get; set; }

	public decimal? ordTransportation { get; set; }

	public int? ordReferUserId { get; set; }

	public decimal? ordDiscountPercent { get; set; }

	public decimal? ordRound { get; set; }

	public DateTime? ordDateTime { get; set; }

	public int? ordLinkAccCodeId { get; set; }

	public string ordLinkAccCode { get; set; }

	public int? ordLinkAccOrderId { get; set; }

	public string ordLinkAccOrderNumber { get; set; }

	public int? ordLinkAccVoucherId { get; set; }

	public string ordLinkAccVoucherNumber { get; set; }

	public string ordLinkAccOrderIdStr { get; set; }

	public int? ordCurrencyUnitId { get; set; }

	public string OrderOpr { get; set; }

	public int? OrderOprType { get; set; }

	public int? CompanyNumber { get; set; }

	public string CompanyName { get; set; }

	public string CompanyPerson { get; set; }

	public string ProjectTitle { get; set; }

	public string ordReferUser { get; set; }

	public string ordCurrencyUnit { get; set; }

	public bool? ordCurrencyUnitIsDecimal { get; set; }

	public string CompanyCode { get; set; }

	public int? cmpLinkAccCodeId { get; set; }

	public string cmpLinkAccCode { get; set; }

	public int? cmpLinkAccCustomerId { get; set; }

	public string cmpLinkAccCustomerIdStr { get; set; }

	public int? SepInvoiceId { get; set; }

	public int? SepInvoiceNumber { get; set; }

	public DateTime? SepInvoiceDate { get; set; }

	public string SepInvoiceDatePersian { get; set; }

	public int? SepInvoiceCustomerPartyRef { get; set; }

	public string SepInvoiceCustomerPartyFullName { get; set; }

	public string SepInvoiceCustomerPartyCode { get; set; }

	public decimal? SepInvoiceNetPrice { get; set; }

	public int? SepVoucherId { get; set; }

	public int? SepVoucherNumber { get; set; }

	public string ordCompanyName { get; set; }

	public DateTime? ordLinkAccFirstTransferDate { get; set; }

	public DateTime? ordLinkAccLastTransferDate { get; set; }

	public string ordLinkAccFirstTransferDateStr { get; set; }

	public string ordLinkAccLastTransferDateStr { get; set; }
}
