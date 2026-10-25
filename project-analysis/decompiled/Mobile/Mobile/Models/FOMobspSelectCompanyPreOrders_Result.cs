using System;

namespace Mobile.Models;

public class FOMobspSelectCompanyPreOrders_Result
{
	public int PreOrderID { get; set; }

	public string pordTitle { get; set; }

	public long pordNumber { get; set; }

	public int? pordCompanyId { get; set; }

	public int? pordCompanyPersonId { get; set; }

	public int? pordProjectId { get; set; }

	public string pordSubject { get; set; }

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

	public bool? pordIsVerified { get; set; }

	public int? pordStatusId { get; set; }

	public bool? pordIsFixed { get; set; }

	public int UserId { get; set; }

	public string RegisterUser { get; set; }

	public DateTime RegisterDate { get; set; }

	public string RegisterDatePerWithSlash { get; set; }

	public string pordDay { get; set; }

	public string pordTime { get; set; }

	public string pordDiscountTitle { get; set; }

	public decimal? pordDiscountPercent { get; set; }

	public decimal? pordTransportation { get; set; }

	public int? pordReferUserId { get; set; }

	public string pordReferUser { get; set; }

	public decimal? pordRound { get; set; }

	public DateTime? pordDate { get; set; }

	public string pordDatePerWithSlash { get; set; }

	public int? PreOrderOprID { get; set; }

	public int? FirstRegisterUserId { get; set; }

	public string FirstRegisterUser { get; set; }

	public DateTime? FirstRegisterDate { get; set; }

	public string FirstRegisterDatePerWithSlash { get; set; }

	public string Company { get; set; }

	public string CompanyPerson { get; set; }

	public string ProjectTitle { get; set; }

	public string PreOrderStatus { get; set; }

	public string PreOrderOpr { get; set; }

	public decimal? SumPreOrderPayAmount { get; set; }

	public decimal? RemainPreOrderAmount { get; set; }

	public long? RowNumber { get; set; }

	public double? SumItemQuantity { get; set; }

	public int? pordCurrencyUnitId { get; set; }

	public string pordCurrencyUnit { get; set; }

	public int? AllPage { get; set; }

	public string pordNumRef { get; set; }

	public long? pordNumberRevision { get; set; }

	public string LastPrintLogType { get; set; }

	public DateTime? LastPrintLogDateTime { get; set; }

	public int? ReviewStatus { get; set; }

	public int? VerifyStatus { get; set; }

	public int? CancelStatus { get; set; }

	public int? ExpireStatus { get; set; }

	public int? IssueOrderStatus { get; set; }

	public string StatusTitle { get; set; }

	public string LastPrjCnvsStatus { get; set; }
}
