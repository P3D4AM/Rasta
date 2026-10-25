using System;

namespace CRM.Models;

public class WSspSelectOrderItemsWithRefOrdId_Result
{
	public int OrderItemID { get; set; }

	public int OrderId { get; set; }

	public int ordIPrdId { get; set; }

	public double? ordIQuantity { get; set; }

	public decimal? ordIPrice { get; set; }

	public decimal? ordITotalPrice { get; set; }

	public string ordIDescription { get; set; }

	public int UserId { get; set; }

	public string EditUser { get; set; }

	public int FPId { get; set; }

	public short Month1 { get; set; }

	public DateTime RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	public string ordIQuantityDesc { get; set; }

	public decimal? ordIDiscountI { get; set; }

	public decimal? ordIDiscount { get; set; }

	public decimal? ordIDiscountPercent { get; set; }

	public decimal? ordIDiscountIPercent { get; set; }

	public int? ordIPrdUnitId { get; set; }

	public string ordIPrdUnit { get; set; }

	public int? ordICurrencyUnitId { get; set; }

	public string ordICurrencyUnit { get; set; }

	public int? ordIOrderView { get; set; }

	public double? ordIFCR { get; set; }

	public decimal? ordITax { get; set; }

	public decimal? ordITaxIndex { get; set; }

	public bool? ordICalculateTax { get; set; }

	public bool? ordINotVisible { get; set; }

	public double? ordIFCRI { get; set; }

	public bool? ordINotInSum { get; set; }

	public int? ordIWHId { get; set; }

	public string ordIWH { get; set; }

	public decimal? ordIRound { get; set; }

	public string AppType { get; set; }

	public int? LanguageID { get; set; }

	public int? FirstRegisterUserId { get; set; }

	public string FirstRegisterUser { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public DateTime? FirstRegisterDate { get; set; }

	public decimal? ordIRoundPlus { get; set; }

	public double? ordIPricePartRate { get; set; }

	public decimal? ordIPricePartI { get; set; }

	public decimal? ordIPricePartII { get; set; }

	public int? ordILinkAccItemId { get; set; }

	public int? ordIPrdPriceGroupID { get; set; }

	public string ordIPrdPriceGroup { get; set; }

	public string ordITracing { get; set; }

	public string ordILinkAccItemIdStr { get; set; }

	public decimal? ordIPriceSum { get; set; }

	public decimal? ordIDiscountISum { get; set; }

	public decimal? ordIDiscountSum { get; set; }

	public decimal? ordITaxSum { get; set; }

	public int? ordIDeliveryTermId { get; set; }

	public string ordIDeliveryTerm { get; set; }

	public DateTime? ordIDeliveryDate { get; set; }

	public string ordIDeliveryDatePersian { get; set; }

	public string ordILinkAccWHIdStr { get; set; }

	public DateTime? ordIValidityExpireDate { get; set; }

	public string ordIValidityExpireDatePersian { get; set; }

	public double? ordIQuantityTotal { get; set; }

	public int? ordIPrdUnitIdI { get; set; }

	public string ordIPrdUnitI { get; set; }

	public double? ordIPrdUnitIRateResult { get; set; }

	public int? ordIPrdColorId { get; set; }

	public string ordIPrdColor { get; set; }

	public int? ordIPrdValidityCountingNum { get; set; }

	public int? ordIPrdValidityCountingMin { get; set; }

	public string ordIPrdNickname { get; set; }

	public string ordIDiscountDesc { get; set; }

	public decimal? TspOrdICfee { get; set; }

	public string TspOrdICut { get; set; }

	public decimal? TspOrdIExr { get; set; }

	public string TspOrdIOdt { get; set; }

	public decimal? TspOrdIOdr { get; set; }

	public decimal? TspOrdIOdam { get; set; }

	public string TspOrdIOlt { get; set; }

	public decimal? TspOrdIOlr { get; set; }

	public decimal? TspOrdIOlam { get; set; }

	public decimal? TspOrdIConsfee { get; set; }

	public decimal? TspOrdISpro { get; set; }

	public decimal? TspOrdIBros { get; set; }

	public decimal? TspOrdICop { get; set; }

	public decimal? TspOrdIVop { get; set; }

	public double? TspOrdINw { get; set; }

	public decimal? TspOrdISsrv { get; set; }

	public decimal? TspOrdISscv { get; set; }

	public string ordIDeliveryTime { get; set; }

	public string ordIDeliveryDay { get; set; }

	public DateTime? ordIDeliveryEndDate { get; set; }

	public string ordIDeliveryEndDatePersian { get; set; }

	public string ordIDeliveryEndTime { get; set; }

	public string ordIDeliveryEndDay { get; set; }

	public decimal? ordIPrdAutoCalcRate { get; set; }

	public decimal? ordIPrdAutoCalcInflationRateInfo { get; set; }

	public string ordIDescriptionI { get; set; }

	public int? ordIDeliveryUserId { get; set; }

	public string ordIDeliveryUser { get; set; }

	public bool? ordIDeActiveModuleInReg { get; set; }

	public DateTime? ordILinkAccFirstTransferDate { get; set; }

	public DateTime? ordILinkAccLastTransferDate { get; set; }

	public decimal? TspOrdIPspd { get; set; }

	public decimal? TspOrdICui { get; set; }

	public int? PreOrderItemId { get; set; }

	public string BuyOrderItemIds { get; set; }

	public int? ordIDiscountCodeId { get; set; }

	public int? ordIDiscountCodeUserId { get; set; }

	public string ordIDiscountCodeUser { get; set; }

	public DateTime? ordIDiscountCodeRegisterDate { get; set; }

	public string ordIDiscountCodeRegisterDatePersian { get; set; }

	public int? ordICurrencyUnitIdI { get; set; }

	public string ordICurrencyUnitI { get; set; }

	public double? ordICurrencyUnitIRate { get; set; }

	public decimal? ordIPriceCurrencyI { get; set; }

	public decimal? ordITotalPriceCurrencyI { get; set; }

	public decimal? ordIDiscountICurrencyI { get; set; }

	public decimal? ordIDiscountCurrencyI { get; set; }

	public decimal? ordITaxCurrencyI { get; set; }

	public decimal? ordIRoundCurrencyI { get; set; }

	public decimal? ordIRoundPlusCurrencyI { get; set; }

	public decimal? ordIPriceSumCurrencyI { get; set; }

	public decimal? ordIDiscountISumCurrencyI { get; set; }

	public decimal? ordIDiscountSumCurrencyI { get; set; }

	public decimal? ordITaxSumCurrencyI { get; set; }

	public string ordILinkAccData { get; set; }

	public int? ordISaleCenterId { get; set; }

	public string ordISaleCenter { get; set; }

	public int? ordICId { get; set; }

	public string ordICenterName { get; set; }

	public string TspOrdIBsrn { get; set; }

	public int? ordILinkedParentItemId { get; set; }

	public int? ordILinkedParentPrdId { get; set; }

	public double? ordIPriceCurrencyRate { get; set; }

	public int? ordIRefOrderItemId { get; set; }

	public string ordDate { get; set; }

	public DateTime? ordDateTime { get; set; }

	public int? OrderOprID { get; set; }

	public string OrderOpr { get; set; }

	public string PrdDefQuantity { get; set; }

	public bool? PrdJustDefQuantity { get; set; }
}
