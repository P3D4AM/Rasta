using System;

namespace CRM.Models;

public class WSspSelectOrderItems_Result
{
	public int OrderItemID { get; set; }

	public int OrderId { get; set; }

	public int ordIPrdId { get; set; }

	public double? ordIQuantity { get; set; }

	public decimal? ordIPrice { get; set; }

	public decimal? ordITotalPrice { get; set; }

	public string ordIDescription { get; set; }

	public int UserId { get; set; }

	public int FPId { get; set; }

	public short Month1 { get; set; }

	public DateTime RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	public string ordIQuantityDesc { get; set; }

	public decimal? ordIDiscountI { get; set; }

	public decimal? ordIDiscount { get; set; }

	public decimal? ordIDiscountPercent { get; set; }

	public decimal? ordIDiscountIPercent { get; set; }

	public Guid? GUId { get; set; }

	public int? ordIPrdUnitId { get; set; }

	public int? ordICurrencyUnitId { get; set; }

	public int? ordIOrderView { get; set; }

	public double? ordIFCR { get; set; }

	public decimal? ordITax { get; set; }

	public decimal? ordITaxIndex { get; set; }

	public bool? ordICalculateTax { get; set; }

	public bool? ordINotVisible { get; set; }

	public double? ordIFCRI { get; set; }

	public bool? ordINotInSum { get; set; }

	public int? ordIWHId { get; set; }

	public string ordIWrhsName { get; set; }

	public decimal? ordIRound { get; set; }

	public string AppType { get; set; }

	public int? LanguageID { get; set; }

	public int? FirstRegisterUserId { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public DateTime? FirstRegisterDate { get; set; }

	public decimal? ordIRoundPlus { get; set; }

	public string PrdName { get; set; }

	public string PrdCode { get; set; }

	public string PrdFGName { get; set; }

	public string PrdSGName { get; set; }

	public string PrdUnitName { get; set; }

	public string PrdCurrencyUnitPrice { get; set; }

	public string PrdFirstBarcode { get; set; }

	public int? ordIPrdPriceGroupID { get; set; }

	public string ordITracing { get; set; }

	public int? ordILinkAccItemId { get; set; }

	public string ordILinkAccItemIdStr { get; set; }

	public decimal? ordIPriceSum { get; set; }

	public decimal? ordIDiscountISum { get; set; }

	public decimal? ordIDiscountSum { get; set; }

	public decimal? ordITaxSum { get; set; }

	public string ordIPrdUnit { get; set; }

	public string ordICurrencyUnit { get; set; }

	public int? ordIDeliveryTermId { get; set; }

	public string ordIDeliveryTerm { get; set; }

	public DateTime? ordIDeliveryDate { get; set; }

	public string ordIDeliveryDatePersian { get; set; }

	public string ordILinkAccWHIdStr { get; set; }

	public double? ordIQuantityTotal { get; set; }

	public int? ordIPrdColorId { get; set; }

	public string ordIPrdColor { get; set; }

	public int? ordIPrdUnitIdI { get; set; }

	public string ordIPrdUnitI { get; set; }

	public double? ordIPrdUnitIRateResult { get; set; }

	public bool? PrdSingleItem { get; set; }

	public double? ordIPrdUnitIRate { get; set; }

	public string PrdModuleName { get; set; }

	public DateTime? ordIValidityExpireDate { get; set; }

	public string ordIValidityExpireDatePersian { get; set; }

	public string ordIDescriptionI { get; set; }

	public decimal? ordIPrdAutoCalcRate { get; set; }

	public decimal? ordIPrdAutoCalcInflationRateInfo { get; set; }

	public int? ordIPrdValidityCountingNum { get; set; }

	public int? ordIPrdValidityCountingMin { get; set; }

	public string ordIPrdNickname { get; set; }

	public string ordIDiscountDesc { get; set; }

	public string ordIDeliveryTime { get; set; }

	public string ordIDeliveryDay { get; set; }

	public DateTime? ordIDeliveryEndDate { get; set; }

	public string ordIDeliveryEndDatePersian { get; set; }

	public string ordIDeliveryEndTime { get; set; }

	public string ordIDeliveryEndDay { get; set; }

	public int? ordIDeliveryUserId { get; set; }

	public string ordIDeliveryUser { get; set; }

	public string PrdManufacturerCode { get; set; }

	public string PrdManufacturerName { get; set; }

	public string ordIDescriptionI_Lang { get; set; }

	public bool? ordIDeActiveModuleInReg { get; set; }

	public int? ordIDiscountCodeId { get; set; }

	public string ordIDiscountCode { get; set; }

	public int? ordIDiscountCodeUserId { get; set; }

	public string ordIDiscountCodeUser { get; set; }

	public DateTime? ordIDiscountCodeRegisterDate { get; set; }

	public string ordIDiscountCodeRegisterDatePersian { get; set; }

	public string ordIPrdNameAndDesc { get; set; }

	public string TspPrdIndentify { get; set; }

	public string TspPrdName { get; set; }

	public string TspFGIndentify { get; set; }

	public string TspFGName { get; set; }

	public string TspSGIndentify { get; set; }

	public string TspSGName { get; set; }

	public decimal? ordIPriceSumWithoutDiscount { get; set; }

	public string PrdRowColor { get; set; }

	public string PrdLocation { get; set; }

	public double? PrdWeight { get; set; }

	public int? itemOrderView { get; set; }

	public int? ordILinkedParentItemId { get; set; }

	public int? ordILinkedParentPrdId { get; set; }

	public long? RowNumber { get; set; }

	public string ordILinkedParentPrdName { get; set; }

	public string ordILinkedParentPrdCode { get; set; }

	public string PrdDefQuantity { get; set; }

	public bool? PrdJustDefQuantity { get; set; }

	public int? ordILinkAccSettingDBId { get; set; }

	public double? ordIPrdWeight { get; set; }
}
