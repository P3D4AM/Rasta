using System;

namespace CRM.Models;

public class CRMspLkHolooWSSelectOrderByOrdIds_Result
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

	public int? CompanyNumber { get; set; }

	public string cmpLinkAccCustomerIdStr { get; set; }

	public string CompanyName { get; set; }

	public string CompanyPerson { get; set; }

	public string ProjectTitle { get; set; }

	public string ordReferUser { get; set; }

	public int? ordLinkAccCodeId { get; set; }

	public string ordLinkAccCode { get; set; }

	public int? ordLinkAccOrderId { get; set; }

	public string ordLinkAccOrderNumber { get; set; }

	public string ordLinkAccVoucherId { get; set; }

	public string ordLinkAccVoucherNumber { get; set; }

	public string ordLinkAccOrderIdStr { get; set; }

	public long? RowNumber { get; set; }

	public string ordLinkAccTransferKey { get; set; }

	public string ordLinkAccTransferResult { get; set; }

	public string ordDescriptionII { get; set; }

	public DateTime? ordDeadlineDate { get; set; }
}
