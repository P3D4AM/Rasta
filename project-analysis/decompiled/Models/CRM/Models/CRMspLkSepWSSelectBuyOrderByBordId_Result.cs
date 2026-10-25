using System;

namespace CRM.Models;

public class CRMspLkSepWSSelectBuyOrderByBordId_Result
{
	public int BuyOrderID { get; set; }

	public int? BuyOrderOprID { get; set; }

	public long bordNumber { get; set; }

	public string bordDate { get; set; }

	public int bordCompanyId { get; set; }

	public int? bordCompanyPersonId { get; set; }

	public int? bordProjectId { get; set; }

	public int? bordItemCount { get; set; }

	public decimal? bordItemsAmount { get; set; }

	public decimal? bordDiscount { get; set; }

	public decimal? bordSumAmount { get; set; }

	public decimal? bordTax { get; set; }

	public decimal? bordTaxIndex { get; set; }

	public bool? bordCalculateTax { get; set; }

	public decimal? bordTotalAmount { get; set; }

	public string bordTotalAmountStr { get; set; }

	public decimal? bordTransportation { get; set; }

	public int? bordReferUserId { get; set; }

	public decimal? bordDiscountPercent { get; set; }

	public decimal? bordRound { get; set; }

	public DateTime? bordDateTime { get; set; }

	public int? bordLinkAccCodeId { get; set; }

	public string bordLinkAccCode { get; set; }

	public int? bordLinkAccBuyOrderId { get; set; }

	public string bordLinkAccBuyOrderNumber { get; set; }

	public int? bordLinkAccVoucherId { get; set; }

	public string bordLinkAccVoucherNumber { get; set; }

	public int? bordCurrencyUnitId { get; set; }

	public string BuyOrderOpr { get; set; }

	public int? BuyOrderOprType { get; set; }

	public int? CompanyNumber { get; set; }

	public string CompanyName { get; set; }

	public string CompanyPerson { get; set; }

	public string ProjectTitle { get; set; }

	public string bordReferUser { get; set; }

	public string bordCurrencyUnit { get; set; }

	public bool? bordCurrencyUnitIsDecimal { get; set; }

	public string bordCompanyName { get; set; }

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

	public DateTime? bordLinkAccFirstTransferDate { get; set; }

	public DateTime? bordLinkAccLastTransferDate { get; set; }

	public string bordLinkAccFirstTransferDateStr { get; set; }

	public string bordLinkAccLastTransferDateStr { get; set; }
}
