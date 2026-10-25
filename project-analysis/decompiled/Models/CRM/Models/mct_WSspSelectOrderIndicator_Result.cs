using System;

namespace CRM.Models;

public class mct_WSspSelectOrderIndicator_Result
{
	public int? PreOrderID { get; set; }

	public int? OrderID { get; set; }

	public long? ordNumber { get; set; }

	public string ordDate { get; set; }

	public int? ordCompanyId { get; set; }

	public string Company { get; set; }

	public int? ordCompanyPersonId { get; set; }

	public string Person { get; set; }

	public string CompanyTel { get; set; }

	public string Project { get; set; }

	public int? ordProjectId { get; set; }

	public string ordSubject { get; set; }

	public decimal? ordDiscount { get; set; }

	public decimal? ordSumAmount { get; set; }

	public decimal? ordTax { get; set; }

	public decimal? ordRound { get; set; }

	public decimal? ordTotalAmount { get; set; }

	public bool? ordIsVerified { get; set; }

	public int? ordStatusId { get; set; }

	public string Status { get; set; }

	public bool? ordIsFixed { get; set; }

	public string UserName { get; set; }

	public string ReferUserName { get; set; }

	public string rptUserName { get; set; }

	public string rptDay { get; set; }

	public short? Month1 { get; set; }

	public int? ordItemCount { get; set; }

	public int? OrderOprID { get; set; }

	public string OprName { get; set; }

	public string CompanyProvince { get; set; }

	public string CompanyCity { get; set; }

	public string CompanycmpAddress { get; set; }

	public string cmpZipCode { get; set; }

	public string cmpFax { get; set; }

	public string cmpEconomicCode { get; set; }

	public string cmpNationalCode { get; set; }

	public long? PreOrderNumber { get; set; }

	public decimal? PaySumOrder { get; set; }

	public decimal? PayRemainOrder { get; set; }

	public decimal? PayRemainAllOrder { get; set; }

	public string cmpRegistrationNumber { get; set; }

	public string rptDate { get; set; }

	public DateTime? ordDateTime { get; set; }

	public decimal? SumItemPriceAmount { get; set; }

	public int? UserId { get; set; }

	public decimal? ordTransportation { get; set; }

	public int? ordDeliveryTermId { get; set; }

	public string ordDeliveryTerm { get; set; }

	public string ordNumRef { get; set; }

	public int? ordDefWHId { get; set; }

	public string ordDefWrhsName { get; set; }

	public int? ordDefPrdPriceGroupId { get; set; }

	public string ordDefPrdPriceGroup { get; set; }

	public int? ordSellerId { get; set; }

	public string ordSellerName { get; set; }

	public int? ordEmailUsersInfoId { get; set; }

	public string ordEmailUsersInfo { get; set; }

	public int? ordEmailUserDefaultSettingId { get; set; }

	public string ordEmailUserDefaultSetting { get; set; }

	public int? ordVerificationWorkFlowId { get; set; }

	public string ordVerificationWorkFlow { get; set; }

	public string LastVerificationWorkFlowStep { get; set; }

	public string LastVerifyUser { get; set; }

	public DateTime? LastVerifyDateTime { get; set; }

	public string ordSpecialWord { get; set; }

	public string ordITracing { get; set; }

	public int? ordLinkAccCodeId { get; set; }

	public string ordLinkAccCode { get; set; }

	public int? ordLinkAccOrderId { get; set; }

	public string ordLinkAccOrderNumber { get; set; }

	public int? ordLinkAccVoucherId { get; set; }

	public string ordLinkAccVoucherNumber { get; set; }

	public string ordLinkAccOrderIdStr { get; set; }

	public int? CompanyNumber { get; set; }

	public string CompanyCode { get; set; }

	public string PersonNationalCode { get; set; }

	public int? ordSaleCenterId { get; set; }

	public string ordSaleCenter { get; set; }

	public long? ordDailyCounter { get; set; }

	public decimal? ordItemsTax { get; set; }

	public decimal? ordItemsDiscount { get; set; }

	public double? ordItemsQty { get; set; }

	public decimal? ordItemsPriceWithDiscount { get; set; }

	public decimal? ordItemsPriceWithoutDiscount { get; set; }

	public string prjInquiryNum { get; set; }

	public string prjNumRef { get; set; }

	public long? prjNumR { get; set; }

	public decimal? ordGrossProfit { get; set; }

	public decimal? ordMoneySleep { get; set; }

	public decimal? ordSaleNetProfit { get; set; }

	public decimal? ordSumOtherComm { get; set; }

	public decimal? ordSumSaleComm { get; set; }

	public decimal? ordSumBuyComm { get; set; }

	public decimal? ordSumMangComm { get; set; }

	public decimal? ordNetProfit { get; set; }

	public DateTime? ordDeadlineDate { get; set; }

	public string ordDeadlineDatePersian { get; set; }

	public string ordLinkAccData { get; set; }

	public decimal? CompanyMoneyBagRemain { get; set; }

	public string ProjectSubject { get; set; }

	public string ProjectprjDesc { get; set; }

	public string ProjectprjDescI { get; set; }

	public string PersonMobile { get; set; }

	public int? ordCurrencyUnitId { get; set; }

	public string ordCurrencyUnit { get; set; }

	public int? ordCurrencyUnitIdI { get; set; }

	public string ordCurrencyUnitI { get; set; }

	public double? ordCurrencyUnitIRate { get; set; }

	public decimal? SumOrdPayAmount { get; set; }

	public decimal? RemainOrdAmount { get; set; }

	public decimal? ordItemsAmountCurrencyI { get; set; }

	public decimal? ordInstallAmountCurrencyI { get; set; }

	public decimal? ordDiscountCurrencyI { get; set; }

	public decimal? ordSumAmountCurrencyI { get; set; }

	public decimal? ordTaxCurrencyI { get; set; }

	public decimal? ordTotalAmountCurrencyI { get; set; }

	public string ordTotalAmountCurrencyIStr { get; set; }

	public decimal? ordTransportationCurrencyI { get; set; }

	public decimal? ordRoundCurrencyI { get; set; }

	public decimal? ordItemsDiscountCurrencyI { get; set; }

	public decimal? ordItemsTaxCurrencyI { get; set; }

	public decimal? ordGrossProfitCurrencyI { get; set; }

	public decimal? ordMoneySleepCurrencyI { get; set; }

	public decimal? ordSaleNetProfitCurrencyI { get; set; }

	public decimal? ordSumOtherCommCurrencyI { get; set; }

	public decimal? ordSumSaleCommCurrencyI { get; set; }

	public decimal? ordSumBuyCommCurrencyI { get; set; }

	public decimal? ordSumMangCommCurrencyI { get; set; }

	public decimal? ordNetProfitCurrencyI { get; set; }

	public int? ordSettlementTypeId { get; set; }

	public string ordSettlementType { get; set; }

	public int? cmpKind { get; set; }

	public string TspOrdIdentify { get; set; }

	public string RefOrderNumber { get; set; }

	public string ReturnOrderNumbers { get; set; }
}
