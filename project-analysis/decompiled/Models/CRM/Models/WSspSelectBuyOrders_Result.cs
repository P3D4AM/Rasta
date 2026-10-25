using System;

namespace CRM.Models;

public class WSspSelectBuyOrders_Result
{
	public string bordOpr { get; set; }

	public string bordCompany { get; set; }

	public string bordPerson { get; set; }

	public string bordProject { get; set; }

	public string bordStatus { get; set; }

	public string bordVerifierUser { get; set; }

	public string bordFirstRegisterUser { get; set; }

	public string bordReferUser { get; set; }

	public string EditUser { get; set; }

	public string bordPrintFormat { get; set; }

	public string CompanyPersonMobile { get; set; }

	public string CompanyprsEmail { get; set; }

	public string CompanyprsEmailII { get; set; }

	public int BuyOrderID { get; set; }

	public int? BuyOrderOprId { get; set; }

	public int? PreBuyOrderId { get; set; }

	public int? PreBuyOrderVerifierId { get; set; }

	public string bordTitle { get; set; }

	public long bordNumber { get; set; }

	public string bordOrderNumber { get; set; }

	public string bordDate { get; set; }

	public string bordOrderDate { get; set; }

	public DateTime? bordOrderDateTime { get; set; }

	public int bordCompanyId { get; set; }

	public int? bordCompanyPersonId { get; set; }

	public int? bordProjectId { get; set; }

	public string bordSubject { get; set; }

	public int? bordItemCount { get; set; }

	public decimal? bordItemsAmount { get; set; }

	public decimal? bordDiscount { get; set; }

	public decimal? bordSumAmount { get; set; }

	public decimal? bordTax { get; set; }

	public decimal? bordTaxIndex { get; set; }

	public bool? bordCalculateTax { get; set; }

	public decimal? bordTotalAmount { get; set; }

	public string bordTotalAmountStr { get; set; }

	public bool? bordIsVerified { get; set; }

	public int? bordStatusId { get; set; }

	public bool? bordIsFixed { get; set; }

	public int? bordPrintFormatId { get; set; }

	public string bordImportDate { get; set; }

	public int UserId { get; set; }

	public int FPId { get; set; }

	public short Month1 { get; set; }

	public DateTime RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	public int? bordVerifierId { get; set; }

	public DateTime? bordVerifiedRegisterDate { get; set; }

	public string bordVerifiedRegisterDatePersian { get; set; }

	public int? bordFirstRegisterUserId { get; set; }

	public int? bordSettlementTypeId { get; set; }

	public string bordDay { get; set; }

	public string bordTime { get; set; }

	public decimal? bordTransportation { get; set; }

	public int? bordReferUserId { get; set; }

	public decimal? bordRound { get; set; }

	public decimal? bordDiscountPercent { get; set; }

	public string bordDiscountTitle { get; set; }

	public string bordNote { get; set; }

	public DateTime? bordDateTime { get; set; }

	public DateTime? bordImportDateTime { get; set; }

	public string bordcmpTitle { get; set; }

	public Guid? GUId { get; set; }

	public string AppType { get; set; }

	public int? LanguageID { get; set; }

	public int? FirstRegisterUserId { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public DateTime? FirstRegisterDate { get; set; }

	public int? bordLinkAccCodeId { get; set; }

	public string bordLinkAccCode { get; set; }

	public int? bordLinkAccBuyOrderId { get; set; }

	public string bordLinkAccBuyOrderNumber { get; set; }

	public int? bordLinkAccVoucherId { get; set; }

	public string bordLinkAccVoucherNumber { get; set; }

	public int? bordCurrencyUnitId { get; set; }

	public string bordCurrencyUnit { get; set; }

	public int? bordFacilityCmpId { get; set; }

	public string bordFacilityCmp { get; set; }

	public int? bordFacilityPrsId { get; set; }

	public string bordFacilityPrs { get; set; }

	public int? bordFacilityPrjId { get; set; }

	public string bordFacilityPrj { get; set; }

	public int? bordReqCmpId { get; set; }

	public string bordReqCmp { get; set; }

	public int? bordReqPrsId { get; set; }

	public string bordReqPrs { get; set; }

	public int? bordReqPrjId { get; set; }

	public string bordReqPrj { get; set; }

	public string bordDeliveryTerm { get; set; }

	public DateTime? bordDeliveryDate { get; set; }

	public string bordDeliveryDatePersian { get; set; }

	public bool? bordTaxCleared { get; set; }

	public DateTime? bordTaxClearedDate { get; set; }

	public string bordTaxClearedDatePersian { get; set; }

	public decimal? bordFacilityCost { get; set; }

	public decimal? bordFacilityCostPercent { get; set; }

	public DateTime? bordSupplierDeliveryDate { get; set; }

	public string bordSupplierDeliveryDatePersian { get; set; }

	public string bordForwarderName { get; set; }

	public decimal? bordFreightCost { get; set; }

	public int? bordFreightCurrUnId { get; set; }

	public string bordFreightCurrUn { get; set; }

	public double? bordFreightCurrencyRate { get; set; }

	public decimal? bordFinalFreightCost { get; set; }

	public string bordCustomsPart { get; set; }

	public decimal? bordCustomsFee { get; set; }

	public int? bordCustomsCurrUnId { get; set; }

	public string bordCustomsCurrUn { get; set; }

	public double? bordCustomsCurrencyRate { get; set; }

	public decimal? bordFinalCustomsFee { get; set; }

	public DateTime? bordFinalDeliveryDate { get; set; }

	public string bordFinalDeliveryDatePersian { get; set; }

	public decimal? bordTotalFinalCost { get; set; }

	public decimal? bordCommission { get; set; }

	public int? bordCommissionCurrUnId { get; set; }

	public string bordCommissionCurrUn { get; set; }

	public double? bordCommissionCurrencyRate { get; set; }

	public decimal? bordFinalCommission { get; set; }

	public int? bordCostSheetId { get; set; }

	public long? bordCostSheetNumber { get; set; }

	public string bordNumRef { get; set; }

	public int? BuyOprType { get; set; }

	public decimal? TaxIndexItem { get; set; }

	public bool? CalculateTaxItem { get; set; }

	public int? bordVerificationWorkFlowId { get; set; }

	public DateTime? bordLinkAccFirstTransferDate { get; set; }

	public string bordLinkAccBuyOrderIdStr { get; set; }

	public DateTime? bordLinkAccLastTransferDate { get; set; }

	public string bordLinkAccData { get; set; }

	public string bordEditAfterFixInfoJs { get; set; }

	public int? bordSuppUserId { get; set; }

	public string bordSuppUser { get; set; }

	public int? bordCId { get; set; }

	public string bordCenterName { get; set; }
}
