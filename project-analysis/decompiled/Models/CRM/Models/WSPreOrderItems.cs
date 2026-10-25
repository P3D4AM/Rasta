using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(WSPreOrderItemsMetadata))]
public class WSPreOrderItems
{
	public int PreOrderItemID { get; set; }

	public int PreOrderId { get; set; }

	public int pordIPrdId { get; set; }

	public double? pordIQuantity { get; set; }

	public decimal? pordIPrice { get; set; }

	public decimal? pordITotalPrice { get; set; }

	public string pordIDescription { get; set; }

	public int UserId { get; set; }

	public int FPId { get; set; }

	public short Month1 { get; set; }

	public DateTime RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	public string pordIQuantityDesc { get; set; }

	public decimal? pordIDiscount { get; set; }

	public decimal? pordIDiscountI { get; set; }

	public decimal? pordIDiscountPercent { get; set; }

	public decimal? pordIDiscountIPercent { get; set; }

	public Guid? GUId { get; set; }

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

	public decimal? pordIRound { get; set; }

	public string AppType { get; set; }

	public int? LanguageID { get; set; }

	public int? FirstRegisterUserId { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public DateTime? FirstRegisterDate { get; set; }

	public decimal? pordIRoundPlus { get; set; }

	public int? pordILinkAccItemId { get; set; }

	public int? pordIPrdPriceGroupID { get; set; }

	public string pordITracing { get; set; }

	public decimal? pordIPriceSum { get; set; }

	public decimal? pordIDiscountSum { get; set; }

	public decimal? pordIDiscountISum { get; set; }

	public decimal? pordITaxSum { get; set; }

	public int? pordIDeliveryTermId { get; set; }

	public DateTime? pordIDeliveryDate { get; set; }

	public string pordIDeliveryDatePersian { get; set; }

	public int? pordICostSheetItemId { get; set; }

	public string pordILinkAccItemIdStr { get; set; }

	public string pordILinkAccWHIdStr { get; set; }

	public double? pordIQuantityTotal { get; set; }

	public int? pordIPrdUnitIdI { get; set; }

	public double? pordIPrdUnitIRateResult { get; set; }

	public int? pordIPrdColorId { get; set; }

	public string pordIPrdNickname { get; set; }

	public string pordIDiscountDesc { get; set; }

	public string pordIDeliveryTime { get; set; }

	public string pordIDeliveryDay { get; set; }

	public DateTime? pordIDeliveryEndDate { get; set; }

	public string pordIDeliveryEndDatePersian { get; set; }

	public string pordIDeliveryEndTime { get; set; }

	public string pordIDeliveryEndDay { get; set; }

	public DateTime? pordIValidityExpireDate { get; set; }

	public string pordIValidityExpireDatePersian { get; set; }

	public decimal? pordIPrdAutoCalcRate { get; set; }

	public decimal? pordIPrdAutoCalcInflationRateInfo { get; set; }

	public string pordIDescriptionI { get; set; }

	public DateTime? pordILinkAccFirstTransferDate { get; set; }

	public DateTime? pordILinkAccLastTransferDate { get; set; }

	public int? pordIDiscountCodeId { get; set; }

	public int? pordIDiscountCodeUserId { get; set; }

	public DateTime? pordIDiscountCodeRegisterDate { get; set; }

	public string pordIDiscountCodeRegisterDatePersian { get; set; }

	public int? pordICurrencyUnitIdI { get; set; }

	public double? pordICurrencyUnitIRate { get; set; }

	public decimal? pordIPriceCurrencyI { get; set; }

	public decimal? pordITotalPriceCurrencyI { get; set; }

	public decimal? pordIDiscountCurrencyI { get; set; }

	public decimal? pordIDiscountICurrencyI { get; set; }

	public decimal? pordITaxCurrencyI { get; set; }

	public decimal? pordIRoundCurrencyI { get; set; }

	public decimal? pordIRoundPlusCurrencyI { get; set; }

	public decimal? pordIPriceSumCurrencyI { get; set; }

	public decimal? pordIDiscountSumCurrencyI { get; set; }

	public decimal? pordIDiscountISumCurrencyI { get; set; }

	public decimal? pordITaxSumCurrencyI { get; set; }

	public string pordILinkAccData { get; set; }

	public int? pordISaleCenterId { get; set; }

	public int? pordICId { get; set; }

	public int? pordILinkedParentItemId { get; set; }

	public int? pordILinkedParentPrdId { get; set; }

	public double? pordIPriceCurrencyRate { get; set; }

	public double? pordIPrdWeight { get; set; }

	public int? pordILinkAccSettingDBId { get; set; }

	public int? pordIPrdUnitIdII { get; set; }

	public double? pordIPrdUnitIIRateResult { get; set; }

	public virtual Languages Languages { get; set; }

	public virtual ICollection<WSBuyOrderItems> WSBuyOrderItems { get; set; }

	public virtual ICollection<WSCostSheetItems> WSCostSheetItems { get; set; }

	public virtual WSCostSheetItems WSCostSheetItems1 { get; set; }

	public virtual WSCurrencyUnits WSCurrencyUnits { get; set; }

	public virtual WSFinancialPeriod WSFinancialPeriod { get; set; }

	public virtual WSPreOrder WSPreOrder { get; set; }

	public virtual ICollection<WSPreOrderItems_Lang> WSPreOrderItems_Lang { get; set; }

	public virtual WSProductColor WSProductColor { get; set; }

	public virtual WSProductUnits WSProductUnits { get; set; }

	public virtual WSProductUnits WSProductUnits1 { get; set; }

	public virtual WsWareHouse WsWareHouse { get; set; }

	public virtual ICollection<WSPreOrderItemSpecification> WSPreOrderItemSpecification { get; set; }

	public virtual WSDeliveryTerms WSDeliveryTerms { get; set; }

	public virtual ICollection<WSStockSupplyItems> WSStockSupplyItems { get; set; }

	public virtual ICollection<WSOrderItems> WSOrderItems { get; set; }

	public virtual WSCurrencyUnits WSCurrencyUnits1 { get; set; }

	public virtual WSDiscountCode WSDiscountCode { get; set; }

	public virtual WSSaleCenters WSSaleCenters { get; set; }

	public virtual Centers Centers { get; set; }

	public virtual WSProducts WSProducts { get; set; }

	public virtual WSProducts WSProducts1 { get; set; }

	public virtual ICollection<WSDocItems> WSDocItems { get; set; }

	public virtual WSProductUnits WSProductUnits2 { get; set; }

	public virtual Users Users { get; set; }

	public virtual Users Users1 { get; set; }

	public virtual Users Users2 { get; set; }

	public WSPreOrderItems()
	{
		WSBuyOrderItems = (ICollection<WSBuyOrderItems>)new HashSet<WSBuyOrderItems>();
		WSCostSheetItems = (ICollection<WSCostSheetItems>)new HashSet<WSCostSheetItems>();
		WSPreOrderItems_Lang = (ICollection<WSPreOrderItems_Lang>)new HashSet<WSPreOrderItems_Lang>();
		WSPreOrderItemSpecification = (ICollection<WSPreOrderItemSpecification>)new HashSet<WSPreOrderItemSpecification>();
		WSStockSupplyItems = (ICollection<WSStockSupplyItems>)new HashSet<WSStockSupplyItems>();
		WSOrderItems = (ICollection<WSOrderItems>)new HashSet<WSOrderItems>();
		WSDocItems = (ICollection<WSDocItems>)new HashSet<WSDocItems>();
	}
}
