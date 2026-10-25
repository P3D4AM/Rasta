using System;

namespace Mobile.Models;

public class WSspRpt_PrintOrderItems_Result
{
	public int? OrderItemCount { get; set; }

	public int OrderItemID { get; set; }

	public int ordIPrdId { get; set; }

	public string PrdCode { get; set; }

	public string PrdName { get; set; }

	public string PrdFGName { get; set; }

	public string PrdSGName { get; set; }

	public string PrdGroup { get; set; }

	public string PrdLatinName { get; set; }

	public string PrdType { get; set; }

	public string PrdDesign { get; set; }

	public string PrdSize { get; set; }

	public string PrdColor { get; set; }

	public string PrdUnit { get; set; }

	public double? OrdIQuantity { get; set; }

	public decimal? ordIPrice { get; set; }

	public decimal? ordITotalPrice { get; set; }

	public string ordIDescription { get; set; }

	public int OIUserId { get; set; }

	public int OIFPId { get; set; }

	public short OIMonth1 { get; set; }

	public DateTime OIRegisterDate { get; set; }

	public string OIRegisterDatePersian { get; set; }

	public double? ordIPricePartRate { get; set; }

	public decimal? ordIPricePartI { get; set; }

	public decimal? ordIPricePartII { get; set; }

	public string ordITracing { get; set; }

	public decimal? ordIPriceSum { get; set; }

	public decimal? ordIDiscountSum { get; set; }

	public decimal? ordIDiscountISum { get; set; }

	public decimal? ordITaxSum { get; set; }

	public int? ordICurrencyUnitId { get; set; }

	public string ordICurrencyUnit { get; set; }

	public int? ordIDeliveryTermId { get; set; }

	public string ordIDeliveryTerm { get; set; }

	public DateTime? ordIDeliveryDate { get; set; }

	public string ordIDeliveryDatePersian { get; set; }

	public DateTime? ordIValidityExpireDate { get; set; }

	public string ordIValidityExpireDatePersian { get; set; }

	public double? ordIQuantityTotal { get; set; }

	public int? ordIPrdUnitId { get; set; }

	public string ordIPrdUnit { get; set; }

	public int? ordIPrdUnitIdI { get; set; }

	public string ordIPrdUnitI { get; set; }

	public double? ordIPrdUnitIRateResult { get; set; }

	public int? ordIPrdColorId { get; set; }

	public string ordIPrdColor { get; set; }

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

	public decimal? ordIPrdAutoCalcRate { get; set; }

	public decimal? ordIPrdAutoCalcInflationRateInfo { get; set; }

	public string ordIDescriptionI { get; set; }

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

	public int? ordIDiscountCodeId { get; set; }

	public string ordIDiscountCode { get; set; }

	public int? ordIDiscountCodeUserId { get; set; }

	public string ordIDiscountCodeUser { get; set; }

	public DateTime? ordIDiscountCodeRegisterDate { get; set; }

	public string ordIDiscountCodeRegisterDatePersian { get; set; }

	public string PrdLocation { get; set; }

	public double? PrdWeight { get; set; }

	public int? ordICId { get; set; }

	public string ordICenterName { get; set; }

	public int? ordIPrdUnitIdII { get; set; }

	public string ordIPrdUnitII { get; set; }

	public double? ordIPrdUnitIIRateResult { get; set; }

	public double? ordIPriceCurrencyRate { get; set; }
}
