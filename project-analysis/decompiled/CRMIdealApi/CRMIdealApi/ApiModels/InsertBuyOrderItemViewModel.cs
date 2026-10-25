using System;

namespace CRMIdealApi.ApiModels;

public class InsertBuyOrderItemViewModel : PublicParameters
{
	public int ApiBuyOrderId { get; set; }

	public int ApiBordIPrdId { get; set; }

	public string ApiBordIPrdCode { get; set; }

	public decimal? ApiBordIRound { get; set; }

	public decimal? ApiBordIRoundPlus { get; set; }

	public float? ApiBordIQuantity { get; set; }

	public decimal? ApiBordICost { get; set; }

	public string ApiBordIDescription { get; set; }

	public string ApiBordIDescription_Lang { get; set; }

	public string ApiBordIQuantityDesc { get; set; }

	public string ApiBordIQuantityDesc_Lang { get; set; }

	public decimal? ApiBordIDiscount { get; set; }

	public decimal? ApiBordIDiscountPercent { get; set; }

	public decimal? ApiBordIDiscountSum { get; set; }

	public int? ApiBordIPrdUnitId { get; set; }

	public int? ApiBordICurrencyUnitId { get; set; }

	public int? ApiBordIOrderView { get; set; }

	public float? ApiBordIFCR { get; set; }

	public decimal? ApiBordITax { get; set; }

	public decimal? ApiBordITaxIndex { get; set; }

	public bool? ApiBordICalculateTax { get; set; }

	public bool? ApiBordINotVisible { get; set; }

	public float? ApiBordIFCRI { get; set; }

	public bool? ApiBordINotInSum { get; set; }

	public int? ApiBordIWHId { get; set; }

	public int? ApiBordIPrdCostGroupID { get; set; }

	public string ApiBordITracing { get; set; }

	public bool? ApiBordITaxCleared { get; set; }

	public DateTime? ApiBordITaxClearedDate { get; set; }

	public decimal? ApiBordIFacilityCostPercent { get; set; }

	public string ApiBordIForwarderName { get; set; }

	public string ApiBordIForwarderName_Lang { get; set; }

	public decimal? ApiBordIFreightCost { get; set; }

	public int? ApiBordIFreightCurrUnId { get; set; }

	public float? ApiBordIFreightCurrencyRate { get; set; }

	public string ApiBordICustomsPart { get; set; }

	public string ApiBordICustomsPart_Lang { get; set; }

	public decimal? ApiBordICustomsFee { get; set; }

	public int? ApiBordICustomsCurrUnId { get; set; }

	public float? ApiBordICustomsCurrencyRate { get; set; }

	public decimal? ApiBordICommission { get; set; }

	public int? ApiBordICommissionCurrUnId { get; set; }

	public float? ApiBordICommissionCurrencyRate { get; set; }

	public int? ApiBordICostSheetItemId { get; set; }

	public float? ApiBordIQuantityTotal { get; set; }

	public int? ApiBordIPrdUnitIdI { get; set; }

	public float? ApiBordIPrdUnitIRateResult { get; set; }

	public int? ApiBordIPrdColorId { get; set; }

	public string ApiBordIPrdNickname { get; set; }

	public string ApiBordIPrdNickname_Lang { get; set; }

	public DateTime? ApiBordILinkAccFirstTransferDate { get; set; }

	public DateTime? ApiBordILinkAccLastTransferDate { get; set; }

	public bool? ApiAddLinkedPrd { get; set; }

	public decimal? ApiBordIFinalCustomsFee { get; set; }

	public decimal? ApiBordIFacilityCost { get; set; }

	public decimal? ApiBordITaxSum { get; set; }

	public decimal? ApiBordICostSum { get; set; }

	public decimal? ApiBordITotalCost { get; set; }

	public decimal? ApiBordIFinalFreightCost { get; set; }

	public decimal? ApiBordIFinalCommission { get; set; }

	public decimal? ApiBordITotalFinalCost { get; set; }
}
