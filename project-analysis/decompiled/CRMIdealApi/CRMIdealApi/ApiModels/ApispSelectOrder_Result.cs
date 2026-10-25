using System;

namespace CRMIdealApi.ApiModels;

public class ApispSelectOrder_Result
{
	public int ApiOrderID { get; set; }

	public int? ApiOrderOprID { get; set; }

	public string ApiOrderOpr { get; set; }

	public int? ApiPreOrderId { get; set; }

	public string ApiPreOrderTitle { get; set; }

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

	public bool? ApiOrdIsFixed { get; set; }

	public int? ApiOrdGuarantyId { get; set; }

	public string ApiOrdGuaranty { get; set; }

	public string ApiOrdSpecialWord { get; set; }

	public string ApiOrdDescriptionI { get; set; }

	public string ApiOrdDescriptionII { get; set; }

	public int? ApiOrdDescriptionId { get; set; }

	public int? ApiOrdPrintFormatId { get; set; }

	public string ApiOrdPrintFormat { get; set; }

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

	public int ApiFPId { get; set; }

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

	public string ApiOrdVerifierRequest { get; set; }

	public int? ApiOrdVerificationWorkFlowId { get; set; }

	public string ApiOrdVerificationWorkFlow { get; set; }

	public int ApiUserId { get; set; }

	public string ApiEditUser { get; set; }

	public DateTime ApiRegisterDate { get; set; }

	public int? ApiFirstRegisterUserId { get; set; }

	public string ApiFirstRegisterUser { get; set; }

	public DateTime? ApiFirstRegisterDate { get; set; }

	public int? ApiOrdLinkAccCodeId { get; set; }

	public string ApiOrdLinkAccCode { get; set; }

	public int? ApiOrdLinkAccOrderId { get; set; }

	public string ApiOrdLinkAccOrderNumber { get; set; }

	public int? ApiOrdLinkAccVoucherId { get; set; }

	public int? ApiOrdDeliveryTermId { get; set; }

	public string ApiOrdDeliveryEndDate { get; set; }

	public DateTime? ApiordDeliveryEndDateTime { get; set; }

	public string ApiOrdDeliveryEndTime { get; set; }

	public string ApiOrdDeliveryDay { get; set; }

	public string ApiOrdDeliveryEndDay { get; set; }

	public string ApiOrdLinkAccVoucherNumber { get; set; }

	public int? ApiOrdCId { get; set; }

	public string ApiOrdCenterName { get; set; }

	public string ApiOrdLinkAccOrderIdStr { get; set; }

	public string ApiOrdLinkAccTransferKey { get; set; }

	public string ApiOrdLinkAccTransferResult { get; set; }

	public bool? ApiOrdLinkAccConflict { get; set; }

	public DateTime? ApiOrdLinkAccFirstTransferDate { get; set; }

	public DateTime? ApiOrdLinkAccLastTransferDate { get; set; }

	public string ApiOrdLinkAccData { get; set; }

	public long? ApiRowNumber { get; set; }

	public int? ApiTotalCount { get; set; }

	public int? ApiOrdSellerId { get; set; }

	public string ApiOrdSeller { get; set; }
}
