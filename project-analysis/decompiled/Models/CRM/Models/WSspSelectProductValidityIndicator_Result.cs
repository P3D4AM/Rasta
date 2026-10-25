using System;

namespace CRM.Models;

public class WSspSelectProductValidityIndicator_Result
{
	public int oprType { get; set; }

	public int ordId { get; set; }

	public long oprNumber { get; set; }

	public string oprDate { get; set; }

	public DateTime? oprDateTime { get; set; }

	public int? oprCompanyId { get; set; }

	public string oprCompanyName { get; set; }

	public int? oprCompanyPersonId { get; set; }

	public string oprCompanyPersonName { get; set; }

	public string oprProjectTitle { get; set; }

	public int? oprItemCount { get; set; }

	public decimal? oprItemsAmount { get; set; }

	public decimal? oprDiscount { get; set; }

	public decimal? oprSumAmount { get; set; }

	public decimal? oprTax { get; set; }

	public decimal? oprTaxIndex { get; set; }

	public decimal? oprTotalAmount { get; set; }

	public string oprTotalAmountStr { get; set; }

	public decimal? oprDiscountPercent { get; set; }

	public decimal? oprTransportation { get; set; }

	public int? oprReferUserId { get; set; }

	public string oprReferUser { get; set; }

	public decimal? oprRound { get; set; }

	public int? OprOrderOprID { get; set; }

	public string OprOrderOprName { get; set; }

	public int? oprTypeId { get; set; }

	public string ordTypeTitle { get; set; }

	public int? oprSellerId { get; set; }

	public string oprSeller { get; set; }

	public DateTime? oprDeadlineDate { get; set; }

	public string oprDeadlineDatePersian { get; set; }

	public double? oprItemsQty { get; set; }

	public decimal? oprItemsDiscount { get; set; }

	public decimal? oprItemsTax { get; set; }

	public int oprIPrdId { get; set; }

	public string oprIPrdName { get; set; }

	public string oprIPrdCode { get; set; }

	public DateTime? oprIValidityExpireDate { get; set; }

	public string oprIValidityExpireDatePersian { get; set; }

	public string rptUserName { get; set; }

	public string rptDate { get; set; }

	public string rptDay { get; set; }

	public int? oprProjectId { get; set; }
}
