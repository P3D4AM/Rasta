using System;

namespace Mobile.Models;

public class SHPMobspSelectOrderWithID_Result
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

	public DateTime RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	public int? ordVerifierId { get; set; }

	public int? ordSettlementTypeId { get; set; }

	public string ordDay { get; set; }

	public string ordTime { get; set; }

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

	public int? ordVerificationWorkFlowId { get; set; }

	public int? ordLinkAccCodeId { get; set; }

	public string ordLinkAccCode { get; set; }

	public int? ordLinkAccOrderId { get; set; }

	public string ordLinkAccOrderNumber { get; set; }

	public int? ordLinkAccVoucherId { get; set; }

	public string ordLinkAccVoucherNumber { get; set; }

	public string ordLinkAccOrderIdStr { get; set; }

	public int? ordCurrencyUnitId { get; set; }

	public int? ordDeliveryTermId { get; set; }

	public string ordDeliveryEndDate { get; set; }

	public DateTime? ordDeliveryEndDateTime { get; set; }

	public string ordDeliveryEndTime { get; set; }

	public string ordNumRef { get; set; }

	public int? ordDefWHId { get; set; }

	public int? ordDefPrdPriceGroupId { get; set; }

	public int? ordSellerId { get; set; }

	public int? ordEmailUsersInfoId { get; set; }

	public int? ordEmailUserDefaultSettingId { get; set; }

	public int? ordSaleCenterId { get; set; }

	public int? ordDefPayTypeId { get; set; }

	public long? ordDailyCounter { get; set; }

	public DateTime? ordDeadlineDate { get; set; }

	public string ordDeadlineDatePersian { get; set; }

	public int? ordDefaultSettingId { get; set; }

	public int? ordCurrencyUnitIdI { get; set; }

	public string ordCurrencyUnitI { get; set; }

	public bool? IsDecimalI { get; set; }

	public double? ordCurrencyUnitIRate { get; set; }

	public int? ordCompanyNumber { get; set; }

	public string ordCompany { get; set; }

	public string ordCompanyTel { get; set; }

	public string ordCompanyAddress { get; set; }

	public int? ordCompanyGroupIdII { get; set; }

	public string ordCompanyEmail { get; set; }

	public string ordCompanyPerson { get; set; }

	public string ordCompanyPersonAddress { get; set; }

	public string ordCompanyPersonMobile { get; set; }

	public string ordCompanyPersonEmail { get; set; }

	public string ordCompanyPersonEmailII { get; set; }

	public string ordProject { get; set; }

	public string OrderOpr { get; set; }

	public int? DocOprId { get; set; }

	public long? pordNumber { get; set; }

	public string pordDate { get; set; }

	public DateTime? pordDateTime { get; set; }

	public string PreOrderVerifier { get; set; }

	public string ordStatus { get; set; }

	public string ordGuaranty { get; set; }

	public string ordPrintFormat { get; set; }

	public string ordFirstRegisterUser { get; set; }

	public string RegisterUser { get; set; }

	public string ordVerifier { get; set; }

	public string ordSettlementType { get; set; }

	public string ordReferUser { get; set; }

	public string ordVerifierRequest { get; set; }

	public string FirstRegisterUser { get; set; }

	public string ordVerificationWorkFlow { get; set; }

	public string ordDeliveryTerm { get; set; }

	public string ordDefWH { get; set; }

	public string ordDefPrdPriceGroup { get; set; }

	public string ordCurrencyUnit { get; set; }

	public bool? IsDecimal { get; set; }

	public string ordSeller { get; set; }

	public string ordEmailUsersInfo { get; set; }

	public string ordEmailUserDefaultSetting { get; set; }

	public string ordSaleCenter { get; set; }

	public string ordDefPayType { get; set; }

	public string ordDefaultSettingTitle { get; set; }
}
