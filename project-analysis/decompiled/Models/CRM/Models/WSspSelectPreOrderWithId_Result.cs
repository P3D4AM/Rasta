using System;

namespace CRM.Models;

public class WSspSelectPreOrderWithId_Result
{
	public int PreOrderID { get; set; }

	public string pordTitle { get; set; }

	public long pordNumber { get; set; }

	public string pordDate { get; set; }

	public int? pordCompanyId { get; set; }

	public int? pordCompanyPersonId { get; set; }

	public int? pordProjectId { get; set; }

	public string pordSubject { get; set; }

	public int? pordItemCount { get; set; }

	public decimal? pordItemsAmount { get; set; }

	public decimal? pordInstallAmount { get; set; }

	public decimal? pordDiscount { get; set; }

	public decimal? pordSumAmount { get; set; }

	public decimal? pordTax { get; set; }

	public decimal? pordTaxIndex { get; set; }

	public bool? pordCalculateTax { get; set; }

	public decimal? pordTotalAmount { get; set; }

	public string pordTotalAmountStr { get; set; }

	public bool? pordIsVerified { get; set; }

	public int? pordVerifierId { get; set; }

	public int? pordVerifierRequestId { get; set; }

	public DateTime? pordVerifiedRegisterDate { get; set; }

	public string pordVerifiedRegisterDatePersian { get; set; }

	public int? pordStatusId { get; set; }

	public bool? pordIsFixed { get; set; }

	public int? pordGuarantyId { get; set; }

	public int? pordPayConditionId { get; set; }

	public int? pordDeliveryTimeId { get; set; }

	public int? pordCreditDurationId { get; set; }

	public string pordSpecialWord { get; set; }

	public string pordDescriptionI { get; set; }

	public string pordDescriptionII { get; set; }

	public int? pordDescriptionId { get; set; }

	public int? pordPrintFormatId { get; set; }

	public int? pordRLogoId { get; set; }

	public int? pordLLogoId { get; set; }

	public string pordSigningI { get; set; }

	public string pordSigningII { get; set; }

	public string pordSigningIII { get; set; }

	public string pordAccountNumberI { get; set; }

	public string pordAccountShabaNumberI { get; set; }

	public string pordAccountNumberII { get; set; }

	public string pordAccountShabaNumberII { get; set; }

	public string pordAddress { get; set; }

	public string pordTelephone { get; set; }

	public string pordFax { get; set; }

	public string pordWebSite { get; set; }

	public string pordEmail { get; set; }

	public int? pordSignatureId { get; set; }

	public string pordImportDate { get; set; }

	public int? pordFirstRegisterUserId { get; set; }

	public string pordFirstRegisterUser { get; set; }

	public int UserId { get; set; }

	public string EditUser { get; set; }

	public int FPId { get; set; }

	public short Month1 { get; set; }

	public DateTime RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	public string pordDay { get; set; }

	public string pordTime { get; set; }

	public string pordDiscountTitle { get; set; }

	public decimal? pordDiscountPercent { get; set; }

	public decimal? pordTransportation { get; set; }

	public int? pordReferUserId { get; set; }

	public decimal? pordRound { get; set; }

	public string pordcmpTitle { get; set; }

	public DateTime? pordDateTime { get; set; }

	public DateTime? pordImportDateTime { get; set; }

	public string pordDeliveryDate { get; set; }

	public DateTime? pordDeliveryDateTime { get; set; }

	public string pordDeliveryTime { get; set; }

	public int? PreOrderOprID { get; set; }

	public string AppType { get; set; }

	public int? LanguageID { get; set; }

	public int? FirstRegisterUserId { get; set; }

	public string FirstRegisterUser { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public DateTime? FirstRegisterDate { get; set; }

	public int? pordVerificationWorkFlowId { get; set; }

	public string pordExpireDate { get; set; }

	public DateTime? pordExpireDateTime { get; set; }

	public int? pordLinkAccPreOrderId { get; set; }

	public string pordLinkAccPreOrderNumber { get; set; }

	public int? pordCurrencyUnitId { get; set; }

	public long? pordNumberRevision { get; set; }

	public string pordNumRef { get; set; }

	public int? pordDeliveryTermId { get; set; }

	public string pordCostSheetIds { get; set; }

	public int? pordParentPreOrderId { get; set; }

	public string pordLinkAccPreOrderIdStr { get; set; }

	public Guid? GUId { get; set; }

	public string pordReferUser { get; set; }

	public string pordDeliveryEndDate { get; set; }

	public DateTime? pordDeliveryEndDateTime { get; set; }

	public string pordDeliveryEndTime { get; set; }

	public int? pordTypeId { get; set; }

	public int? pordDefWHId { get; set; }

	public int? pordDefPrdPriceGroupId { get; set; }

	public int? pordSellerId { get; set; }

	public int? pordEmailUsersInfoId { get; set; }

	public int? pordEmailUserDefaultSettingId { get; set; }

	public string pordDeliveryTerm { get; set; }

	public string pordDefWH { get; set; }

	public string pordDefPrdPriceGroup { get; set; }

	public string pordSeller { get; set; }

	public string pordType { get; set; }

	public int? pordSaleCenterId { get; set; }

	public string pordSaleCenter { get; set; }

	public string CompanyName { get; set; }

	public int? cmpReferUserId { get; set; }

	public int? cmpSuppUserId { get; set; }

	public string pordEditAfterFixInfoJs { get; set; }

	public decimal? RemainpordAmount { get; set; }

	public decimal? sumpordpayAmount { get; set; }

	public decimal? PordITotalDiscountSum { get; set; }

	public decimal? PordITotalPriceSum { get; set; }

	public decimal? PordITotalTaxSum { get; set; }

	public string CompanyPerson { get; set; }

	public string pordCurrencyUnit { get; set; }

	public decimal? PordITotalPriceSumWithoutDiscount { get; set; }

	public string pordLinkAccData { get; set; }

	public bool? IsSentToLinkAcc { get; set; }

	public int? pordCId { get; set; }

	public string pordCenterName { get; set; }

	public string pordStatus { get; set; }

	public string CmpShpIsActive { get; set; }

	public string CmpFOIsActive { get; set; }

	public int? pordSaleCenterReferUserId { get; set; }

	public string pordSaleCenterReferUser { get; set; }
}
