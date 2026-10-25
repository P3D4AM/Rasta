using System;

namespace CRM.Models;

public class WSspSelectPreOrderItemsWithOrdItemQuantity_Result
{
	public int PreOrderItemID { get; set; }

	public int PreOrderId { get; set; }

	public int pordIPrdId { get; set; }

	public double? pordIQuantity { get; set; }

	public decimal? pordIPrice { get; set; }

	public decimal? pordITotalPrice { get; set; }

	public string pordIDescription { get; set; }

	public string pordIQuantityDesc { get; set; }

	public decimal? pordIDiscount { get; set; }

	public decimal? pordIDiscountI { get; set; }

	public decimal? pordIDiscountPercent { get; set; }

	public decimal? pordIDiscountIPercent { get; set; }

	public int? pordIPrdUnitId { get; set; }

	public int? pordICurrencyUnitId { get; set; }

	public int? pordIOrderView { get; set; }

	public double? pordIFCR { get; set; }

	public decimal? pordITax { get; set; }

	public decimal? pordITaxIndex { get; set; }

	public bool? pordICalculateTax { get; set; }

	public bool? pordINotVisible { get; set; }

	public double? pordIFCRI { get; set; }

	public bool? pordINotInSum { get; set; }

	public int? pordIWHId { get; set; }

	public string pordIWrhsName { get; set; }

	public decimal? pordIRound { get; set; }

	public decimal? pordIRoundPlus { get; set; }

	public string PrdName { get; set; }

	public string PrdCode { get; set; }

	public string PrdFGName { get; set; }

	public string PrdSGName { get; set; }

	public string PrdUnitName { get; set; }

	public string PrdCurrencyUnitPrice { get; set; }

	public int? pordIPrdPriceGroupID { get; set; }

	public string pordITracing { get; set; }

	public decimal? pordIPriceSum { get; set; }

	public decimal? pordIDiscountSum { get; set; }

	public decimal? pordIDiscountISum { get; set; }

	public decimal? pordITaxSum { get; set; }

	public string pordIPrdUnit { get; set; }

	public string pordICurrencyUnit { get; set; }

	public int? pordIDeliveryTermId { get; set; }

	public string pordIDeliveryTerm { get; set; }

	public DateTime? pordIDeliveryDate { get; set; }

	public string pordIDeliveryDatePersian { get; set; }

	public int? pordICostSheetItemId { get; set; }

	public string pordILinkAccItemIdStr { get; set; }

	public string pordILinkAccWHIdStr { get; set; }

	public decimal? pordIPriceInQuan { get; set; }

	public double? pordIQuantityTotal { get; set; }

	public double? OrdItemQuantity { get; set; }

	public double CurrentQuantity { get; set; }

	public DateTime? pordIValidityExpireDate { get; set; }

	public string pordIValidityExpireDatePersian { get; set; }

	public decimal? pordIPrdAutoCalcRate { get; set; }

	public decimal? pordIPrdAutoCalcInflationRateInfo { get; set; }

	public bool? PrdAutoCalcIssueOrdFromIndexed { get; set; }

	public int? PrdAutoCalcIssueOrdFromIndexedOprId { get; set; }

	public string PrdAutoCalcIssueOrdFromIndexedOpr { get; set; }

	public int? PrdAutoCalcIndexedPrdId { get; set; }

	public string PrdAutoCalcIndexedPrdName { get; set; }

	public string PrdAutoCalcIndexedPrdCode { get; set; }

	public bool? PrdOrdIssueSetSetting { get; set; }

	public int? PrdOrdIssuePrjTitleGroupId { get; set; }

	public string PrdOrdIssuePrjTitleGroup { get; set; }

	public int? PrdOrdIssuePrjTitleId { get; set; }

	public string PrdOrdIssuePrjTitle { get; set; }

	public string PrdOrdIssuePrjPostFix { get; set; }

	public int? PrdOrdIssuePrjCnvsStatusGroupId { get; set; }

	public string PrdOrdIssuePrjCnvsStatusGroup { get; set; }

	public int? PrdOrdIssuePrjRemindDay { get; set; }

	public bool? PrdOrdIssuePrjFOCmpCanSee { get; set; }

	public bool? PrdOrdIssuePrjIsTicket { get; set; }

	public int? PrdOrdIssuePrjUsedType { get; set; }
}
