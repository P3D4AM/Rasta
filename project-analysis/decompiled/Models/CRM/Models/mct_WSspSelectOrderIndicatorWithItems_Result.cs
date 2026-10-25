using System;

namespace CRM.Models;

public class mct_WSspSelectOrderIndicatorWithItems_Result
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

	public int? UserId { get; set; }

	public string UserName { get; set; }

	public string rptUserName { get; set; }

	public string rptDay { get; set; }

	public short? Month1 { get; set; }

	public int? ordItemCount { get; set; }

	public int? OrderOprID { get; set; }

	public string CompanyProvince { get; set; }

	public string CompanyCity { get; set; }

	public string cmpEconomicCode { get; set; }

	public string cmpNationalCode { get; set; }

	public long? PreOrderNumber { get; set; }

	public decimal? PaySumOrder { get; set; }

	public decimal? PayRemainOrder { get; set; }

	public decimal? PayRemainAllOrder { get; set; }

	public string cmpRegistrationNumber { get; set; }

	public string rptDate { get; set; }

	public string ordTitle { get; set; }

	public string CmpTitle { get; set; }

	public string PersonJob { get; set; }

	public string PersonDepartment { get; set; }

	public string prsNationalCode { get; set; }

	public string prsMobile { get; set; }

	public string CompanyFax { get; set; }

	public string CompanyCountry { get; set; }

	public string CompanyAddress { get; set; }

	public string CompanyZipcode { get; set; }

	public int? CompanyNumber { get; set; }

	public decimal? ordItemsAmount { get; set; }

	public decimal? ordInstallAmount { get; set; }

	public string ordDiscountTitle { get; set; }

	public decimal? ordDiscountPercent { get; set; }

	public decimal? ordTaxIndex { get; set; }

	public bool? ordCalculateTax { get; set; }

	public string ordTotalAmountStr { get; set; }

	public string VerifierFName { get; set; }

	public string VerifierLName { get; set; }

	public int? ordVerifierId { get; set; }

	public int? ordGuarantyId { get; set; }

	public string Guaranty { get; set; }

	public string ordDescriptionI { get; set; }

	public string ordDescriptionII { get; set; }

	public int? ordDescriptionId { get; set; }

	public int? ordPrintFormatId { get; set; }

	public int? ordRLogoId { get; set; }

	public int? ordLLogoId { get; set; }

	public string ordAccountNumberI { get; set; }

	public string ordAccountShabaNumberI { get; set; }

	public string ordAccountNumberII { get; set; }

	public string ordAccountShabaNumberII { get; set; }

	public string ordSigningI { get; set; }

	public string ordSigningII { get; set; }

	public string ordSigningIII { get; set; }

	public string ordSpecialWord { get; set; }

	public int? ordSignatureId { get; set; }

	public string UserDirectTel { get; set; }

	public string UserTelDesc { get; set; }

	public int FPId { get; set; }

	public DateTime RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	public string pordReferUser { get; set; }

	public string pordVerifierUser { get; set; }

	public int OrderItemID { get; set; }

	public int ordIPrdId { get; set; }

	public string PrdNMBL { get; set; }

	public string PrdCode { get; set; }

	public string PrdName { get; set; }

	public string PrdFGName { get; set; }

	public string PrdSGName { get; set; }

	public string PrdFGNameEn { get; set; }

	public string PrdSGNameEn { get; set; }

	public string PrdGroup { get; set; }

	public string PrdGroupEn { get; set; }

	public string PrdLatinName { get; set; }

	public string PrdModel { get; set; }

	public string PrdFirstBarcode { get; set; }

	public string PrdType { get; set; }

	public string PrdDesign { get; set; }

	public string PrdSize { get; set; }

	public string PrdColor { get; set; }

	public string PrdColorEn { get; set; }

	public string PrdCostCurrencyUnit { get; set; }

	public string PrdCostCurrencyUnitEn { get; set; }

	public double? OrdIQuantity { get; set; }

	public decimal? ordIPrice { get; set; }

	public decimal? ordITotalPrice { get; set; }

	public string ordIDescription { get; set; }

	public int OIUserId { get; set; }

	public int OIFPId { get; set; }

	public short OIMonth1 { get; set; }

	public DateTime OIRegisterDate { get; set; }

	public string OIRegisterDatePersian { get; set; }

	public string ordIQuantityDesc { get; set; }

	public decimal? ordIDiscount { get; set; }

	public decimal? ordIDiscountPercent { get; set; }

	public decimal? ordIDiscountI { get; set; }

	public decimal? ordIDiscountIPercent { get; set; }

	public int? ordIPrdUnitId { get; set; }

	public int? ordICurrencyUnitId { get; set; }

	public double? ordIFCR { get; set; }

	public decimal? ordITax { get; set; }

	public decimal? ordITaxIndex { get; set; }

	public bool? ordICalculateTax { get; set; }

	public bool? ordINotVisible { get; set; }

	public double? ordIFCRI { get; set; }

	public bool? ordINotInSum { get; set; }

	public int? ordIOrderView { get; set; }

	public string PrdUnit { get; set; }

	public string PrdUnitEn { get; set; }

	public string PrdPriceCurrencyUnit { get; set; }

	public string PrdPriceCurrencyUnitEn { get; set; }

	public int? OISSerialId { get; set; }

	public string OISSerial { get; set; }

	public DateTime? OISExpDate { get; set; }

	public string OISExpDatePersian { get; set; }

	public decimal? ordTransportation { get; set; }

	public int? ordReferUserId { get; set; }

	public string ReferUserFName { get; set; }

	public string ReferUserLName { get; set; }

	public string OrderOpr { get; set; }

	public string SettlementType { get; set; }

	public string ordNote { get; set; }

	public DateTime? ordDateTime { get; set; }

	public DateTime? ordImportDateTime { get; set; }

	public string ordcmpTitle { get; set; }

	public string ordDeliveryDate { get; set; }

	public string ordDeliveryTime { get; set; }

	public DateTime? ordDeliveryDateTime { get; set; }

	public string prjTitle { get; set; }

	public string prjPostFix { get; set; }

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

	public int? cmpGroupId { get; set; }

	public int? cmpSubGroupId { get; set; }

	public int? cmpGroupIdII { get; set; }

	public int? cmpGroupIdIII { get; set; }

	public int? cmpGroupIdIV { get; set; }

	public string CompanyGroup { get; set; }

	public string CompanySubGroup { get; set; }

	public string CompanyGroupII { get; set; }

	public string CompanyGroupIII { get; set; }

	public string CompanyGroupIV { get; set; }

	public string ordITracing { get; set; }

	public int? ordLinkAccCodeId { get; set; }

	public string ordLinkAccCode { get; set; }

	public int? ordLinkAccOrderId { get; set; }

	public string ordLinkAccOrderNumber { get; set; }

	public int? ordLinkAccVoucherId { get; set; }

	public string ordLinkAccVoucherNumber { get; set; }

	public string ordLinkAccOrderIdStr { get; set; }

	public string CompanyCode { get; set; }

	public string ordSaleCenter { get; set; }

	public int? ordSaleCenterId { get; set; }

	public int? ordIPrdColorId { get; set; }

	public string ordIPrdColor { get; set; }

	public decimal? ordIPriceSum { get; set; }

	public decimal? ordIDiscountISum { get; set; }

	public decimal? ordIDiscountSum { get; set; }

	public decimal? ordITaxSum { get; set; }

	public long? ordDailyCounter { get; set; }

	public double? ordItemsQty { get; set; }

	public decimal? ordItemsDiscount { get; set; }

	public decimal? ordItemsTax { get; set; }

	public decimal? ordItemsPriceWithoutDiscount { get; set; }

	public decimal? ordItemsPriceWithDiscount { get; set; }

	public long? prjNumR { get; set; }

	public string prjNumRef { get; set; }

	public string prjInquiryNum { get; set; }

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

	public string ordISaleCenter { get; set; }

	public int? ordISaleCenterId { get; set; }

	public DateTime? ordIDeliveryDate { get; set; }

	public string ordIDeliveryDatePersian { get; set; }

	public string ordIDeliveryDay { get; set; }

	public DateTime? ordIDeliveryEndDate { get; set; }

	public string ordIDeliveryEndDatePersian { get; set; }

	public string ordIDeliveryEndDay { get; set; }

	public string ordIDeliveryEndTime { get; set; }

	public string ordIDeliveryTime { get; set; }

	public decimal? CompanyMoneyBagRemain { get; set; }

	public string prjSubject { get; set; }

	public string prjDesc { get; set; }

	public string prjDescI { get; set; }

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

	public int? ordICurrencyUnitIdI { get; set; }

	public string ordICurrencyUnitI { get; set; }

	public double? ordICurrencyUnitIRate { get; set; }

	public decimal? ordIPriceCurrencyI { get; set; }

	public decimal? ordITotalPriceCurrencyI { get; set; }

	public decimal? ordIDiscountICurrencyI { get; set; }

	public decimal? ordIDiscountCurrencyI { get; set; }

	public decimal? ordITaxCurrencyI { get; set; }

	public decimal? ordIRoundCurrencyI { get; set; }

	public decimal? ordIRoundPlusCurrencyI { get; set; }

	public decimal? ordIPriceSumCurrencyI { get; set; }

	public decimal? ordIDiscountISumCurrencyI { get; set; }

	public decimal? ordIDiscountSumCurrencyI { get; set; }

	public decimal? ordITaxSumCurrencyI { get; set; }

	public double? ordIPriceCurrencyRate { get; set; }

	public int? ordSettlementTypeId { get; set; }

	public string ordSettlementType { get; set; }

	public int? cmpKind { get; set; }

	public int? ordIWHId { get; set; }

	public string ordIWrhsName { get; set; }

	public string TspOrdIdentify { get; set; }

	public string RefOrderNumber { get; set; }

	public string ReturnOrderNumbers { get; set; }

	public double? ordIPrdWeight { get; set; }

	public double? PrdWeight { get; set; }

	public int? PrdUnitIdI { get; set; }

	public string PrdUnitI { get; set; }

	public double? PrdUnitIRate { get; set; }

	public string ordIPrdUnit { get; set; }

	public int? ordIPrdUnitIdI { get; set; }

	public string ordIPrdUnitI { get; set; }

	public double? ordIPrdUnitIRateResult { get; set; }

	public int? ordIPrdUnitIdII { get; set; }

	public string ordIPrdUnitII { get; set; }

	public double? ordIPrdUnitIIRateResult { get; set; }

	public int? PrdUnitIdII { get; set; }

	public string PrdUnitII { get; set; }

	public double? PrdUnitIIRate { get; set; }
}
