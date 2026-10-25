using System;
using System.ComponentModel.DataAnnotations;
using CRM.Resources;

namespace CRM.Models;

public class PreOrderItemsViewModel
{
	[Key]
	public int PreOrderItemID { get; set; }

	public int PreOrderId { get; set; }

	public int pordIPrdId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "PreOrderItemPrdCode")]
	public string PrdCode { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "PreOrderItemPrdName")]
	public string PrdName { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "PreOrderItemPrdGroupName")]
	public string PrdGroupName { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "PreOrderItemPordIQuantity")]
	public double? pordIQuantity { get; set; }

	public string pordIDescription { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "PreOrderItemPrdUnitName")]
	public string PrdUnitName { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "PreOrderItemPordIQuantityDesc")]
	public string pordIQuantityDesc { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "PreOrderItemPrdCurrencyUnitPrice")]
	public string PrdCurrencyUnitPrice { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "PreOrderItemPordIFCR")]
	public double? pordIFCR { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "PreOrderItemPordIFCRI")]
	public double? pordIFCRI { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "PreOrderItemPordIPrice")]
	public decimal? pordIPrice { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "PreOrderItemPordIDiscount")]
	public decimal? pordIDiscount { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "PreOrderItemPordIDiscountPercent")]
	public decimal? pordIDiscountPercent { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "PreOrderItemPordITax")]
	public decimal? pordITax { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "PreOrderItemPordITaxIndex")]
	public decimal? pordITaxIndex { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "PreOrderItemPordITotalPrice")]
	public decimal? pordITotalPrice { get; set; }

	public int? pordIOrderView { get; set; }

	public int? pordIWHId { get; set; }

	public string pordITracing { get; set; }

	public string pordILinkAccWHIdStr { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "PreOrderItemPordIPriceSum")]
	public decimal? pordIPriceSum { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "PreOrderItemPordIDiscountSum")]
	public decimal? pordIDiscountSum { get; set; }

	public decimal? pordIDiscountISum { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "PreOrderItemPordITaxSum")]
	public decimal? pordITaxSum { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "PreOrderItemPordIPriceInCount")]
	public decimal? pordIPriceInQuan { get; set; }

	public int? pordIPrdColorId { get; set; }

	public string pordIPrdColor { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "PordIPrdColorName")]
	public int? pordIPrdUnitIdI { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "PreOrderItemPrdUnitIName")]
	public string pordIPrdUnitIName { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "PreOrderItemPrdUnitIRateResult")]
	public double? pordIPrdUnitIRateResult { get; set; }

	public bool? PrdSingleItem { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "PreOrderItemPordIPrdUnitIRate")]
	public double? pordIPrdUnitIRate { get; set; }

	public DateTime? pordIValidityExpireDate { get; set; }

	public string pordIValidityExpireDatePersian { get; set; }

	public string pordIDescriptionI { get; set; }

	public decimal? pordIPrdAutoCalcRate { get; set; }

	public decimal? pordIPrdAutoCalcInflationRateInfo { get; set; }

	public string pordIDeliveryTerm { get; set; }

	public DateTime? pordIDeliveryDate { get; set; }

	public string pordIDeliveryDatePersian { get; set; }

	public DateTime? pordIDeliveryEndDate { get; set; }

	public string pordIDeliveryEndDatePersian { get; set; }

	public string StockSupplyItemIds { get; set; }

	public int? pordIDiscountCodeId { get; set; }

	public string pordIDiscountCode { get; set; }

	public int? pordIDiscountCodeUserId { get; set; }

	public string pordIDiscountCodeUser { get; set; }

	public DateTime? pordIDiscountCodeRegisterDate { get; set; }

	public string pordIDiscountCodeRegisterDatePersian { get; set; }

	public string PrdRowColor { get; set; }

	public string PrdLocation { get; set; }

	public double? PrdWeight { get; set; }

	public string PrdSpecificationsJs { get; set; }

	public int? itemOrderView { get; set; }

	public int? pordILinkedParentItemId { get; set; }

	public int? pordILinkedParentPrdId { get; set; }

	public long? RowNumber { get; set; }

	public string pordILinkedParentPrdName { get; set; }

	public string pordILinkedParentPrdCode { get; set; }

	public string pordIWrhsName { get; set; }

	public double? pordIPrdWeight { get; set; }
}
