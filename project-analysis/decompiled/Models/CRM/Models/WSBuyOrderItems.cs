using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(WSBuyOrderItemsMetadata))]
public class WSBuyOrderItems
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

	public double? bordIFreightCurrencyRate { get; set; }

	public decimal? bordIFinalFreightCost { get; set; }

	public string bordICustomsPart { get; set; }

	public decimal? bordICustomsFee { get; set; }

	public int? bordICustomsCurrUnId { get; set; }

	public double? bordICustomsCurrencyRate { get; set; }

	public decimal? bordIFinalCustomsFee { get; set; }

	public decimal? bordITotalFinalCost { get; set; }

	public int? bordIPreOrderItemId { get; set; }

	public decimal? bordICommission { get; set; }

	public int? bordICommissionCurrUnId { get; set; }

	public double? bordICommissionCurrencyRate { get; set; }

	public decimal? bordIFinalCommission { get; set; }

	public int? bordICostSheetItemId { get; set; }

	public string bordILinkAccWHIdStr { get; set; }

	public double? bordIQuantityTotal { get; set; }

	public int? bordIPrdUnitIdI { get; set; }

	public double? bordIPrdUnitIRateResult { get; set; }

	public int? bordIPrdColorId { get; set; }

	public string bordIPrdNickname { get; set; }

	public DateTime? bordILinkAccFirstTransferDate { get; set; }

	public DateTime? bordILinkAccLastTransferDate { get; set; }

	public string bordILinkAccItemIdStr { get; set; }

	public int? bordICurrencyUnitIdI { get; set; }

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

	public double? bordICostCurrencyRate { get; set; }

	public double? bordIPrdWeight { get; set; }

	public int? bordILinkAccSettingDBId { get; set; }

	public int? bordIPrdUnitIdII { get; set; }

	public double? bordIPrdUnitIIRateResult { get; set; }

	public virtual Languages Languages { get; set; }

	public virtual WSBuyOrder WSBuyOrder { get; set; }

	public virtual WSCurrencyUnits WSCurrencyUnits { get; set; }

	public virtual WSCurrencyUnits WSCurrencyUnits1 { get; set; }

	public virtual WSCurrencyUnits WSCurrencyUnits2 { get; set; }

	public virtual ICollection<WSBuyOrderItems_Lang> WSBuyOrderItems_Lang { get; set; }

	public virtual WSCostSheetItems WSCostSheetItems { get; set; }

	public virtual WSCurrencyUnits WSCurrencyUnits3 { get; set; }

	public virtual WSFinancialPeriod WSFinancialPeriod { get; set; }

	public virtual WSProductUnits WSProductUnits { get; set; }

	public virtual WsWareHouse WsWareHouse { get; set; }

	public virtual ICollection<WSBuyOrderItemSerials> WSBuyOrderItemSerials { get; set; }

	public virtual ICollection<WSCostSheetItems> WSCostSheetItems1 { get; set; }

	public virtual WSProductUnits WSProductUnits1 { get; set; }

	public virtual WSProductColor WSProductColor { get; set; }

	public virtual WSPreOrderItems WSPreOrderItems { get; set; }

	public virtual WSCurrencyUnits WSCurrencyUnits31 { get; set; }

	public virtual Centers Centers { get; set; }

	public virtual WSProducts WSProducts { get; set; }

	public virtual ICollection<WSDocItems> WSDocItems { get; set; }

	public virtual WSProductUnits WSProductUnits2 { get; set; }

	public virtual Users Users { get; set; }

	public virtual Users Users1 { get; set; }

	public WSBuyOrderItems()
	{
		WSBuyOrderItems_Lang = (ICollection<WSBuyOrderItems_Lang>)new HashSet<WSBuyOrderItems_Lang>();
		WSBuyOrderItemSerials = (ICollection<WSBuyOrderItemSerials>)new HashSet<WSBuyOrderItemSerials>();
		WSCostSheetItems1 = (ICollection<WSCostSheetItems>)new HashSet<WSCostSheetItems>();
		WSDocItems = (ICollection<WSDocItems>)new HashSet<WSDocItems>();
	}
}
