using System;

namespace CRM.Models;

public class WSspSelectBuyOrderIndicatorWithItems_Result
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

	public string CmpTitle { get; set; }

	public string Company { get; set; }

	public int? bordCompanyPersonId { get; set; }

	public string Person { get; set; }

	public string PersonJob { get; set; }

	public string PersonDepartment { get; set; }

	public string prsNationalCode { get; set; }

	public string prsMobile { get; set; }

	public string CompanyTel { get; set; }

	public string CompanyFax { get; set; }

	public string CompanyCountry { get; set; }

	public string CompanyProvince { get; set; }

	public string CompanyCity { get; set; }

	public string CompanyAddress { get; set; }

	public string CompanyZipcode { get; set; }

	public int? CompanyNumber { get; set; }

	public string CompanyCode { get; set; }

	public string cmpRegistrationNumber { get; set; }

	public string cmpEconomicCode { get; set; }

	public string cmpNationalCode { get; set; }

	public int? cmpGroupId { get; set; }

	public int? cmpSubGroupId { get; set; }

	public int? cmpGroupIdII { get; set; }

	public int? cmpGroupIdIII { get; set; }

	public int? cmpGroupIdIV { get; set; }

	public string CompanyGroup { get; set; }

	public string CompanySubGroup { get; set; }

	public string CompanyGroupII { get; set; }

	public string CompanyGroupIII { get; set; }

	public string CompanyGroupIV { get; set; }

	public int? bordProjectId { get; set; }

	public string prjTitle { get; set; }

	public string prjPostFix { get; set; }

	public string prjInquiryNum { get; set; }

	public string prjNumRef { get; set; }

	public long? prjNumR { get; set; }

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

	public string UserName { get; set; }

	public string UserDirectTel { get; set; }

	public string UserTelDesc { get; set; }

	public DateTime RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	public int? bordVerifierId { get; set; }

	public string VerifierFName { get; set; }

	public string VerifierLName { get; set; }

	public DateTime? bordVerifiedRegisterDate { get; set; }

	public string bordVerifiedRegisterDatePersian { get; set; }

	public int? bordSettlementTypeId { get; set; }

	public decimal? bordTransportation { get; set; }

	public int? bordReferUserId { get; set; }

	public string ReferUserFName { get; set; }

	public string ReferUserLName { get; set; }

	public decimal? bordRound { get; set; }

	public decimal? bordDiscountPercent { get; set; }

	public string bordDiscountTitle { get; set; }

	public string bordNote { get; set; }

	public DateTime? bordDateTime { get; set; }

	public DateTime? bordImportDateTime { get; set; }

	public string bordcmpTitle { get; set; }

	public int? FirstRegisterUserId { get; set; }

	public string FirstRegisterUserFName { get; set; }

	public string FirstRegisterUserLName { get; set; }

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

	public string bordFacilityPrjTitle { get; set; }

	public string bordFacilityPrjPostFix { get; set; }

	public int? bordReqCmpId { get; set; }

	public string bordReqCmp { get; set; }

	public int? bordReqPrsId { get; set; }

	public string bordReqPrs { get; set; }

	public int? bordReqPrjId { get; set; }

	public string bordReqPrjTitle { get; set; }

	public string bordReqPrjPostFix { get; set; }

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

	public string bordNumRef { get; set; }

	public double? bordItemsQty { get; set; }

	public decimal? bordItemsDiscount { get; set; }

	public decimal? bordItemsTax { get; set; }

	public int? bordDefaultSettingId { get; set; }

	public int? bordVerificationWorkFlowId { get; set; }

	public string bordVerificationWorkFlow { get; set; }

	public string LastVerificationWorkFlowStep { get; set; }

	public string LastVerifyUser { get; set; }

	public DateTime? LastVerifyDateTime { get; set; }

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

	public decimal? bordItemsCostWithoutDiscount { get; set; }

	public int BuyOrderItemId { get; set; }

	public int bordIPrdId { get; set; }

	public string PrdName { get; set; }

	public string PrdNMBL { get; set; }

	public string PrdCode { get; set; }

	public string PrdLatinName { get; set; }

	public string PrdModel { get; set; }

	public string PrdFirstBarcode { get; set; }

	public string PrdType { get; set; }

	public string PrdDesign { get; set; }

	public string PrdSize { get; set; }

	public string PrdSGName { get; set; }

	public string PrdSGNameEn { get; set; }

	public string PrdFGName { get; set; }

	public string PrdFGNameEn { get; set; }

	public string PrdGroup { get; set; }

	public string PrdGroupEn { get; set; }

	public string PrdColor { get; set; }

	public string PrdColorEn { get; set; }

	public string PrdCostCurrencyUnit { get; set; }

	public string PrdCostCurrencyUnitEn { get; set; }

	public string PrdUnit { get; set; }

	public string PrdUnitEn { get; set; }

	public string PrdPriceCurrencyUnit { get; set; }

	public string PrdPriceCurrencyUnitEn { get; set; }

	public double? bordIQuantity { get; set; }

	public decimal? bordICost { get; set; }

	public decimal? bordITotalCost { get; set; }

	public string bordIDescription { get; set; }

	public int BOIUserId { get; set; }

	public string BOIUserFName { get; set; }

	public string BOIUserLName { get; set; }

	public DateTime BOIRegisterDate { get; set; }

	public string BOIRegisterDatePersian { get; set; }

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

	public int? BOIFirstRegisterUserId { get; set; }

	public string BOIFirstRegisterUserFName { get; set; }

	public string BOIFirstRegisterUserLName { get; set; }

	public string BOIFirstRegisterDatePersian { get; set; }

	public DateTime? BOIFirstRegisterDate { get; set; }

	public int? bordILinkAccItemId { get; set; }

	public int? bordIPrdCostGroupID { get; set; }

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

	public decimal? PaySumBuyOrder { get; set; }

	public decimal? PayRemainBuyOrder { get; set; }

	public string rptUserName { get; set; }

	public string rptDate { get; set; }

	public string rptDay { get; set; }

	public decimal? bordItemsCostWithDiscount { get; set; }

	public string bordLinkAccData { get; set; }

	public int? bordSuppUserId { get; set; }

	public string bordSuppUser { get; set; }

	public int? bordIPrdUnitIdII { get; set; }

	public string bordIPrdUnitII { get; set; }

	public double? bordIPrdUnitIIRateResult { get; set; }
}
