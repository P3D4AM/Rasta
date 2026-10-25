using System;

namespace CRM.Models;

public class TSPspSelectOrder_Result
{
	public int OrderID { get; set; }

	public int? OrderOprID { get; set; }

	public string OrderOpr { get; set; }

	public int? OrderOprType { get; set; }

	public long ordNumber { get; set; }

	public string ordDate { get; set; }

	public int ordCompanyId { get; set; }

	public string CompanyName { get; set; }

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

	public string ordReferUser { get; set; }

	public decimal? ordDiscountPercent { get; set; }

	public decimal? ordRound { get; set; }

	public DateTime? ordDateTime { get; set; }

	public int? ordCurrencyUnitId { get; set; }

	public string ordCurrencyUnit { get; set; }

	public bool? ordCurrencyUnitIsDecimal { get; set; }

	public int? ordTspSettingId { get; set; }

	public string TspOrdIdentify { get; set; }

	public string TspOrdInno { get; set; }

	public int? TspOrdIns { get; set; }

	public string TspOrdIrtaxid { get; set; }

	public int? TspOrdFt { get; set; }

	public string TspOrdBillid { get; set; }

	public int? TspOrdSetm { get; set; }

	public decimal? TspOrdTax17 { get; set; }

	public DateTime? TspOrdSendDate { get; set; }

	public string TspOrdSendDatePersian { get; set; }

	public DateTime? TspOrdLastEditDate { get; set; }

	public string TspOrdLastEditDatePersian { get; set; }

	public string TspOrdUID { get; set; }

	public string TspOrdReferenceNumber { get; set; }

	public string TspOrdStatus { get; set; }

	public string TspOrdMessage { get; set; }

	public long? RowNumber { get; set; }

	public string TspOrdCdcn { get; set; }

	public DateTime? TspOrdCdcd { get; set; }

	public string TspOrdCdcdPersian { get; set; }

	public int? AllPage { get; set; }

	public int? TspCmpTob { get; set; }

	public string TspCmpTobTitle { get; set; }

	public string TspOrdStatusResult { get; set; }

	public int? TspOrdStatusResultNum { get; set; }

	public decimal? ordItemsDiscount { get; set; }

	public decimal? ordItemsTax { get; set; }

	public decimal? ordItemPriceSumWithoutDiscount { get; set; }

	public decimal? ordItemPriceSum { get; set; }
}
