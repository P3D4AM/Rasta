using System;

namespace CRM.Models;

public class WSspSelectOrderImportFromExcel_Result
{
	public long Id { get; set; }

	public int? OrderOprID { get; set; }

	public string ordTitle { get; set; }

	public long ordNumber { get; set; }

	public string ordDate { get; set; }

	public DateTime? ordDateTime { get; set; }

	public int ordCompanyNumber { get; set; }

	public string ordCompanyPersonName { get; set; }

	public string ordProjectTitle { get; set; }

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

	public int? ordVerifierId { get; set; }

	public int? ordSettlementTypeId { get; set; }

	public decimal? ordTransportation { get; set; }

	public int? ordReferUserId { get; set; }

	public decimal? ordDiscountPercent { get; set; }

	public string ordDiscountTitle { get; set; }

	public decimal? ordRound { get; set; }

	public string ordNote { get; set; }

	public string ordcmpTitle { get; set; }

	public string ordDeliveryDate { get; set; }

	public DateTime? ordDeliveryDateTime { get; set; }

	public string ordSerial { get; set; }

	public int? ordVerifierRequestId { get; set; }

	public int? ordVerificationWorkFlowId { get; set; }

	public int? ordCurrencyUnitId { get; set; }

	public int? ordDeliveryTermId { get; set; }

	public string ordIPrdCode { get; set; }

	public double? ordIQuantity { get; set; }

	public decimal? ordIPrice { get; set; }

	public string ordIDescription { get; set; }

	public string ordIQuantityDesc { get; set; }

	public decimal? ordIDiscountI { get; set; }

	public decimal? ordIDiscount { get; set; }

	public decimal? ordIDiscountPercent { get; set; }

	public int? ordIPrdUnitId { get; set; }

	public int? ordICurrencyUnitId { get; set; }

	public int? ordIOrderView { get; set; }

	public double? ordIFCR { get; set; }

	public decimal? ordITax { get; set; }

	public decimal? ordITaxIndex { get; set; }

	public bool? ordICalculateTax { get; set; }

	public bool? ordINotVisible { get; set; }

	public double? ordIFCRI { get; set; }

	public bool? ordINotInSum { get; set; }

	public int? ordIWHId { get; set; }

	public decimal? ordIRound { get; set; }

	public decimal? ordIRoundPlus { get; set; }

	public double? ordIPricePartRate { get; set; }

	public decimal? ordIPricePartI { get; set; }

	public decimal? ordIPricePartII { get; set; }

	public int? ordIPrdPriceGroupID { get; set; }

	public string ordITracing { get; set; }

	public int? ordIDeliveryTermId { get; set; }

	public DateTime? ordIDeliveryDate { get; set; }

	public string ordIDeliveryDatePersian { get; set; }

	public decimal? ordITaxSum { get; set; }

	public decimal? ordIPriceSum { get; set; }

	public decimal? ordITotalPrice { get; set; }

	public decimal? ordIDiscountSum { get; set; }

	public decimal? ordIDiscountISum { get; set; }

	public decimal? ordIDiscountIPercent { get; set; }

	public string ImportDate { get; set; }

	public DateTime? ImportDateTime { get; set; }

	public int? ordpayTypeId { get; set; }

	public decimal? ordpayAmount { get; set; }

	public string ordpayDocNumber { get; set; }

	public string ordpayDocDate { get; set; }

	public DateTime? ordpayDocDateTime { get; set; }

	public string ordpayDescription { get; set; }

	public decimal? ordpayDocAmount { get; set; }

	public string ordpayBankDocNumber { get; set; }

	public int? IsDuplicate { get; set; }

	public int? InsertedOrdId { get; set; }

	public int? InsertedOrdItemId { get; set; }

	public int? InsertedOrdPaymentId { get; set; }

	public string ErrorMessage { get; set; }
}
