using System;

namespace CRM.Models;

public class WSspSelectOrdersInMode_Result
{
	public int OrderID { get; set; }

	public int? OrderOprID { get; set; }

	public int? PreOrderId { get; set; }

	public int? PreOrderVerifierId { get; set; }

	public string ordTitle { get; set; }

	public long ordNumber { get; set; }

	public string ordDate { get; set; }

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

	public DateTime? ordVerifiedRegisterDate { get; set; }

	public string ordVerifiedRegisterDatePersian { get; set; }

	public int? ordStatusId { get; set; }

	public bool? ordIsFixed { get; set; }

	public int? ordGuarantyId { get; set; }

	public string ordSpecialWord { get; set; }

	public string ordDescriptionI { get; set; }

	public string ordDescriptionII { get; set; }

	public int? ordDescriptionId { get; set; }

	public int? ordPrintFormatId { get; set; }

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

	public int UserId { get; set; }

	public int FPId { get; set; }

	public short Month1 { get; set; }

	public DateTime RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	public int? ordVerifierId { get; set; }

	public int? ordSettlementTypeId { get; set; }

	public string ordDay { get; set; }

	public string ordTime { get; set; }

	public Guid? GUId { get; set; }

	public decimal? ordTransportation { get; set; }

	public int? ordReferUserId { get; set; }

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

	public int? LanguageID { get; set; }

	public int? FirstRegisterUserId { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public DateTime? FirstRegisterDate { get; set; }

	public int? CompanyNumber { get; set; }

	public string CompanyTitle { get; set; }

	public string CompanyName { get; set; }

	public string CompanyTel { get; set; }

	public string CompanyAddress { get; set; }

	public string CompanyPerson { get; set; }

	public string CompanyPersonMobile { get; set; }

	public string CompanyprsEmail { get; set; }

	public string CompanyprsEmailII { get; set; }

	public string ProjectTitle { get; set; }

	public string ordStatus { get; set; }

	public string Guaranty { get; set; }

	public string PrintFormat { get; set; }

	public string UserName { get; set; }

	public string FirstRegisterUserName { get; set; }

	public string ReferUserName { get; set; }

	public string VerifierFName { get; set; }

	public string OrderOpr { get; set; }

	public string SettlementType { get; set; }

	public long? pordNumber { get; set; }

	public int? pordVerifierId { get; set; }

	public string PordVerifierFName { get; set; }

	public int? ordVerificationWorkFlowId { get; set; }

	public int? ordLinkAccCodeId { get; set; }

	public string ordLinkAccCode { get; set; }

	public int? ordLinkAccOrderId { get; set; }

	public string ordLinkAccOrderNumber { get; set; }

	public int? ordLinkAccVoucherId { get; set; }

	public string ordLinkAccVoucherNumber { get; set; }

	public int? OrderOprType { get; set; }

	public int? ordCurrencyUnitId { get; set; }

	public string ordCurrencyUnit { get; set; }

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

	public int? ordSaleCenterId { get; set; }

	public string ordSaleCenter { get; set; }

	public string ordLinkAccOrderIdStr { get; set; }

	public int? ordDefPayTypeId { get; set; }

	public string ordDefPayType { get; set; }

	public long? ordDailyCounter { get; set; }

	public DateTime? ordDeadlineDate { get; set; }

	public string ordDeadlineDatePersian { get; set; }

	public string TspOrdIdentify { get; set; }

	public string TspOrdInno { get; set; }

	public int? TspOrdIns { get; set; }

	public DateTime? TspOrdSendDate { get; set; }

	public string TspOrdSendDatePersian { get; set; }

	public DateTime? TspOrdLastEditDate { get; set; }

	public string TspOrdLastEditDatePersian { get; set; }

	public string TspOrdUID { get; set; }

	public string TspOrdReferenceNumber { get; set; }

	public string TspOrdStatus { get; set; }

	public int? TspInty { get; set; }

	public int? TspInp { get; set; }

	public int? TspIns { get; set; }

	public bool? CalculateTaxItem { get; set; }

	public decimal? TaxIndexItem { get; set; }

	public string TspOrdStatusResult { get; set; }

	public bool? ordLinkAccConflict { get; set; }

	public string CompanyProvince { get; set; }

	public string CompanyCity { get; set; }

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

	public string ordLinkAccData { get; set; }

	public int? cmpReferUserId { get; set; }

	public int? cmpSuppUserId { get; set; }

	public string ordEditAfterFixInfoJs { get; set; }

	public string ordCompanyPersonIds { get; set; }

	public string ordCompanyPersons { get; set; }

	public int? ordGroupId { get; set; }

	public string ordGroup { get; set; }

	public int? ordCId { get; set; }

	public string ordCenterName { get; set; }

	public int? ordSaleAreaId { get; set; }

	public string ordSaleAreaName { get; set; }

	public int? ordRefOrderId { get; set; }

	public long? ordRefOrderNumber { get; set; }

	public string ordRefOrderOpr { get; set; }

	public int? TspOrdSendTypeId { get; set; }
}
