using System;

namespace CRM.Models;

public class WSspRpt_CmpOrdStockPayAccI_Result
{
	public long? RowNumber { get; set; }

	public int? rptUserId { get; set; }

	public string rptDate { get; set; }

	public string rptDay { get; set; }

	public string rptUserName { get; set; }

	public int OrderID { get; set; }

	public int? OrderOprID { get; set; }

	public string OrderOpr { get; set; }

	public long ordNumber { get; set; }

	public string ordDate { get; set; }

	public int ordCompanyId { get; set; }

	public string Company { get; set; }

	public int? cmpNumber { get; set; }

	public int? ordCompanyPersonId { get; set; }

	public string Person { get; set; }

	public int? ordProjectId { get; set; }

	public string ProjectTitle { get; set; }

	public int? ordItemCount { get; set; }

	public decimal? ordItemsAmount { get; set; }

	public decimal? ordInstallAmount { get; set; }

	public decimal? ordDiscount { get; set; }

	public decimal? ordSumAmount { get; set; }

	public decimal? ordTax { get; set; }

	public decimal? ordTaxIndex { get; set; }

	public decimal? ordTotalAmount { get; set; }

	public string ordTotalAmountStr { get; set; }

	public int? ordStatusId { get; set; }

	public string OrderStatus { get; set; }

	public int? ordReferUserId { get; set; }

	public string ordReferUser { get; set; }

	public decimal? ordDiscountPercent { get; set; }

	public decimal? ordRound { get; set; }

	public DateTime? ordDateTime { get; set; }

	public int? ordCurrencyUnitId { get; set; }

	public string ordCurrencyUnit { get; set; }

	public string ordNumRef { get; set; }

	public long? ordDailyCounter { get; set; }

	public DateTime? ordDeadlineDate { get; set; }

	public string ordDeadlineDatePersian { get; set; }

	public int? OrderItemID { get; set; }

	public int? ordIPrdId { get; set; }

	public string PrdName { get; set; }

	public string PrdCode { get; set; }

	public string PrdFGName { get; set; }

	public string PrdSGName { get; set; }

	public double? ordIQuantity { get; set; }

	public decimal? ordIPrice { get; set; }

	public decimal? ordITotalPrice { get; set; }

	public int? ordIPrdUnitId { get; set; }

	public string ordIPrdUnit { get; set; }

	public double? ordIFCR { get; set; }

	public double? ordIFCRI { get; set; }

	public int? ordIWHId { get; set; }

	public string ordIWrhsName { get; set; }

	public string ordITracing { get; set; }

	public decimal? ordIPriceSum { get; set; }

	public decimal? ordIDiscountISum { get; set; }

	public decimal? ordIDiscountSum { get; set; }

	public decimal? ordITaxSum { get; set; }

	public double? ordIQuantityTotal { get; set; }

	public int? ordIOrderView { get; set; }

	public int? AllPage { get; set; }
}
