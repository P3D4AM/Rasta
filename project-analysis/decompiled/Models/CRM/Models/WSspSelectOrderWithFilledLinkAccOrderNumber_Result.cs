using System;

namespace CRM.Models;

public class WSspSelectOrderWithFilledLinkAccOrderNumber_Result
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

	public string ordFirstRegisterUser { get; set; }

	public int UserId { get; set; }

	public string EditUser { get; set; }

	public int FPId { get; set; }

	public short Month1 { get; set; }

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

	public string FirstRegisterUser { get; set; }

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
}
