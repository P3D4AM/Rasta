using System;

namespace CRM.Models;

public class CRMspLkSepWSSelectPreOrderByPordId_Result
{
	public int PreOrderID { get; set; }

	public long pordNumber { get; set; }

	public string pordDate { get; set; }

	public int? pordCompanyId { get; set; }

	public int? pordCompanyPersonId { get; set; }

	public int? pordProjectId { get; set; }

	public int? pordItemCount { get; set; }

	public decimal? pordItemsAmount { get; set; }

	public decimal? pordInstallAmount { get; set; }

	public decimal? pordDiscount { get; set; }

	public decimal? pordSumAmount { get; set; }

	public decimal? pordTax { get; set; }

	public decimal? pordTaxIndex { get; set; }

	public bool? pordCalculateTax { get; set; }

	public decimal? pordTotalAmount { get; set; }

	public string pordTotalAmountStr { get; set; }

	public int? pordReferUserId { get; set; }

	public DateTime? pordDateTime { get; set; }

	public decimal? pordTransportation { get; set; }

	public decimal? pordDiscountPercent { get; set; }

	public decimal? pordRound { get; set; }

	public int? CompanyNumber { get; set; }

	public string CompanyName { get; set; }

	public string CompanyPerson { get; set; }

	public string ProjectTitle { get; set; }

	public string pordReferUser { get; set; }

	public int? pordLinkAccPreOrderId { get; set; }

	public string pordLinkAccPreOrderNumber { get; set; }

	public int? LinkAccPreOrderId { get; set; }

	public string pordCurrencyUnit { get; set; }

	public bool? pordCurrencyUnitIsDecimal { get; set; }

	public string pordLinkAccPreOrderIdStr { get; set; }

	public string CompanyCode { get; set; }

	public int? cmpLinkAccCodeId { get; set; }

	public string cmpLinkAccCode { get; set; }

	public int? cmpLinkAccCustomerId { get; set; }

	public string cmpLinkAccCustomerIdStr { get; set; }

	public int? SepQuotationId { get; set; }

	public int? SepQuotationNumber { get; set; }

	public DateTime? SepQuotationDate { get; set; }

	public string SepQuotationDatePersian { get; set; }

	public int? SepQuotationPartyRef { get; set; }

	public string SepQuotationPartyFullName { get; set; }

	public string SepQuotationPartyCode { get; set; }

	public decimal? SepQuotationNetPrice { get; set; }

	public string pordCompanyName { get; set; }

	public int? PreOrderOprID { get; set; }

	public string PreOrderOpr { get; set; }

	public DateTime? pordLinkAccFirstTransferDate { get; set; }

	public DateTime? pordLinkAccLastTransferDate { get; set; }

	public string pordLinkAccFirstTransferDateStr { get; set; }

	public string pordLinkAccLastTransferDateStr { get; set; }
}
