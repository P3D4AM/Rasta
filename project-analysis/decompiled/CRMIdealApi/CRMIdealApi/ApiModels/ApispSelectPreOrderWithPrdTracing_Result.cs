using System;

namespace CRMIdealApi.ApiModels;

public class ApispSelectPreOrderWithPrdTracing_Result
{
	public int ApiPreOrderID { get; set; }

	public string ApiPordTitle { get; set; }

	public long ApiPordNumber { get; set; }

	public string ApiPordDate { get; set; }

	public int? ApiPordCompanyId { get; set; }

	public string ApiPordCompany { get; set; }

	public int? ApiPordCompanyPersonId { get; set; }

	public string ApiPordCompanyPerson { get; set; }

	public int? ApiPordProjectId { get; set; }

	public string ApiPordProject { get; set; }

	public string ApiPordSubject { get; set; }

	public int? ApiPordItemCount { get; set; }

	public decimal? ApiPordItemsAmount { get; set; }

	public decimal? ApiPordInstallAmount { get; set; }

	public decimal? ApiPordDiscount { get; set; }

	public decimal? ApiPordSumAmount { get; set; }

	public decimal? ApiPordTax { get; set; }

	public decimal? ApiPordTaxIndex { get; set; }

	public bool? ApiPordCalculateTax { get; set; }

	public decimal? ApiPordTotalAmount { get; set; }

	public string ApiPordTotalAmountStr { get; set; }

	public bool? ApiPordIsVerified { get; set; }

	public int? ApiPordVerifierId { get; set; }

	public string ApiPordVerifier { get; set; }

	public int? ApiPordVerifierRequestId { get; set; }

	public string ApiPordVerifierRequest { get; set; }

	public DateTime? ApiPordVerifiedRegisterDate { get; set; }

	public string ApiPordVerifiedRegisterDatePersian { get; set; }

	public int? ApiPordStatusId { get; set; }

	public string ApiPordStatus { get; set; }

	public bool? ApiPordIsFixed { get; set; }

	public int? ApiPordGuarantyId { get; set; }

	public string ApiPordGuaranty { get; set; }

	public int? ApiPordPayConditionId { get; set; }

	public int? ApiPordDeliveryTimeId { get; set; }

	public int? ApiPordCreditDurationId { get; set; }

	public string ApiPordSpecialWord { get; set; }

	public string ApiPordDescriptionI { get; set; }

	public string ApiPordDescriptionII { get; set; }

	public int? ApiPordDescriptionId { get; set; }

	public int? ApiPordPrintFormatId { get; set; }

	public string ApiPordPrintFormat { get; set; }

	public int? ApiPordRLogoId { get; set; }

	public int? ApiPordLLogoId { get; set; }

	public string ApiordSigningI { get; set; }

	public string ApiordSigningII { get; set; }

	public string ApiordSigningIII { get; set; }

	public string ApiordAccountNumberI { get; set; }

	public string ApiordAccountShabaNumberI { get; set; }

	public string ApiordAccountNumberII { get; set; }

	public string ApiordAccountShabaNumberII { get; set; }

	public string ApiordAddress { get; set; }

	public string ApiordTelephone { get; set; }

	public string ApiordFax { get; set; }

	public string ApiordWebSite { get; set; }

	public string ApiordEmail { get; set; }

	public int? ApiordSignatureId { get; set; }

	public string ApiordImportDate { get; set; }

	public string ApiordDay { get; set; }

	public string ApiordTime { get; set; }

	public string ApiordDiscountTitle { get; set; }

	public decimal? ApiordDiscountPercent { get; set; }

	public decimal? ApiordTransportation { get; set; }

	public int? ApiordReferUserId { get; set; }

	public string ApiPordReferUser { get; set; }

	public decimal? ApiPordRound { get; set; }

	public string ApiPordcmpTitle { get; set; }

	public DateTime? ApiPordDateTime { get; set; }

	public DateTime? ApiPordImportDateTime { get; set; }

	public string ApiPordDeliveryDate { get; set; }

	public DateTime? ApiPordDeliveryDateTime { get; set; }

	public string ApiPordDeliveryTime { get; set; }

	public int? ApiPreOrderOprID { get; set; }

	public string ApiPreOrderOpr { get; set; }

	public int? ApiPordVerificationWorkFlowId { get; set; }

	public string ApiPordExpireDate { get; set; }

	public DateTime? ApiPordExpireDateTime { get; set; }

	public int? ApiPordLinkAccPreOrderId { get; set; }

	public string ApiPordLinkAccPreOrderNumber { get; set; }

	public int? ApiPordCurrencyUnitId { get; set; }

	public string ApiPordCurrencyUnit { get; set; }

	public long? ApiPordNumberRevision { get; set; }

	public int? ApiPordDeliveryTermId { get; set; }

	public string ApiPordDeliveryTerm { get; set; }

	public string ApiPordCostSheetIds { get; set; }

	public int? ApiPordParentPreOrderId { get; set; }

	public string ApiPordDeliveryEndDate { get; set; }

	public DateTime? ApiPordDeliveryEndDateTime { get; set; }

	public string ApiPordDeliveryEndTime { get; set; }

	public string ApiPordNumRef { get; set; }

	public int? ApiPordTypeId { get; set; }

	public string ApiPordType { get; set; }

	public int? ApiPordDefWHId { get; set; }

	public string ApiPordDefWH { get; set; }

	public int? ApiPordDefPrdPriceGroupId { get; set; }

	public string ApiPordDefPrdPriceGroup { get; set; }

	public int? ApiPordSellerId { get; set; }

	public string ApiPordSeller { get; set; }

	public int? ApiPordEmailUsersInfoId { get; set; }

	public string ApiPordEmailUsersInfo { get; set; }

	public int? ApiPordEmailUserDefaultSettingId { get; set; }

	public string ApiPordEmailUserDefaultSetting { get; set; }

	public string ApiPordLinkAccPreOrderIdStr { get; set; }

	public int? ApiPordSaleCenterId { get; set; }

	public string ApiPordSaleCenter { get; set; }

	public int? ApiPordDefPayTypeId { get; set; }

	public int? ApiPordAutoAddCnvsCmpQuickRegisterDefSettingId { get; set; }

	public string ApiPordAutoAddCnvsCmpQuickRegisterDefSetting { get; set; }

	public int? ApiPordAutoAddCnvsStatusId { get; set; }

	public string ApiPordAutoAddCnvsStatus { get; set; }

	public string ApiPordAutoAddCnvsDesc { get; set; }

	public DateTime? ApiPordDeadlineDate { get; set; }

	public string ApiPordDeadlineDatePersian { get; set; }

	public int? ApiPordDefaultSettingId { get; set; }

	public string ApiPordDefaultSetting { get; set; }

	public double? ApiPordItemsQty { get; set; }

	public decimal? ApiPordItemsDiscount { get; set; }

	public decimal? ApiPordItemsTax { get; set; }

	public string ApiPordDeliveryDay { get; set; }

	public string ApiPordDeliveryEndDay { get; set; }

	public DateTime? ApiPordLinkAccFirstTransferDate { get; set; }

	public DateTime? ApiPordLinkAccLastTransferDate { get; set; }

	public int? ApiPordCurrencyUnitIdI { get; set; }

	public string ApiPordCurrencyUnitI { get; set; }

	public double? ApiPordCurrencyUnitIRate { get; set; }

	public decimal? ApiPordItemsAmountCurrencyI { get; set; }

	public decimal? ApiPordInstallAmountCurrencyI { get; set; }

	public decimal? ApiPordDiscountCurrencyI { get; set; }

	public decimal? ApiPordSumAmountCurrencyI { get; set; }

	public decimal? ApiPordTaxCurrencyI { get; set; }

	public decimal? ApiPordTotalAmountCurrencyI { get; set; }

	public string ApiPordTotalAmountCurrencyIStr { get; set; }

	public decimal? ApiPordTransportationCurrencyI { get; set; }

	public decimal? ApiPordRoundCurrencyI { get; set; }

	public decimal? ApiPordItemsDiscountCurrencyI { get; set; }

	public decimal? ApiPordItemsTaxCurrencyI { get; set; }

	public string ApiPordLinkAccData { get; set; }

	public string ApiPordEditAfterFixInfoJs { get; set; }

	public int? ApiPordShpCartPayTypeId { get; set; }

	public int? ApiPordChangeStatusUserId { get; set; }

	public string ApiPordChangeStatusUser { get; set; }

	public DateTime? ApiPordChangeStatusDate { get; set; }

	public string ApiPordChangeStatusDatePersian { get; set; }

	public int? ApiPordSaleAreaId { get; set; }

	public string ApiPordSaleArea { get; set; }

	public int? ApiPordCenterId { get; set; }

	public string ApiPordCenterName { get; set; }

	public int ApiEditUserId { get; set; }

	public string ApiEditUser { get; set; }

	public DateTime ApiRegisterDate { get; set; }

	public string ApiRegisterDatePersian { get; set; }

	public string ApiAppType { get; set; }

	public int? ApiLanguageID { get; set; }

	public int? ApiFirstRegisterUserId { get; set; }

	public string ApiFirstRegisterUser { get; set; }

	public string ApiFirstRegisterDatePersian { get; set; }

	public DateTime? ApiFirstRegisterDate { get; set; }

	public int? ApiPordFirstRegisterUserId { get; set; }

	public string ApiPordFirstRegisterUser { get; set; }

	public int ApiFPId { get; set; }

	public short ApiMonth1 { get; set; }
}
