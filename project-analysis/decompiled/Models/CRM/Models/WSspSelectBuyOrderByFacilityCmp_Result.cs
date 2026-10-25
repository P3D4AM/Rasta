using System;

namespace CRM.Models;

public class WSspSelectBuyOrderByFacilityCmp_Result
{
	public int BuyOrderID { get; set; }

	public int? BuyOrderOprId { get; set; }

	public string BuyOrderOpr { get; set; }

	public int? PreBuyOrderId { get; set; }

	public int? PreBuyOrderVerifierId { get; set; }

	public string bordTitle { get; set; }

	public long bordNumber { get; set; }

	public string bordOrderNumber { get; set; }

	public string bordDate { get; set; }

	public string bordOrderDate { get; set; }

	public DateTime? bordOrderDateTime { get; set; }

	public int bordCompanyId { get; set; }

	public string bordCompany { get; set; }

	public int? bordCompanyNumber { get; set; }

	public int? bordCompanyPersonId { get; set; }

	public string bordCompanyPerson { get; set; }

	public int? bordProjectId { get; set; }

	public string bordProject { get; set; }

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

	public string bordStatus { get; set; }

	public bool? bordIsFixed { get; set; }

	public int? bordPrintFormatId { get; set; }

	public string bordImportDate { get; set; }

	public int UserId { get; set; }

	public string EditUser { get; set; }

	public int FPId { get; set; }

	public short Month1 { get; set; }

	public DateTime RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	public int? bordVerifierId { get; set; }

	public string bordVerifier { get; set; }

	public DateTime? bordVerifiedRegisterDate { get; set; }

	public string bordVerifiedRegisterDatePersian { get; set; }

	public int? bordFirstRegisterUserId { get; set; }

	public string bordFirstRegisterUser { get; set; }

	public int? bordSettlementTypeId { get; set; }

	public string bordSettlementType { get; set; }

	public string bordDay { get; set; }

	public string bordTime { get; set; }

	public decimal? bordTransportation { get; set; }

	public int? bordReferUserId { get; set; }

	public string bordReferUser { get; set; }

	public decimal? bordRound { get; set; }

	public decimal? bordDiscountPercent { get; set; }

	public string bordDiscountTitle { get; set; }

	public string bordNote { get; set; }

	public DateTime? bordDateTime { get; set; }

	public DateTime? bordImportDateTime { get; set; }

	public string bordcmpTitle { get; set; }

	public string AppType { get; set; }

	public int? LanguageID { get; set; }

	public int? FirstRegisterUserId { get; set; }

	public string FirstRegisterUser { get; set; }

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

	public string bordFacilityCmpName { get; set; }

	public int? bordFacilityCmpNumber { get; set; }

	public int? bordFacilityPrsId { get; set; }

	public string bordFacilityPrs { get; set; }

	public int? bordFacilityPrjId { get; set; }

	public string bordFacilityPrj { get; set; }

	public int? bordReqCmpId { get; set; }

	public string bordReqCmpName { get; set; }

	public int? bordReqCmpNumber { get; set; }

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

	public string bordNumRef { get; set; }

	public double? bordItemsQty { get; set; }

	public decimal? bordItemsDiscount { get; set; }

	public decimal? bordItemsTax { get; set; }

	public int? bordDefaultSettingId { get; set; }

	public string bordDefaultSetting { get; set; }

	public int? bordVerificationWorkFlowId { get; set; }

	public string bordVerificationWorkFlow { get; set; }

	public DateTime? bordLinkAccFirstTransferDate { get; set; }

	public DateTime? bordLinkAccLastTransferDate { get; set; }

	public string bordLinkAccBuyOrderIdStr { get; set; }

	public int? bordCurrencyUnitIdI { get; set; }

	public string bordCurrencyUnitI { get; set; }

	public double? bordCurrencyUnitIRate { get; set; }

	public decimal? bordItemsAmountCurrencyI { get; set; }

	public decimal? bordDiscountCurrencyI { get; set; }

	public decimal? bordSumAmountCurrencyI { get; set; }

	public decimal? bordTaxCurrencyI { get; set; }

	public decimal? bordTotalAmountCurrencyI { get; set; }

	public string bordTotalAmountCurrencyIStr { get; set; }

	public decimal? bordTransportationCurrencyI { get; set; }

	public decimal? bordRoundCurrencyI { get; set; }

	public decimal? bordItemsDiscountCurrencyI { get; set; }

	public decimal? bordItemsTaxCurrencyI { get; set; }

	public string bordLinkAccData { get; set; }

	public string bordEditAfterFixInfoJs { get; set; }

	public int? bordSuppUserId { get; set; }

	public string bordSuppUser { get; set; }

	public int? bordCId { get; set; }

	public string bordCenterName { get; set; }

	public string bordCenterCode { get; set; }

	public int BuyOrderItemId { get; set; }

	public int bordIPrdId { get; set; }

	public string bordIPrdName { get; set; }

	public string bordIPrdCode { get; set; }

	public string bordIPrdSGroup { get; set; }

	public string bordIPrdFGroup { get; set; }

	public double? bordIQuantity { get; set; }

	public decimal? bordICost { get; set; }

	public decimal? bordITotalCost { get; set; }

	public string bordIDescription { get; set; }

	public string bordIQuantityDesc { get; set; }

	public decimal? bordIDiscount { get; set; }

	public decimal? bordIDiscountI { get; set; }

	public decimal? bordIDiscountPercent { get; set; }

	public decimal? bordIDiscountIPercent { get; set; }

	public int? bordIPrdUnitId { get; set; }

	public string bordIPrdUnit { get; set; }

	public int? bordICurrencyUnitId { get; set; }

	public string bordICurrencyUnit { get; set; }

	public int? bordIOrderView { get; set; }

	public double? bordIFCR { get; set; }

	public decimal? bordITax { get; set; }

	public decimal? bordITaxIndex { get; set; }

	public bool? bordICalculateTax { get; set; }

	public bool? bordINotVisible { get; set; }

	public double? bordIFCRI { get; set; }

	public bool? bordINotInSum { get; set; }

	public int? bordIWHId { get; set; }

	public string bordIWHName { get; set; }

	public int? bordILinkAccItemId { get; set; }

	public int? bordIPrdCostGroupID { get; set; }

	public string bordIPrdCostGroup { get; set; }

	public string bordITracing { get; set; }

	public decimal? bordICostSum { get; set; }

	public decimal? bordIDiscountSum { get; set; }

	public decimal? bordIDiscountISum { get; set; }

	public decimal? bordITaxSum { get; set; }

	public bool? bordITaxCleared { get; set; }

	public DateTime? bordITaxClearedDate { get; set; }

	public string bordITaxClearedDatePersian { get; set; }

	public decimal? bordIFacilityCost { get; set; }

	public decimal? bordIFacilityCostPercent { get; set; }

	public string bordIForwarderName { get; set; }

	public decimal? bordIFreightCost { get; set; }

	public int? bordIFreightCurrUnId { get; set; }

	public string bordIFreightCurrUn { get; set; }

	public double? bordIFreightCurrencyRate { get; set; }

	public decimal? bordIFinalFreightCost { get; set; }

	public string bordICustomsPart { get; set; }

	public decimal? bordICustomsFee { get; set; }

	public int? bordICustomsCurrUnId { get; set; }

	public string bordICustomsCurrUn { get; set; }

	public double? bordICustomsCurrencyRate { get; set; }

	public decimal? bordIFinalCustomsFee { get; set; }

	public decimal? bordITotalFinalCost { get; set; }

	public int? bordIPreOrderItemId { get; set; }

	public decimal? bordICommission { get; set; }

	public int? bordICommissionCurrUnId { get; set; }

	public string bordICommissionCurrUn { get; set; }

	public double? bordICommissionCurrencyRate { get; set; }

	public decimal? bordIFinalCommission { get; set; }

	public int? bordICostSheetItemId { get; set; }

	public string bordILinkAccWHIdStr { get; set; }

	public double? bordIQuantityTotal { get; set; }

	public int? bordIPrdUnitIdI { get; set; }

	public string bordIPrdUnitI { get; set; }

	public double? bordIPrdUnitIRateResult { get; set; }

	public int? bordIPrdColorId { get; set; }

	public string bordIPrdColor { get; set; }

	public string bordIPrdNickname { get; set; }

	public DateTime? bordILinkAccFirstTransferDate { get; set; }

	public DateTime? bordILinkAccLastTransferDate { get; set; }

	public string bordILinkAccItemIdStr { get; set; }

	public int? bordICurrencyUnitIdI { get; set; }

	public string bordICurrencyUnitI { get; set; }

	public double? bordICurrencyUnitIRate { get; set; }

	public decimal? bordICostCurrencyI { get; set; }

	public decimal? bordITotalCostCurrencyI { get; set; }

	public decimal? bordIDiscountCurrencyI { get; set; }

	public decimal? bordIDiscountICurrencyI { get; set; }

	public decimal? bordITaxCurrencyI { get; set; }

	public decimal? bordICostSumCurrencyI { get; set; }

	public decimal? bordIDiscountSumCurrencyI { get; set; }

	public decimal? bordIDiscountISumCurrencyI { get; set; }

	public decimal? bordITaxSumCurrencyI { get; set; }

	public string bordILinkAccData { get; set; }

	public int? bordICId { get; set; }

	public string bordICenterName { get; set; }

	public string bordICenterCode { get; set; }

	public double? bordICostCurrencyRate { get; set; }

	public double? bordIPrdWeight { get; set; }

	public int? bordILinkAccSettingDBId { get; set; }

	public string bordILinkAccSettingDBTitle { get; set; }

	public string bordPrintFormat { get; set; }

	public int? bordIPrdUnitIdII { get; set; }

	public string bordIPrdUnitII { get; set; }

	public double? bordIPrdUnitIIRateResult { get; set; }
}
