using System;

namespace Mobile.Models;

public class FOMobspSelectCompanyOrders_Result
{
	public int OrderID { get; set; }

	public int? OrderOprID { get; set; }

	public int? PreOrderId { get; set; }

	public string ordTitle { get; set; }

	public long ordNumber { get; set; }

	public int ordCompanyId { get; set; }

	public int? ordCompanyPersonId { get; set; }

	public int? ordProjectId { get; set; }

	public string ordSubject { get; set; }

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

	public bool? ordIsVerified { get; set; }

	public int? ordStatusId { get; set; }

	public bool? ordIsFixed { get; set; }

	public int UserId { get; set; }

	public string RegisterUser { get; set; }

	public DateTime RegisterDate { get; set; }

	public string RegisterDatePerWithSlash { get; set; }

	public int? ordSettlementTypeId { get; set; }

	public string ordDay { get; set; }

	public string ordTime { get; set; }

	public decimal? ordTransportation { get; set; }

	public int? ordReferUserId { get; set; }

	public string ordReferUser { get; set; }

	public decimal? ordDiscountPercent { get; set; }

	public string ordDiscountTitle { get; set; }

	public decimal? ordRound { get; set; }

	public DateTime? ordDate { get; set; }

	public string ordDatePerWithSlash { get; set; }

	public int? FirstRegisterUserId { get; set; }

	public string FirstRegisterUser { get; set; }

	public DateTime? FirstRegisterDate { get; set; }

	public string FirstRegisterDatePerWithSlash { get; set; }

	public string Company { get; set; }

	public string CompanyPerson { get; set; }

	public string ProjectTitle { get; set; }

	public string ordStatus { get; set; }

	public string OrderOpr { get; set; }

	public string SettlementType { get; set; }

	public long? pordNumber { get; set; }

	public decimal? SumOrderPayAmount { get; set; }

	public decimal? RemainOrderAmount { get; set; }

	public long? RowNumber { get; set; }

	public double? SumItemQuantity { get; set; }

	public int? ordCurrencyUnitId { get; set; }

	public string ordCurrencyUnit { get; set; }

	public int? AllPage { get; set; }

	public string ordNumRef { get; set; }

	public long? ordDailyCounter { get; set; }
}
