using System;

namespace CRMIdealApi.ApiModels;

public class UpdateBuyOrderViewModel : PublicParameters
{
	public int ApiBuyOrderId { get; set; }

	public int? ApiBuyOrderOprId { get; set; }

	public string ApiBordTitle { get; set; }

	public string ApiBordTitle_Lang { get; set; }

	public long? ApiBordNumber { get; set; }

	public string ApiBordOrderNumber { get; set; }

	public DateTime? ApiBordOrderDateTime { get; set; }

	public int ApiBordCompanyId { get; set; }

	public int? ApiBordCompanyPersonId { get; set; }

	public int? ApiBordProjectId { get; set; }

	public string ApiBordSubject { get; set; }

	public string ApiBordSubject_Lang { get; set; }

	public decimal? ApiBordDiscount { get; set; }

	public string ApiBordDiscountTitle { get; set; }

	public string ApiBordDiscountTitle_Lang { get; set; }

	public decimal? ApiBordTaxIndex { get; set; }

	public bool? ApiBordCalculateTax { get; set; }

	public bool? ApiBordIsVerified { get; set; }

	public int? ApiBordStatusId { get; set; }

	public bool? ApiBordIsFixed { get; set; }

	public int? ApiBordPrintFormatId { get; set; }

	public int? ApiBordVerifierId { get; set; }

	public DateTime? ApiBordVerifiedRegisterDate { get; set; }

	public int? ApiBordSettlementTypeId { get; set; }

	public decimal? ApiBordTransportation { get; set; }

	public int? ApiBordReferUserId { get; set; }

	public decimal? ApiBordRound { get; set; }

	public string ApiBordNote { get; set; }

	public string ApiBordNote_Lang { get; set; }

	public DateTime? ApiBordDateTime { get; set; }

	public string ApiBordCmpTitle { get; set; }

	public string ApiBordCmpTitle_Lang { get; set; }

	public int? ApiBordCurrencyUnitId { get; set; }

	public int? ApiBordFacilityCmpId { get; set; }

	public int? ApiBordFacilityPrsId { get; set; }

	public int? ApiBordFacilityPrjId { get; set; }

	public int? ApiBordReqCmpId { get; set; }

	public int? ApiBordReqPrsId { get; set; }

	public int? ApiBordReqPrjId { get; set; }

	public string ApiBordDeliveryTerm { get; set; }

	public string ApiBordDeliveryTerm_Lang { get; set; }

	public DateTime? ApiBordDeliveryDate { get; set; }

	public bool? ApiBordTaxCleared { get; set; }

	public DateTime? ApiBordTaxClearedDate { get; set; }

	public decimal? ApiBordFacilityCostPercent { get; set; }

	public DateTime? ApiBordSupplierDeliveryDate { get; set; }

	public string ApiBordForwarderName { get; set; }

	public string ApiBordForwarderName_Lang { get; set; }

	public decimal? ApiBordFreightCost { get; set; }

	public int? ApiBordFreightCurrUnId { get; set; }

	public float? ApiBordFreightCurrencyRate { get; set; }

	public string ApiBordCustomsPart { get; set; }

	public string ApiBordCustomsPart_Lang { get; set; }

	public decimal? ApiBordCustomsFee { get; set; }

	public int? ApiBordCustomsCurrUnId { get; set; }

	public float? ApiBordCustomsCurrencyRate { get; set; }

	public DateTime? ApiBordFinalDeliveryDate { get; set; }

	public decimal? ApiBordCommission { get; set; }

	public int? ApiBordCommissionCurrUnId { get; set; }

	public float? ApiBordCommissionCurrencyRate { get; set; }

	public int? ApiBordCostSheetId { get; set; }

	public string ApiBordNumRef { get; set; }

	public int? ApiBordDefaultSettingId { get; set; }

	public int? ApiBordVerificationWorkFlowId { get; set; }

	public DateTime? ApiBordLinkAccFirstTransferDate { get; set; }

	public DateTime? ApiBordLinkAccLastTransferDate { get; set; }

	public int? ApiBordCurrencyUnitIdI { get; set; }

	public float? ApiBordCurrencyUnitIRate { get; set; }

	public decimal? ApiBordFinalFreightCost { get; set; }

	public decimal? ApiBordFinalCustomsFee { get; set; }

	public decimal? ApiBordFinalCommission { get; set; }

	public decimal? ApiBordTotalFinalCost { get; set; }

	public decimal? ApiBordFacilityCost { get; set; }
}
