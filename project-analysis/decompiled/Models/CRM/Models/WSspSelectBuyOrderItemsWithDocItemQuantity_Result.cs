using System;

namespace CRM.Models;

public class WSspSelectBuyOrderItemsWithDocItemQuantity_Result
{
	public int BuyOrderItemId { get; set; }

	public int BuyOrderId { get; set; }

	public int bordIPrdId { get; set; }

	public double? bordIQuantity { get; set; }

	public decimal? bordICost { get; set; }

	public decimal? bordITotalCost { get; set; }

	public string bordIDescription { get; set; }

	public int UserId { get; set; }

	public int FPId { get; set; }

	public short Month1 { get; set; }

	public DateTime RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	public string bordIQuantityDesc { get; set; }

	public decimal? bordIDiscount { get; set; }

	public decimal? bordIDiscountI { get; set; }

	public Guid? GUId { get; set; }

	public decimal? bordIDiscountPercent { get; set; }

	public decimal? bordIDiscountIPercent { get; set; }

	public int? bordIPrdUnitId { get; set; }

	public int? bordICurrencyUnitId { get; set; }

	public int? bordIOrderView { get; set; }

	public double? bordIFCR { get; set; }

	public decimal? bordITax { get; set; }

	public decimal? bordITaxIndex { get; set; }

	public bool? bordICalculateTax { get; set; }

	public bool? bordINotVisible { get; set; }

	public double? bordIFCRI { get; set; }

	public bool? bordINotInSum { get; set; }

	public int? bordIWHId { get; set; }

	public string AppType { get; set; }

	public int? LanguageID { get; set; }

	public int? FirstRegisterUserId { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public DateTime? FirstRegisterDate { get; set; }

	public string prdName { get; set; }

	public string prdCode { get; set; }

	public string PrdUnit { get; set; }

	public string PrdCurrencyUnit { get; set; }

	public string PrdSGroup { get; set; }

	public string PrdFGroup { get; set; }

	public string PrdGroup { get; set; }

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

	public decimal? pordITotalPrice { get; set; }

	public decimal? bordICommission { get; set; }

	public int? bordICommissionCurrUnId { get; set; }

	public string bordICommissionCurrUn { get; set; }

	public double? bordICommissionCurrencyRate { get; set; }

	public decimal? bordIFinalCommission { get; set; }

	public int? bordICostSheetItemId { get; set; }

	public double? DocItemQuantity { get; set; }

	public double CurrentQuantity { get; set; }
}
