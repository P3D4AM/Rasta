using System;

namespace CRMIdealApi.ApiModels;

public class InsertOrderViewModel
{
	public string UserName { get; set; }

	public string Password { get; set; }

	public int UserId { get; set; }

	public int? ApiOrderOprId { get; set; }

	public int? ApiPreOrderId { get; set; }

	public int? ApiPreOrderVerifierId { get; set; }

	public string ApiOrdTitle { get; set; }

	public long? ApiOrdNumber { get; set; }

	public DateTime? ApiOrdDate { get; set; }

	public string ApiOrdSubject { get; set; }

	public decimal? ApiOrdInstallAmount { get; set; }

	public decimal? ApiOrdDiscount { get; set; }

	public decimal? ApiOrdTax { get; set; }

	public decimal? ApiOrdTaxIndex { get; set; }

	public bool? ApiOrdCalculateTax { get; set; }

	public bool? ApiOrdIsVerified { get; set; }

	public DateTime? ApiOrdVerifiedRegisterDate { get; set; }

	public bool? ApiOrdIsFixed { get; set; }

	public int? ApiOrdGuarantyId { get; set; }

	public string ApiOrdSpecialWord { get; set; }

	public string ApiOrdDescriptionI { get; set; }

	public string ApiOrdDescriptionII { get; set; }

	public int? ApiOrdDescriptionId { get; set; }

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

	public int? ApiOrdVerifierId { get; set; }

	public int? ApiOrdSettlementTypeId { get; set; }

	public decimal? ApiOrdTransportation { get; set; }

	public int? ApiOrdReferUserId { get; set; }

	public decimal? ApiOrdDiscountPercent { get; set; }

	public string ApiOrdDiscountTitle { get; set; }

	public decimal? ApiOrdRound { get; set; }

	public string ApiOrdNote { get; set; }

	public string ApiOrdCmpTitle { get; set; }

	public DateTime? ApiOrdDeliveryDate { get; set; }

	public string ApiOrdDeliveryTime { get; set; }

	public string ApiOrdSerial { get; set; }

	public int? ApiOrdVerifierRequestId { get; set; }

	public int? ApiOrdStatusId { get; set; }

	public int? ApiCompanyId { get; set; }

	public int? ApiCmpNumber { get; set; }

	public string ApiCmpCode { get; set; }

	public int? ApiCompanyPersonId { get; set; }

	public int? ApiProjectId { get; set; }

	public string ApiPrjTitle { get; set; }

	public int? LanguageId { get; set; }

	public int? ApiOrdDeliveryTermId { get; set; }

	public string ApiOrdDeliveryEndDate { get; set; }

	public DateTime? ApiOrdDeliveryEndDateTime { get; set; }

	public string ApiOrdDeliveryEndTime { get; set; }

	public string ApiOrdDeliveryDay { get; set; }

	public string ApiOrdDeliveryEndDay { get; set; }

	public int? ApiOrdCurrencyUnitId { get; set; }

	public int? CenterId { get; set; }

	public string CenterCode { get; set; }

	public int? ApiOrdLinkAccCodeId { get; set; }

	public string ApiOrdLinkAccCode { get; set; }

	public int? ApiOrdLinkAccOrderId { get; set; }

	public string ApiOrdLinkAccOrderNumber { get; set; }

	public int? ApiOrdLinkAccVoucherId { get; set; }

	public string ApiOrdLinkAccVoucherNumber { get; set; }

	public string ApiOrdLinkAccOrderIdStr { get; set; }

	public string ApiOrdLinkAccTransferKey { get; set; }

	public string ApiOrdLinkAccTransferResult { get; set; }

	public bool? ApiOrdLinkAccConflict { get; set; }

	public DateTime? ApiOrdLinkAccFirstTransferDate { get; set; }

	public DateTime? ApiOrdLinkAccLastTransferDate { get; set; }

	public string ApiOrdLinkAccData { get; set; }
}
