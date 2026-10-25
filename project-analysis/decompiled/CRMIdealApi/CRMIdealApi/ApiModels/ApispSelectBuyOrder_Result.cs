using System;

namespace CRMIdealApi.ApiModels;

public class ApispSelectBuyOrder_Result
{
	public int ApiBuyOrderID { get; set; }

	public int? ApiBuyOrderOprId { get; set; }

	public string ApiBuyOrderOpr { get; set; }

	public string ApiBordTitle { get; set; }

	public long ApiBordNumber { get; set; }

	public string ApiBordOrderNumber { get; set; }

	public DateTime? ApiBordDateTime { get; set; }

	public string ApiBordDate { get; set; }

	public DateTime? ApiBordOrderDateTime { get; set; }

	public string ApiBordOrderDate { get; set; }

	public int ApiBordCompanyId { get; set; }

	public string ApiCmpNameWithTitle { get; set; }

	public int? ApiBordCompanyPersonId { get; set; }

	public string ApiBordCompanyPerson { get; set; }

	public int? ApiBordProjectId { get; set; }

	public string ApiBordProject { get; set; }

	public string ApiBordSubject { get; set; }

	public int? ApiBordItemCount { get; set; }

	public decimal? ApiBordItemsAmount { get; set; }

	public decimal? ApiBordDiscount { get; set; }

	public decimal? ApiBordSumAmount { get; set; }

	public decimal? ApiBordTax { get; set; }

	public decimal? ApiBordTaxIndex { get; set; }

	public bool? ApiBordCalculateTax { get; set; }

	public decimal? ApiBordTotalAmount { get; set; }

	public string ApiBordTotalAmountStr { get; set; }

	public bool? ApiBordIsVerified { get; set; }

	public int? ApiBordStatusId { get; set; }

	public string ApiBordStatus { get; set; }

	public bool? ApiBordIsFixed { get; set; }

	public int? ApiBordPrintFormatId { get; set; }

	public string ApiBordPrintFormat { get; set; }

	public DateTime? ApiBordImportDateTime { get; set; }

	public string ApiBordImportDate { get; set; }

	public int? ApiBordVerifierId { get; set; }

	public string ApiBordVerifier { get; set; }

	public DateTime? ApiBordVerifiedRegisterDate { get; set; }

	public string ApiBordVerifiedRegisterDatePersian { get; set; }

	public int? ApiBordFirstRegisterUserId { get; set; }

	public string ApiBordFirstRegisterUser { get; set; }

	public int? ApiBordSettlementTypeId { get; set; }

	public string ApiBordSettlementType { get; set; }

	public string ApiBordDay { get; set; }

	public string ApiBordTime { get; set; }

	public decimal? ApiBordTransportation { get; set; }

	public int? ApiBordReferUserId { get; set; }

	public string ApiBordReferUser { get; set; }

	public decimal? ApiBordRound { get; set; }

	public decimal? ApiBordDiscountPercent { get; set; }

	public string ApiBordDiscountTitle { get; set; }

	public string ApiBordNote { get; set; }

	public string ApiBordcmpTitle { get; set; }

	public int? ApiBordLinkAccCodeId { get; set; }

	public string ApiBordLinkAccCode { get; set; }

	public int? ApiBordLinkAccBuyOrderId { get; set; }

	public string ApiBordLinkAccBuyOrderNumber { get; set; }

	public int? ApiBordLinkAccVoucherId { get; set; }

	public string ApiBordLinkAccVoucherNumber { get; set; }

	public int? ApiBordCurrencyUnitId { get; set; }

	public string ApiBordCurrencyUnit { get; set; }

	public int? ApiBordFacilityCmpId { get; set; }

	public string ApiBordFacilityCmp { get; set; }

	public int? ApiBordFacilityPrsId { get; set; }

	public string ApiBordFacilityPrs { get; set; }

	public int? ApiBordFacilityPrjId { get; set; }

	public string ApiBordFacilityPrj { get; set; }

	public int? ApiBordReqCmpId { get; set; }

	public string ApiBordReqCmp { get; set; }

	public int? ApiBordReqPrsId { get; set; }

	public string ApiBordReqPrs { get; set; }

	public int? ApiBordReqPrjId { get; set; }

	public string ApiBordReqPrj { get; set; }

	public string ApiBordDeliveryTerm { get; set; }

	public DateTime? ApiBordDeliveryDate { get; set; }

	public string ApiBordDeliveryDatePersian { get; set; }

	public bool? ApiBordTaxCleared { get; set; }

	public DateTime? ApiBordTaxClearedDate { get; set; }

	public string ApiBordTaxClearedDatePersian { get; set; }

	public decimal? ApiBordFacilityCost { get; set; }

	public decimal? ApiBordFacilityCostPercent { get; set; }

	public DateTime? ApiBordSupplierDeliveryDate { get; set; }

	public string ApiBordSupplierDeliveryDatePersian { get; set; }

	public string ApiBordForwarderName { get; set; }

	public decimal? ApiBordFreightCost { get; set; }

	public int? ApiBordFreightCurrUnId { get; set; }

	public string ApiBordFreightCurrUn { get; set; }

	public double? ApiBordFreightCurrencyRate { get; set; }

	public decimal? ApiBordFinalFreightCost { get; set; }

	public string ApiBordCustomsPart { get; set; }

	public decimal? ApiBordCustomsFee { get; set; }

	public int? ApiBordCustomsCurrUnId { get; set; }

	public string ApiBordCustomsCurrUn { get; set; }

	public double? ApiBordCustomsCurrencyRate { get; set; }

	public decimal? ApiBordFinalCustomsFee { get; set; }

	public DateTime? ApiBordFinalDeliveryDate { get; set; }

	public string ApiBordFinalDeliveryDatePersian { get; set; }

	public decimal? ApiBordTotalFinalCost { get; set; }

	public decimal? ApiBordCommission { get; set; }

	public int? ApiBordCommissionCurrUnId { get; set; }

	public string ApiBordCommissionCurrUn { get; set; }

	public double? ApiBordCommissionCurrencyRate { get; set; }

	public decimal? ApiBordFinalCommission { get; set; }

	public int? ApiBordCostSheetId { get; set; }

	public string ApiBordCostSheet { get; set; }

	public string ApiBordNumRef { get; set; }

	public double? ApiBordItemsQty { get; set; }

	public decimal? ApiBordItemsDiscount { get; set; }

	public decimal? ApiBordItemsTax { get; set; }

	public int? ApiBordDefaultSettingId { get; set; }

	public string ApiBordDefaultSetting { get; set; }

	public int? ApiBordVerificationWorkFlowId { get; set; }

	public string ApiBordVerificationWorkFlow { get; set; }

	public DateTime? ApiBordLinkAccFirstTransferDate { get; set; }

	public string ApiBordLinkAccFirstTransferDatePersian { get; set; }

	public DateTime? ApiBordLinkAccLastTransferDate { get; set; }

	public string ApiBordLinkAccBuyOrderIdStr { get; set; }

	public int? ApiBordCurrencyUnitIdI { get; set; }

	public int? ApiBordCurrencyUnitI { get; set; }

	public double? ApiBordCurrencyUnitIRate { get; set; }

	public decimal? ApiBordItemsAmountCurrencyI { get; set; }

	public decimal? ApiBordDiscountCurrencyI { get; set; }

	public decimal? ApiBordSumAmountCurrencyI { get; set; }

	public decimal? ApiBordTaxCurrencyI { get; set; }

	public decimal? ApiBordTotalAmountCurrencyI { get; set; }

	public string ApiBordTotalAmountCurrencyIStr { get; set; }

	public decimal? ApiBordTransportationCurrencyI { get; set; }

	public decimal? ApiBordRoundCurrencyI { get; set; }

	public decimal? ApiBordItemsDiscountCurrencyI { get; set; }

	public decimal? ApiBordItemsTaxCurrencyI { get; set; }

	public int ApiUserId { get; set; }

	public string ApiEditUser { get; set; }

	public int ApiFPId { get; set; }

	public short ApiMonth1 { get; set; }

	public DateTime ApiRegisterDate { get; set; }

	public string ApiRegisterDatePersian { get; set; }

	public Guid? ApiGUId { get; set; }

	public string ApiAppType { get; set; }

	public int? ApiLanguageID { get; set; }

	public int? ApiFirstRegisterUserId { get; set; }

	public string ApiFirstRegisterUser { get; set; }

	public DateTime? ApiFirstRegisterDate { get; set; }

	public string ApiFirstRegisterDatePersian { get; set; }
}
