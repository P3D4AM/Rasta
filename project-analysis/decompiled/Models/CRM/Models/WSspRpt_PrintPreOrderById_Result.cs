using System;

namespace CRM.Models;

public class WSspRpt_PrintPreOrderById_Result
{
	public int? rptUserId { get; set; }

	public string rptDate { get; set; }

	public string rptDay { get; set; }

	public long pordNumber { get; set; }

	public string pordDate { get; set; }

	public int? PreOrderOprId { get; set; }

	public string PreOrderOpr { get; set; }

	public string CmpTitle { get; set; }

	public string Company { get; set; }

	public string pordcmpTitle { get; set; }

	public string CompanyTel { get; set; }

	public string CompanyFax { get; set; }

	public int? CompanyNumber { get; set; }

	public string CompanyCode { get; set; }

	public string CompanyCountry { get; set; }

	public string CompanyProvince { get; set; }

	public string CompanyCity { get; set; }

	public string CompanyAddress { get; set; }

	public string CompanyZipcode { get; set; }

	public string cmpRegistrationNumber { get; set; }

	public string cmpEconomicCode { get; set; }

	public string cmpNationalCode { get; set; }

	public string Person { get; set; }

	public string PersonJob { get; set; }

	public string PersonDepartment { get; set; }

	public string PersonTel { get; set; }

	public string PersonFax { get; set; }

	public string PersonMobile { get; set; }

	public string prsFatherName { get; set; }

	public string prsIdentityNumber { get; set; }

	public string prsNationalCode { get; set; }

	public string prsBirthPlace { get; set; }

	public string prsBirthDate { get; set; }

	public string prsEmail { get; set; }

	public string ProjectTitle { get; set; }

	public string prjTitle { get; set; }

	public string prjPostFix { get; set; }

	public string Guaranty { get; set; }

	public string DeliveryTime { get; set; }

	public string PayCondition { get; set; }

	public string CreditDuration { get; set; }

	public decimal? pordDiscount { get; set; }

	public decimal? pordDiscountPercent { get; set; }

	public string pordDiscountTitle { get; set; }

	public decimal? pordTax { get; set; }

	public decimal? pordTaxIndex { get; set; }

	public bool? pordCalculateTax { get; set; }

	public decimal? pordTransportation { get; set; }

	public decimal? pordRound { get; set; }

	public string PrintFormat { get; set; }

	public string Status { get; set; }

	public int? pordVerifierRequestId { get; set; }

	public string ReferUserFName { get; set; }

	public string ReferUserLName { get; set; }

	public string ReferUserDirectTel { get; set; }

	public string ReferUserTelDesc { get; set; }

	public string VerifierFName { get; set; }

	public string VerifierLName { get; set; }

	public string pordTitle { get; set; }

	public string pordSubject { get; set; }

	public string pordDescriptionI { get; set; }

	public string pordDescriptionII { get; set; }

	public string pordSpecialWord { get; set; }

	public string pordDeliveryDate { get; set; }

	public string pordDeliveryTime { get; set; }

	public DateTime? pordDeliveryDateTime { get; set; }

	public string pordAccountNumberI { get; set; }

	public string pordAccountShabaNumberI { get; set; }

	public string pordAccountNumberII { get; set; }

	public string pordAccountShabaNumberII { get; set; }

	public string pordEmail { get; set; }

	public string pordWebSite { get; set; }

	public string pordTelephone { get; set; }

	public string pordFax { get; set; }

	public string pordAddress { get; set; }

	public string pordSigningI { get; set; }

	public string pordSigningII { get; set; }

	public string pordSigningIII { get; set; }

	public int? pordItemCount { get; set; }

	public int? PreOrderItemCount { get; set; }

	public decimal? pordItemsAmount { get; set; }

	public decimal? pordInstallAmount { get; set; }

	public decimal? pordSumAmount { get; set; }

	public decimal? pordTotalAmount { get; set; }

	public string pordTotalAmountStr { get; set; }

	public string UserName { get; set; }

	public string UserDirectTel { get; set; }

	public string UserTelDesc { get; set; }

	public int PreOrderID { get; set; }

	public DateTime? pordDateTime { get; set; }

	public DateTime? pordImportDateTime { get; set; }

	public int? pordReferUserId { get; set; }

	public int? pordCompanyId { get; set; }

	public int? pordCompanyPersonId { get; set; }

	public bool? pordIsVerified { get; set; }

	public int? pordVerifierId { get; set; }

	public int? pordStatusId { get; set; }

	public bool? pordIsFixed { get; set; }

	public int? pordGuarantyId { get; set; }

	public int? pordPayConditionId { get; set; }

	public int? pordDeliveryTimeId { get; set; }

	public int? pordCreditDurationId { get; set; }

	public int? pordDescriptionId { get; set; }

	public int? pordPrintFormatId { get; set; }

	public int? pordRLogoId { get; set; }

	public int? pordLLogoId { get; set; }

	public int? pordSignatureId { get; set; }

	public int UserId { get; set; }

	public int FPId { get; set; }

	public short Month1 { get; set; }

	public DateTime RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	public int? pordFirstRegisterUserId { get; set; }

	public string CompanySpecialPoint { get; set; }

	public string pordExpireDate { get; set; }

	public DateTime? pordExpireDateTime { get; set; }

	public int? pordProjectId { get; set; }

	public string cmpMainPerson { get; set; }

	public string cmpGroup { get; set; }

	public string cmpSubGroup { get; set; }

	public string cmpGroupII { get; set; }

	public string cmpGroupIII { get; set; }

	public string cmpGroupIV { get; set; }

	public int? pordCurrencyUnitId { get; set; }

	public string pordCurrencyUnit { get; set; }

	public long? pordNumberRevision { get; set; }

	public string pordNumRef { get; set; }

	public int? pordDeliveryTermId { get; set; }

	public string pordDeliveryTerm { get; set; }

	public string pordCostSheetIds { get; set; }

	public int? pordParentPreOrderId { get; set; }

	public string prjInquiryNum { get; set; }

	public long? prjNumR { get; set; }

	public string prjNumRef { get; set; }

	public string pordDeliveryEndDate { get; set; }

	public DateTime? pordDeliveryEndDateTime { get; set; }

	public string pordDeliveryEndTime { get; set; }

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

	public int? pordVerificationWorkFlowId { get; set; }

	public string pordVerificationWorkFlow { get; set; }

	public int? pordLinkAccPreOrderId { get; set; }

	public string pordLinkAccPreOrderNumber { get; set; }

	public string prjStartDate { get; set; }

	public DateTime? prjStartDateTime { get; set; }

	public string prjGroup { get; set; }

	public string pordLinkAccPreOrderIdStr { get; set; }

	public string cmpNameOfficial { get; set; }

	public string cmpNameEng { get; set; }

	public int? pordSaleCenterId { get; set; }

	public string pordSaleCenter { get; set; }

	public int? pordDefPayTypeId { get; set; }

	public string pordDefPayType { get; set; }

	public decimal? CmpLinkAccAllPayRemain { get; set; }

	public string CompanyOfficialTel { get; set; }

	public string CompanyOfficialCountry { get; set; }

	public string CompanyOfficialProvince { get; set; }

	public string CompanyOfficialCity { get; set; }

	public string CompanyOfficialAddress { get; set; }

	public string CompanyOfficialZipCode { get; set; }

	public string CompanyOfficialDesc { get; set; }

	public DateTime? pordDeadlineDate { get; set; }

	public string pordDeadlineDatePersian { get; set; }

	public double? pordItemsQty { get; set; }

	public decimal? pordItemsDiscount { get; set; }

	public decimal? pordItemsTax { get; set; }

	public string pordDeliveryDay { get; set; }

	public string pordDeliveryEndDay { get; set; }

	public string CompanyFreight { get; set; }

	public int? pordCurrencyUnitIdI { get; set; }

	public string pordCurrencyUnitI { get; set; }

	public double? pordCurrencyUnitIRate { get; set; }

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

	public string pordLinkAccData { get; set; }

	public int? cmpSuppUserId { get; set; }

	public string cmpSuppUserName { get; set; }

	public int? pordCId { get; set; }

	public string pordCenterName { get; set; }

	public string pordCenterCode { get; set; }

	public int? pordChangeStatusUserId { get; set; }

	public string pordChangeStatusUser { get; set; }

	public DateTime? pordChangeStatusDate { get; set; }

	public string pordChangeStatusDatePersian { get; set; }

	public int? pordSaleAreaId { get; set; }

	public string pordSaleArea { get; set; }

	public string prsAddress { get; set; }
}
