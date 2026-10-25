using System;

namespace CRMIdealApi.ApiModels;

public class ApispSelectBuyOrderItems_Result
{
	public int ApiBuyOrderItemId { get; set; }

	public int ApiBuyOrderId { get; set; }

	public int ApiBordIPrdId { get; set; }

	public double? ApiBordIQuantity { get; set; }

	public decimal? ApiBordICost { get; set; }

	public decimal? ApiBordITotalCost { get; set; }

	public string ApiBordIDescription { get; set; }

	public string ApiBordIQuantityDesc { get; set; }

	public decimal? ApiBordIDiscount { get; set; }

	public decimal? ApiBordIDiscountI { get; set; }

	public decimal? ApiBordIDiscountPercent { get; set; }

	public decimal? ApiBordIDiscountIPercent { get; set; }

	public int? ApiBordIPrdUnitId { get; set; }

	public string ApiBordIPrdUnit { get; set; }

	public int? ApiBordICurrencyUnitId { get; set; }

	public string ApiBordICurrencyUnit { get; set; }

	public int? ApiBordIOrderView { get; set; }

	public double? ApiBordIFCR { get; set; }

	public decimal? ApiBordITax { get; set; }

	public decimal? ApiBordITaxIndex { get; set; }

	public bool? ApiBordICalculateTax { get; set; }

	public bool? ApiBordINotVisible { get; set; }

	public double? ApiBordIFCRI { get; set; }

	public bool? ApiBordINotInSum { get; set; }

	public int? ApiBordIWHId { get; set; }

	public string ApiBordIWH { get; set; }

	public int? ApiBordILinkAccItemId { get; set; }

	public int? ApiBordIPrdCostGroupID { get; set; }

	public string ApiBordITracing { get; set; }

	public decimal? ApiBordICostSum { get; set; }

	public decimal? ApiBordIDiscountSum { get; set; }

	public decimal? ApiBordIDiscountISum { get; set; }

	public decimal? ApiBordITaxSum { get; set; }

	public bool? ApiBordITaxCleared { get; set; }

	public DateTime? ApiBordITaxClearedDate { get; set; }

	public string ApiBordITaxClearedDatePersian { get; set; }

	public decimal? ApiBordIFacilityCost { get; set; }

	public decimal? ApiBordIFacilityCostPercent { get; set; }

	public string ApiBordIForwarderName { get; set; }

	public decimal? ApiBordIFreightCost { get; set; }

	public int? ApiBordIFreightCurrUnId { get; set; }

	public string ApiBordIFreightCurrUn { get; set; }

	public double? ApiBordIFreightCurrencyRate { get; set; }

	public decimal? ApiBordIFinalFreightCost { get; set; }

	public string ApiBordICustomsPart { get; set; }

	public decimal? ApiBordICustomsFee { get; set; }

	public int? ApiBordICustomsCurrUnId { get; set; }

	public string ApiBordICustomsCurrUn { get; set; }

	public double? ApiBordICustomsCurrencyRate { get; set; }

	public decimal? ApiBordIFinalCustomsFee { get; set; }

	public decimal? ApiBordITotalFinalCost { get; set; }

	public int? ApiBordIPreOrderItemId { get; set; }

	public decimal? ApiBordICommission { get; set; }

	public int? ApiBordICommissionCurrUnId { get; set; }

	public string ApiBordICommissionCurrUn { get; set; }

	public double? ApiBordICommissionCurrencyRate { get; set; }

	public decimal? ApiBordIFinalCommission { get; set; }

	public int? ApiBordICostSheetItemId { get; set; }

	public string ApiBordILinkAccWHIdStr { get; set; }

	public double? ApiBordIQuantityTotal { get; set; }

	public int? ApiBordIPrdUnitIdI { get; set; }

	public string ApiBordIPrdUnitI { get; set; }

	public double? ApiBordIPrdUnitIRateResult { get; set; }

	public int? ApiBordIPrdColorId { get; set; }

	public string ApiBordIPrdNickname { get; set; }

	public DateTime? ApiBordILinkAccFirstTransferDate { get; set; }

	public DateTime? ApiBordILinkAccLastTransferDate { get; set; }

	public string ApiBordILinkAccItemIdStr { get; set; }

	public int? ApiBordICurrencyUnitIdI { get; set; }

	public int? ApiBordICurrencyUnitI { get; set; }

	public double? ApiBordICurrencyUnitIRate { get; set; }

	public decimal? ApiBordICostCurrencyI { get; set; }

	public decimal? ApiBordITotalCostCurrencyI { get; set; }

	public decimal? ApiBordIDiscountCurrencyI { get; set; }

	public decimal? ApiBordIDiscountICurrencyI { get; set; }

	public decimal? ApiBordITaxCurrencyI { get; set; }

	public decimal? ApiBordICostSumCurrencyI { get; set; }

	public decimal? ApiBordIDiscountSumCurrencyI { get; set; }

	public decimal? ApiBordIDiscountISumCurrencyI { get; set; }

	public decimal? ApiBordITaxSumCurrencyI { get; set; }

	public Guid? ApiGUId { get; set; }

	public int ApiUserId { get; set; }

	public string ApiEditUser { get; set; }

	public int ApiFPId { get; set; }

	public short ApiMonth1 { get; set; }

	public DateTime ApiRegisterDate { get; set; }

	public string ApiRegisterDatePersian { get; set; }

	public string ApiAppType { get; set; }

	public int? ApiLanguageID { get; set; }

	public int? ApiFirstRegisterUserId { get; set; }

	public string ApiFirstRegisterUser { get; set; }

	public DateTime? ApiFirstRegisterDate { get; set; }

	public string ApiFirstRegisterDatePersian { get; set; }
}
