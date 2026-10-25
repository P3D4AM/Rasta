using System;

namespace CRM.Models;

public class WSspSelectOrderByPordId_Result
{
	public int OrderID { get; set; }

	public int? OrderOprID { get; set; }

	public string OrderOpr { get; set; }

	public int? PreOrderId { get; set; }

	public int? PreOrderVerifierId { get; set; }

	public string PreOrderVerifier { get; set; }

	public string ordTitle { get; set; }

	public long ordNumber { get; set; }

	public string ordDate { get; set; }

	public int ordCompanyId { get; set; }

	public string ordCompany { get; set; }

	public int? ordCompanyNumber { get; set; }

	public int? ordCompanyPersonId { get; set; }

	public string ordCompanyPerson { get; set; }

	public int? ordProjectId { get; set; }

	public string ordProject { get; set; }

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

	public DateTime? ordVerifiedRegisterDate { get; set; }

	public string ordVerifiedRegisterDatePersian { get; set; }

	public int? ordStatusId { get; set; }

	public string ordStatus { get; set; }

	public bool? ordIsFixed { get; set; }

	public int? ordGuarantyId { get; set; }

	public string ordGuaranty { get; set; }

	public string ordSpecialWord { get; set; }

	public string ordDescriptionI { get; set; }

	public string ordDescriptionII { get; set; }

	public int? ordDescriptionId { get; set; }

	public int? ordPrintFormatId { get; set; }

	public string ordPrintFormat { get; set; }

	public int? ordRLogoId { get; set; }

	public int? ordLLogoId { get; set; }

	public string ordSigningI { get; set; }

	public string ordSigningII { get; set; }

	public string ordSigningIII { get; set; }

	public string ordAccountNumberI { get; set; }

	public string ordAccountShabaNumberI { get; set; }

	public string ordAccountNumberII { get; set; }

	public string ordAccountShabaNumberII { get; set; }

	public int? ordSignatureId { get; set; }

	public string ordImportDate { get; set; }

	public int? ordFirstRegisterUserId { get; set; }

	public string ordFirstRegisterUser { get; set; }

	public int UserId { get; set; }

	public string EditUser { get; set; }

	public int FPId { get; set; }

	public short Month1 { get; set; }

	public DateTime RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	public int? ordVerifierId { get; set; }

	public string ordVerifier { get; set; }

	public int? ordSettlementTypeId { get; set; }

	public string ordSettlementType { get; set; }

	public string ordDay { get; set; }

	public string ordTime { get; set; }

	public decimal? ordTransportation { get; set; }

	public int? ordReferUserId { get; set; }

	public string ordReferUser { get; set; }

	public decimal? ordDiscountPercent { get; set; }

	public string ordDiscountTitle { get; set; }

	public decimal? ordRound { get; set; }

	public string ordNote { get; set; }

	public string ordcmpTitle { get; set; }

	public DateTime? ordDateTime { get; set; }

	public DateTime? ordImportDateTime { get; set; }

	public string ordDeliveryDate { get; set; }

	public DateTime? ordDeliveryDateTime { get; set; }

	public string ordDeliveryTime { get; set; }

	public string ordSerial { get; set; }

	public string AppType { get; set; }

	public int? ordVerifierRequestId { get; set; }

	public string ordVerifierRequest { get; set; }

	public int? LanguageID { get; set; }

	public int? FirstRegisterUserId { get; set; }

	public string FirstRegisterUser { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public DateTime? FirstRegisterDate { get; set; }

	public int? ordVerificationWorkFlowId { get; set; }

	public string ordVerificationWorkFlow { get; set; }

	public int? ordLinkAccCodeId { get; set; }

	public string ordLinkAccCode { get; set; }

	public int? ordLinkAccOrderId { get; set; }

	public string ordLinkAccOrderNumber { get; set; }

	public int? ordLinkAccVoucherId { get; set; }

	public string ordLinkAccVoucherNumber { get; set; }

	public string ordLinkAccOrderIdStr { get; set; }

	public int? ordCurrencyUnitId { get; set; }

	public string ordCurrencyUnit { get; set; }

	public int? ordDeliveryTermId { get; set; }

	public string ordDeliveryTerm { get; set; }

	public string ordDeliveryEndDate { get; set; }

	public DateTime? ordDeliveryEndDateTime { get; set; }

	public string ordDeliveryEndTime { get; set; }

	public string ordNumRef { get; set; }

	public int? ordDefWHId { get; set; }

	public string ordDefWH { get; set; }

	public int? ordDefPrdPriceGroupId { get; set; }

	public string ordDefPrdPriceGroup { get; set; }

	public int? ordSellerId { get; set; }

	public string ordSeller { get; set; }

	public int? ordEmailUsersInfoId { get; set; }

	public int? ordEmailUserDefaultSettingId { get; set; }

	public int? ordSaleCenterId { get; set; }

	public string ordSaleCenter { get; set; }

	public int? ordDefPayTypeId { get; set; }

	public string ordDefPayType { get; set; }

	public long? ordDailyCounter { get; set; }

	public string ordLinkAccTransferKey { get; set; }

	public string ordLinkAccTransferResult { get; set; }

	public DateTime? ordDeadlineDate { get; set; }

	public string ordDeadlineDatePersian { get; set; }

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

	public string TspOrdCdcn { get; set; }

	public DateTime? TspOrdCdcd { get; set; }

	public string TspOrdCdcdPersian { get; set; }

	public int? ordDefaultSettingId { get; set; }

	public string ordDefaultSetting { get; set; }

	public double? ordItemsQty { get; set; }

	public decimal? ordItemsDiscount { get; set; }

	public decimal? ordItemsTax { get; set; }

	public string ordDeliveryDay { get; set; }

	public string ordDeliveryEndDay { get; set; }

	public string TspOrdStatusResult { get; set; }

	public bool? ordLinkAccConflict { get; set; }

	public DateTime? ordLinkAccFirstTransferDate { get; set; }

	public DateTime? ordLinkAccLastTransferDate { get; set; }

	public string BuyOrderIds { get; set; }

	public decimal? ordGrossProfit { get; set; }

	public decimal? ordMoneySleep { get; set; }

	public decimal? ordSaleNetProfit { get; set; }

	public decimal? ordSumOtherComm { get; set; }

	public decimal? ordSumSaleComm { get; set; }

	public decimal? ordSumBuyComm { get; set; }

	public decimal? ordSumMangComm { get; set; }

	public decimal? ordNetProfit { get; set; }

	public int? ordCurrencyUnitIdI { get; set; }

	public string ordCurrencyUnitI { get; set; }

	public double? ordCurrencyUnitIRate { get; set; }

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

	public string ordLinkAccData { get; set; }

	public string ordEditAfterFixInfoJs { get; set; }

	public string ordCompanyPersonIds { get; set; }

	public int? ordGroupId { get; set; }

	public string ordGroup { get; set; }

	public int? ordCId { get; set; }

	public string ordCenterName { get; set; }

	public string ordCenterCode { get; set; }

	public string TspOrdSbc { get; set; }

	public string TspOrdScln { get; set; }

	public string TspOrdScc { get; set; }

	public string TspOrdCrn { get; set; }

	public int? ordShpCartPayTypeId { get; set; }

	public int? ordSaleAreaId { get; set; }

	public string ordSaleArea { get; set; }

	public int? ordRefOrderId { get; set; }

	public decimal? TspOrdInsp { get; set; }

	public string DocIds { get; set; }

	public int OrderItemID { get; set; }

	public int ordIPrdId { get; set; }

	public string ordIPrdName { get; set; }

	public string ordIPrdCode { get; set; }

	public string ordIPrdSGroup { get; set; }

	public string ordIPrdFGroup { get; set; }

	public double? ordIQuantity { get; set; }

	public decimal? ordIPrice { get; set; }

	public decimal? ordITotalPrice { get; set; }

	public string ordIDescription { get; set; }

	public string ordIQuantityDesc { get; set; }

	public decimal? ordIDiscountI { get; set; }

	public decimal? ordIDiscount { get; set; }

	public decimal? ordIDiscountPercent { get; set; }

	public decimal? ordIDiscountIPercent { get; set; }

	public int? ordIPrdUnitId { get; set; }

	public string ordIPrdUnit { get; set; }

	public int? ordICurrencyUnitId { get; set; }

	public string ordICurrencyUnit { get; set; }

	public int? ordIOrderView { get; set; }

	public double? ordIFCR { get; set; }

	public decimal? ordITax { get; set; }

	public decimal? ordITaxIndex { get; set; }

	public bool? ordICalculateTax { get; set; }

	public bool? ordINotVisible { get; set; }

	public double? ordIFCRI { get; set; }

	public bool? ordINotInSum { get; set; }

	public int? ordIWHId { get; set; }

	public string ordIWHName { get; set; }

	public decimal? ordIRound { get; set; }

	public decimal? ordIRoundPlus { get; set; }

	public double? ordIPricePartRate { get; set; }

	public decimal? ordIPricePartI { get; set; }

	public decimal? ordIPricePartII { get; set; }

	public int? ordILinkAccItemId { get; set; }

	public int? ordIPrdPriceGroupID { get; set; }

	public string ordIPrdPriceGroup { get; set; }

	public string ordITracing { get; set; }

	public string ordILinkAccItemIdStr { get; set; }

	public decimal? ordIPriceSum { get; set; }

	public decimal? ordIDiscountISum { get; set; }

	public decimal? ordIDiscountSum { get; set; }

	public decimal? ordITaxSum { get; set; }

	public int? ordIDeliveryTermId { get; set; }

	public string ordIDeliveryTerm { get; set; }

	public DateTime? ordIDeliveryDate { get; set; }

	public string ordIDeliveryDatePersian { get; set; }

	public string ordILinkAccWHIdStr { get; set; }

	public DateTime? ordIValidityExpireDate { get; set; }

	public string ordIValidityExpireDatePersian { get; set; }

	public double? ordIQuantityTotal { get; set; }

	public int? ordIPrdUnitIdI { get; set; }

	public string ordIPrdUnitI { get; set; }

	public double? ordIPrdUnitIRateResult { get; set; }

	public int? ordIPrdColorId { get; set; }

	public string ordIPrdColor { get; set; }

	public int? ordIPrdValidityCountingNum { get; set; }

	public int? ordIPrdValidityCountingMin { get; set; }

	public string ordIPrdNickname { get; set; }

	public string ordIDiscountDesc { get; set; }

	public decimal? TspOrdICfee { get; set; }

	public string TspOrdICut { get; set; }

	public decimal? TspOrdIExr { get; set; }

	public string TspOrdIOdt { get; set; }

	public decimal? TspOrdIOdr { get; set; }

	public decimal? TspOrdIOdam { get; set; }

	public string TspOrdIOlt { get; set; }

	public decimal? TspOrdIOlr { get; set; }

	public decimal? TspOrdIOlam { get; set; }

	public decimal? TspOrdIConsfee { get; set; }

	public decimal? TspOrdISpro { get; set; }

	public decimal? TspOrdIBros { get; set; }

	public decimal? TspOrdICop { get; set; }

	public decimal? TspOrdIVop { get; set; }

	public double? TspOrdINw { get; set; }

	public decimal? TspOrdISsrv { get; set; }

	public decimal? TspOrdISscv { get; set; }

	public string ordIDeliveryTime { get; set; }

	public string ordIDeliveryDay { get; set; }

	public DateTime? ordIDeliveryEndDate { get; set; }

	public string ordIDeliveryEndDatePersian { get; set; }

	public string ordIDeliveryEndTime { get; set; }

	public string ordIDeliveryEndDay { get; set; }

	public decimal? ordIPrdAutoCalcRate { get; set; }

	public decimal? ordIPrdAutoCalcInflationRateInfo { get; set; }

	public string ordIDescriptionI { get; set; }

	public int? ordIDeliveryUserId { get; set; }

	public string ordIDeliveryUser { get; set; }

	public bool? ordIDeActiveModuleInReg { get; set; }

	public DateTime? ordILinkAccFirstTransferDate { get; set; }

	public DateTime? ordILinkAccLastTransferDate { get; set; }

	public decimal? TspOrdIPspd { get; set; }

	public decimal? TspOrdICui { get; set; }

	public int? PreOrderItemId { get; set; }

	public string BuyOrderItemIds { get; set; }

	public int? ordIDiscountCodeId { get; set; }

	public int? ordIDiscountCodeUserId { get; set; }

	public string ordIDiscountCodeUser { get; set; }

	public DateTime? ordIDiscountCodeRegisterDate { get; set; }

	public string ordIDiscountCodeRegisterDatePersian { get; set; }

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

	public string ordILinkAccData { get; set; }

	public int? ordISaleCenterId { get; set; }

	public string ordISaleCenter { get; set; }

	public int? ordICId { get; set; }

	public string ordICenterName { get; set; }

	public string ordICenterCode { get; set; }

	public string TspOrdIBsrn { get; set; }

	public int? ordILinkedParentItemId { get; set; }

	public int? ordILinkedParentPrdId { get; set; }

	public double? ordIPriceCurrencyRate { get; set; }

	public int? ordIRefOrderItemId { get; set; }

	public double? ordIPrdWeight { get; set; }

	public int? ordILinkAccSettingDBId { get; set; }

	public string DocItemIds { get; set; }

	public int? ordIPrdUnitIdII { get; set; }

	public string ordIPrdUnitII { get; set; }

	public double? ordIPrdUnitIIRateResult { get; set; }
}
