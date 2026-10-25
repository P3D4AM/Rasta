using System;

namespace CRM.Models;

public class CRMspLkSepWSSelectBuyOrder_Result
{
	public int? BuyOrderID { get; set; }

	public int? BuyOrderOprId { get; set; }

	public string BuyOrderOpr { get; set; }

	public long bordNumber { get; set; }

	public string bordOrderNumber { get; set; }

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

	public decimal? bordRound { get; set; }

	public decimal? bordDiscountPercent { get; set; }

	public DateTime? bordDateTime { get; set; }

	public int? bordLinkAccCodeId { get; set; }

	public string bordLinkAccCode { get; set; }

	public int? bordLinkAccBuyOrderId { get; set; }

	public string bordLinkAccBuyOrderNumber { get; set; }

	public int? bordLinkAccVoucherId { get; set; }

	public string bordLinkAccVoucherNumber { get; set; }

	public int? CompanyNumber { get; set; }

	public string CompanyName { get; set; }

	public string CompanyPerson { get; set; }

	public string ProjectTitle { get; set; }

	public string bordReferUser { get; set; }

	public long? RowNumber { get; set; }

	public int? AllPage { get; set; }
}
