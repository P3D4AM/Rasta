using System;

namespace CRMIdealApi.ApiModels;

public class ApispSelectOrderWithPrdTracing_Result
{
	public int ApiOrderID { get; set; }

	public int? ApiOrderOprID { get; set; }

	public string ApiOrderOpr { get; set; }

	public int? ApiPreOrderId { get; set; }

	public int? ApiPreOrderVerifierId { get; set; }

	public string ApiPreOrderVerifier { get; set; }

	public string ApiOrdTitle { get; set; }

	public long ApiOrdNumber { get; set; }

	public string ApiOrdDate { get; set; }

	public int ApiOrdCompanyId { get; set; }

	public string ApiOrdCompany { get; set; }

	public int? ApiOrdCompanyPersonId { get; set; }

	public string ApiOrdCompanyPerson { get; set; }

	public int? ApiOrdProjectId { get; set; }

	public string ApiOrdProject { get; set; }

	public string ApiOrdSubject { get; set; }

	public int? ApiOrdItemCount { get; set; }

	public decimal? ApiOrdItemsAmount { get; set; }

	public decimal? ApiOrdInstallAmount { get; set; }

	public decimal? ApiOrdDiscount { get; set; }

	public decimal? ApiOrdSumAmount { get; set; }

	public decimal? ApiOrdTax { get; set; }

	public decimal? ApiOrdTaxIndex { get; set; }

	public bool? ApiOrdCalculateTax { get; set; }

	public decimal? ApiOrdTotalAmount { get; set; }

	public string ApiOrdTotalAmountStr { get; set; }

	public bool? ApiOrdIsVerified { get; set; }

	public DateTime? ApiOrdVerifiedRegisterDate { get; set; }

	public string ApiOrdVerifiedRegisterDatePersian { get; set; }

	public int? ApiOrdStatusId { get; set; }

	public string ApiOrdStatus { get; set; }

	public bool? ApirdIsFixed { get; set; }

	public int? ApiOrdGuarantyId { get; set; }

	public string ApiOrdGuaranty { get; set; }

	public string ApiOrdSpecialWord { get; set; }

	public string ApiOrdDescriptionI { get; set; }

	public string ApiOrdDescriptionII { get; set; }

	public int? ApiOrdPrintFormatId { get; set; }

	public int? ApiOrdRLogoId { get; set; }

	public int? ApiOrdLLogoId { get; set; }

	public string ApiOrdSigningI { get; set; }

	public string ApiOrdSigningII { get; set; }

	public string ApiOrdSigningIII { get; set; }

	public string ApiOrdAccountNumberI { get; set; }

	public string ApiOrdAccountShabaNumberI { get; set; }

	public string ApiOrdAccountNumberII { get; set; }

	public string ApiOrdAccountShabaNumberII { get; set; }

	public int? ApiOrdSignatureId { get; set; }

	public string ApiOrdImportDate { get; set; }

	public int? ApiOrdVerifierId { get; set; }

	public string ApiOrdVerifier { get; set; }

	public int? ApiOrdSettlementTypeId { get; set; }

	public string ApiOrdSettlementType { get; set; }

	public string ApiOrdDay { get; set; }

	public string ApiOrdTime { get; set; }

	public decimal? ApiOrdTransportation { get; set; }

	public int? ApiOrdReferUserId { get; set; }

	public string ApiOrdReferUser { get; set; }

	public decimal? ApiOrdDiscountPercent { get; set; }

	public string ApiOrdDiscountTitle { get; set; }

	public decimal? ApiOrdRound { get; set; }

	public string ApiOrdNote { get; set; }

	public string ApiOrdcmpTitle { get; set; }

	public DateTime? ApiOrdDateTime { get; set; }

	public DateTime? ApiOrdImportDateTime { get; set; }

	public string ApiOrdDeliveryDate { get; set; }

	public DateTime? ApiOrdDeliveryDateTime { get; set; }

	public string ApiOrdDeliveryTime { get; set; }

	public string ApiOrdSerial { get; set; }

	public int? ApiOrdVerifierRequestId { get; set; }

	public int? ApiOrdVerificationWorkFlowId { get; set; }

	public int? ApiOrdLinkAccCodeId { get; set; }

	public string ApiOrdLinkAccCode { get; set; }

	public int? ApiOrdLinkAccOrderId { get; set; }

	public string ApiOrdLinkAccOrderNumber { get; set; }

	public int? ApiOrdLinkAccVoucherId { get; set; }

	public string ApiOrdLinkAccVoucherNumber { get; set; }

	public string ApiOrdLinkAccOrderIdStr { get; set; }

	public int? ApiOrdCurrencyUnitId { get; set; }

	public string ApiOrdCurrencyUnit { get; set; }

	public int? ApiOrdDeliveryTermId { get; set; }

	public string ApiOrdDeliveryTerm { get; set; }

	public string ApiOrdDeliveryEndDate { get; set; }

	public DateTime? ApiOrdDeliveryEndDateTime { get; set; }

	public string ApiOrdDeliveryEndTime { get; set; }

	public string ApiOrdNumRef { get; set; }

	public int? ApiOrdDefWHId { get; set; }

	public string ApiOrdDefWH { get; set; }

	public int? ApiOrdDefPrdPriceGroupId { get; set; }

	public string ApiOrdDefPrdPriceGroup { get; set; }

	public int? ApiOrdSellerId { get; set; }

	public string ApiOrdSeller { get; set; }

	public int? ApiOrdEmailUsersInfoId { get; set; }

	public string ApiOrdEmailUsersInfo { get; set; }

	public int? ApiOrdEmailUserDefaultSettingId { get; set; }

	public string ApiOrdEmailUserDefaultSetting { get; set; }

	public int? ApiOrdSaleCenterId { get; set; }

	public string ApiOrdSaleCenter { get; set; }

	public int? ApiOrdDefPayTypeId { get; set; }

	public int? ApiOrdAutoAddCnvsCmpQuickRegisterDefSettingId { get; set; }

	public string ApiOrdAutoAddCnvsCmpQuickRegisterDefSetting { get; set; }

	public int? ApiOrdAutoAddCnvsStatusId { get; set; }

	public string ApiOrdAutoAddCnvsStatus { get; set; }

	public string ApiOrdAutoAddCnvsDesc { get; set; }

	public long? ApiOrdDailyCounter { get; set; }

	public string ApiOrdLinkAccTransferKey { get; set; }

	public string ApiOrdLinkAccTransferResult { get; set; }

	public DateTime? ApiOrdDeadlineDate { get; set; }

	public string ApiOrdDeadlineDatePersian { get; set; }

	public int? ApiOrdTspSettingId { get; set; }

	public string ApiOrdTspSetting { get; set; }

	public string ApiTspOrdIdentify { get; set; }

	public string ApiTspOrdInno { get; set; }

	public int? ApiTspOrdIns { get; set; }

	public string ApiTspOrdIrtaxid { get; set; }

	public int? ApiTspOrdFt { get; set; }

	public string ApiTspOrdBillid { get; set; }

	public int? ApiTspOrdSetm { get; set; }

	public decimal? ApiTspOrdTax17 { get; set; }

	public DateTime? ApiTspOrdSendDate { get; set; }

	public string ApiTspOrdSendDatePersian { get; set; }

	public DateTime? ApiTspOrdLastEditDate { get; set; }

	public string ApiTspOrdLastEditDatePersian { get; set; }

	public string ApiTspOrdUID { get; set; }

	public string ApiTspOrdReferenceNumber { get; set; }

	public string ApiTspOrdStatus { get; set; }

	public string ApiTspOrdMessage { get; set; }

	public string ApiTspOrdCdcn { get; set; }

	public DateTime? ApiTspOrdCdcd { get; set; }

	public string ApiTspOrdCdcdPersian { get; set; }

	public int? ApiOrdDefaultSettingId { get; set; }

	public string ApiOrdDefaultSetting { get; set; }

	public double? ApiOrdItemsQty { get; set; }

	public decimal? ApiOrdItemsDiscount { get; set; }

	public decimal? ApiOrdItemsTax { get; set; }

	public string ApiOrdDeliveryDay { get; set; }

	public string ApiOrdDeliveryEndDay { get; set; }

	public string ApiTspOrdStatusResult { get; set; }

	public bool? ApiOrdLinkAccConflict { get; set; }

	public DateTime? ApiOrdLinkAccFirstTransferDate { get; set; }

	public DateTime? ApiOrdLinkAccLastTransferDate { get; set; }

	public string ApiBuyOrderIds { get; set; }

	public decimal? ApiOrdGrossProfit { get; set; }

	public decimal? ApiOrdMoneySleep { get; set; }

	public decimal? ApiOrdSaleNetProfit { get; set; }

	public decimal? ApiOrdSumOtherComm { get; set; }

	public decimal? ApiOrdSumSaleComm { get; set; }

	public decimal? ApiOrdSumBuyComm { get; set; }

	public decimal? ApiOrdSumMangComm { get; set; }

	public decimal? ApiOrdNetProfit { get; set; }

	public int? ApiOrdCurrencyUnitIdI { get; set; }

	public string ApiOrdCurrencyUnitI { get; set; }

	public double? ApiOrdCurrencyUnitIRate { get; set; }

	public decimal? ApiOrdItemsAmountCurrencyI { get; set; }

	public decimal? ApiOrdInstallAmountCurrencyI { get; set; }

	public decimal? ApiOrdDiscountCurrencyI { get; set; }

	public decimal? ApiOrdSumAmountCurrencyI { get; set; }

	public decimal? ApiOrdTaxCurrencyI { get; set; }

	public decimal? ApiOrdTotalAmountCurrencyI { get; set; }

	public string ApiOrdTotalAmountCurrencyIStr { get; set; }

	public decimal? ApiOrdTransportationCurrencyI { get; set; }

	public decimal? ApiOrdRoundCurrencyI { get; set; }

	public decimal? ApiOrdItemsDiscountCurrencyI { get; set; }

	public decimal? ApiOrdItemsTaxCurrencyI { get; set; }

	public decimal? ApiOrdGrossProfitCurrencyI { get; set; }

	public decimal? ApiOrdMoneySleepCurrencyI { get; set; }

	public decimal? ApiOrdSaleNetProfitCurrencyI { get; set; }

	public decimal? ApiOrdSumOtherCommCurrencyI { get; set; }

	public decimal? ApiOrdSumSaleCommCurrencyI { get; set; }

	public decimal? ApiOrdSumBuyCommCurrencyI { get; set; }

	public decimal? ApiOrdSumMangCommCurrencyI { get; set; }

	public decimal? ApiOrdNetProfitCurrencyI { get; set; }

	public string ApiOrdLinkAccData { get; set; }

	public string ApiOrdEditAfterFixInfoJs { get; set; }

	public string ApiOrdCompanyPersonIds { get; set; }

	public int? ApiOrdGroupId { get; set; }

	public string ApiOrdGroup { get; set; }

	public string ApiTspOrdSbc { get; set; }

	public string ApiTspOrdScln { get; set; }

	public string ApiTspOrdScc { get; set; }

	public string ApiTspOrdCrn { get; set; }

	public decimal? ApiTspOrdInsp { get; set; }

	public int? ApiOrdShpCartPayTypeId { get; set; }

	public int? ApiOrdSaleAreaId { get; set; }

	public string ApiOrdSaleArea { get; set; }

	public int? ApiOrdRefOrderId { get; set; }

	public int? ApiOrdCenterId { get; set; }

	public string ApiOrdCenterName { get; set; }

	public int ApiEditUserId { get; set; }

	public string ApiEditUser { get; set; }

	public int ApiFPId { get; set; }

	public short ApiMonth1 { get; set; }

	public DateTime ApiRegisterDate { get; set; }

	public string ApiRegisterDatePersian { get; set; }

	public int? ApiLanguageID { get; set; }

	public int? ApiFirstRegisterUserId { get; set; }

	public string ApiFirstRegisterUser { get; set; }

	public string ApiFirstRegisterDatePersian { get; set; }

	public DateTime? ApiFirstRegisterDate { get; set; }

	public string ApiAppType { get; set; }

	public string ApiOrdPrintFormat { get; set; }
}
