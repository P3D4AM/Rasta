using System;

namespace CRM.Models;

public class mct_WSspSelectPreOrderIndicator_Result
{
	public int? PreOrderID { get; set; }

	public long? pordNumber { get; set; }

	public string pordDate { get; set; }

	public int? pordCompanyId { get; set; }

	public string Company { get; set; }

	public int? pordCompanyPersonId { get; set; }

	public string Person { get; set; }

	public string CompanyTel { get; set; }

	public string Project { get; set; }

	public int? pordProjectId { get; set; }

	public string pordSubject { get; set; }

	public decimal? pordItemsAmount { get; set; }

	public decimal? pordDiscountPercent { get; set; }

	public decimal? pordDiscount { get; set; }

	public decimal? pordSumAmount { get; set; }

	public decimal? pordTaxIndex { get; set; }

	public decimal? pordTax { get; set; }

	public decimal? pordTransportation { get; set; }

	public decimal? pordRound { get; set; }

	public decimal? pordTotalAmount { get; set; }

	public bool? pordIsVerified { get; set; }

	public int? pordVerifierId { get; set; }

	public string Verifier { get; set; }

	public int? pordVerifierRequestId { get; set; }

	public string VerifierRequest { get; set; }

	public int? pordStatusId { get; set; }

	public string Status { get; set; }

	public int? PreOrderOprId { get; set; }

	public string PreOrderOpr { get; set; }

	public bool? pordIsFixed { get; set; }

	public int? UserID { get; set; }

	public string UserName { get; set; }

	public string ReferUserName { get; set; }

	public string rptUserName { get; set; }

	public string rptDay { get; set; }

	public short? Month1 { get; set; }

	public int? rptDate { get; set; }

	public int? pordItemCount { get; set; }

	public int? pordVerificationWorkFlowId { get; set; }

	public string pordVerificationWorkFlow { get; set; }

	public string LastVerificationWorkFlowStep { get; set; }

	public string LastVerifyUser { get; set; }

	public DateTime? LastVerifyDateTime { get; set; }

	public int? pordDeliveryTermId { get; set; }

	public string pordDeliveryTerm { get; set; }

	public int? pordTypeId { get; set; }

	public string pordType { get; set; }

	public string pordNumRef { get; set; }

	public int? pordDefWHId { get; set; }

	public string pordDefWrhsName { get; set; }

	public int? pordDefPrdPriceGroupId { get; set; }

	public string pordDefPrdPriceGroup { get; set; }

	public int? pordSellerId { get; set; }

	public string pordSellerName { get; set; }

	public int? pordEmailUsersInfoId { get; set; }

	public string pordEmailUsersInfo { get; set; }

	public int? pordEmailUserDefaultSettingId { get; set; }

	public string pordEmailUserDefaultSetting { get; set; }

	public int? pordLinkAccPreOrderId { get; set; }

	public string pordLinkAccPreOrderNumber { get; set; }

	public string pordLinkAccPreOrderIdStr { get; set; }

	public int? CompanyNumber { get; set; }

	public string CompanyCode { get; set; }

	public string CompanyNationalCode { get; set; }

	public string PersonNationalCode { get; set; }

	public int? pordSaleCenterId { get; set; }

	public string pordSaleCenter { get; set; }

	public string pordExpireDate { get; set; }

	public DateTime? pordExpireDateTime { get; set; }

	public double? pordItemsQty { get; set; }

	public decimal? pordItemsDiscount { get; set; }

	public decimal? pordItemsTax { get; set; }

	public decimal? pordItemsPriceWithoutDiscount { get; set; }

	public decimal? pordItemsPriceWithDiscount { get; set; }

	public string prjInquiryNum { get; set; }

	public string prjNumRef { get; set; }

	public long? prjNumR { get; set; }

	public string pordDeadlineDatePersian { get; set; }

	public DateTime? pordDeadlineDate { get; set; }

	public string pordLinkAccData { get; set; }

	public string ProjectSubject { get; set; }

	public string ProjectDesc { get; set; }

	public string ProjectDescI { get; set; }

	public string PersonMobile { get; set; }

	public int? pordCurrencyUnitId { get; set; }

	public string pordCurrencyUnit { get; set; }

	public int? pordCurrencyUnitIdI { get; set; }

	public string pordCurrencyUnitI { get; set; }

	public double? pordCurrencyUnitIRate { get; set; }

	public decimal? SumPordPayAmount { get; set; }

	public decimal? RemainPordAmount { get; set; }

	public decimal? AllPayRemain { get; set; }

	public decimal? pordItemsAmountCurrencyI { get; set; }

	public decimal? pordInstallAmountCurrencyI { get; set; }

	public decimal? pordDiscountCurrencyI { get; set; }

	public decimal? pordSumAmountCurrencyI { get; set; }

	public decimal? pordTaxCurrencyI { get; set; }

	public decimal? pordTotalAmountCurrencyI { get; set; }

	public string pordTotalAmountCurrencyIStr { get; set; }

	public decimal? pordTransportationCurrencyI { get; set; }

	public decimal? pordRoundCurrencyI { get; set; }

	public decimal? pordItemsDiscountCurrencyI { get; set; }

	public decimal? pordItemsTaxCurrencyI { get; set; }

	public string prjStartDate { get; set; }

	public DateTime? prjStartDateTime { get; set; }

	public bool? HasOrder { get; set; }

	public string pordDeliveryDate { get; set; }

	public DateTime? pordDeliveryDateTime { get; set; }

	public string pordDeliveryTime { get; set; }

	public string pordDeliveryEndDate { get; set; }

	public DateTime? pordDeliveryEndDateTime { get; set; }

	public string pordDeliveryEndTime { get; set; }

	public string pordDeliveryDay { get; set; }

	public string pordDeliveryEndDay { get; set; }

	public bool? HasStockSupply { get; set; }

	public bool? HasDoc { get; set; }

	public int? cmpKind { get; set; }
}
