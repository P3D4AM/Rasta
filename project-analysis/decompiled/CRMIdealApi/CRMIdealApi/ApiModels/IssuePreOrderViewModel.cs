using System;

namespace CRMIdealApi.ApiModels;

public class IssuePreOrderViewModel : PublicParameters
{
	public string ApiPordTitle { get; set; }

	public long? ApiPordNumber { get; set; }

	public DateTime? ApiPordDate { get; set; }

	public string ApiPordSubject { get; set; }

	public decimal? ApiPordInstallAmount { get; set; }

	public decimal? ApiPordDiscount { get; set; }

	public decimal? ApiPordTax { get; set; }

	public decimal? ApiPordTaxIndex { get; set; }

	public bool? ApiPordCalculateTax { get; set; }

	public bool? ApiPordIsVerified { get; set; }

	public int? ApiPordVerifierId { get; set; }

	public int? ApiPordVerifierRequestId { get; set; }

	public DateTime? ApiPordVerifiedRegisterDate { get; set; }

	public int? ApiPordStatusId { get; set; }

	public bool? ApiPordIsFixed { get; set; }

	public int? ApiPordGuarantyId { get; set; }

	public int? ApiPordPayConditionId { get; set; }

	public int? ApiPordDeliveryTimeId { get; set; }

	public int? ApiPordCreditDurationId { get; set; }

	public string ApiPordSpecialWord { get; set; }

	public string ApiPordDescriptionI { get; set; }

	public string ApiPordDescriptionII { get; set; }

	public int? ApiPordDescriptionId { get; set; }

	public int? ApiPordPrintFormatId { get; set; }

	public int? ApiPordRLogoId { get; set; }

	public int? ApiPordLLogoId { get; set; }

	public string ApiPordSigningI { get; set; }

	public string ApiPordSigningII { get; set; }

	public string ApiPordSigningIII { get; set; }

	public string ApiPordAccountNumberI { get; set; }

	public string ApiPordAccountShabaNumberI { get; set; }

	public string ApiPordAccountNumberII { get; set; }

	public string ApiPordAccountShabaNumberII { get; set; }

	public string ApiPordAddress { get; set; }

	public string ApiPordTelephone { get; set; }

	public string ApiPordFax { get; set; }

	public string ApiPordWebSite { get; set; }

	public string ApiPordEmail { get; set; }

	public int? ApiPordSignatureId { get; set; }

	public string ApiPordDiscountTitle { get; set; }

	public decimal? ApiPordDiscountPercent { get; set; }

	public decimal? ApiPordTransportation { get; set; }

	public int? ApiPordReferUserId { get; set; }

	public decimal? ApiPordRound { get; set; }

	public string ApiPordcmpTitle { get; set; }

	public DateTime? ApiPordDeliveryDate { get; set; }

	public string ApiPordDeliveryTime { get; set; }

	public int? ApiPordOprId { get; set; }

	public int? ApiPordVerificationWorkFlowId { get; set; }

	public DateTime? ApiPordExpireDate { get; set; }

	public string ApiPordExpireTime { get; set; }

	public int? ApiCompanyId { get; set; }

	public int? ApiCmpNumber { get; set; }

	public string ApiCmpCode { get; set; }

	public int? ApiCompanyPersonId { get; set; }

	public int? ApiProjectId { get; set; }

	public string ApiPrjTitle { get; set; }

	public string ApiProductsInJsonFormat { get; set; }

	public string ApiProductSpecificationInJsonFormat { get; set; }

	public string ApiPaymentsInJsonFormat { get; set; }

	public int? ApiWarehouseId { get; set; }

	public int? ApiPordDeliveryTermId { get; set; }

	public string ApiPordDeliveryEndDate { get; set; }

	public DateTime? ApiPordDeliveryEndDateTime { get; set; }

	public string ApiPordDeliveryEndTime { get; set; }

	public string ApiPordDeliveryDay { get; set; }

	public string ApiPordDeliveryEndDay { get; set; }

	public int? ApiPordCurrencyUnitId { get; set; }

	public int? ApiPordLinkAccPreOrderId { get; set; }

	public string ApiPordLinkAccPreOrderNumber { get; set; }

	public string ApiPordLinkAccPreOrderIdStr { get; set; }

	public DateTime? ApiPordLinkAccFirstTransferDate { get; set; }

	public DateTime? ApiPordLinkAccLastTransferDate { get; set; }

	public string ApiPordLinkAccData { get; set; }

	public string ApiCommissionInJsonFormat { get; set; }
}
