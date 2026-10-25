using System;

namespace CRM.Models;

public class LkOrderItemViewModel
{
	public bool Selected { get; set; }

	public int InsertedId { get; set; }

	public int OrderItemID { get; set; }

	public int OrderId { get; set; }

	public int ordIPrdId { get; set; }

	public float? ordIQuantity { get; set; }

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

	public float? ordIFCR { get; set; }

	public decimal? ordITax { get; set; }

	public decimal? ordITaxIndex { get; set; }

	public bool? ordICalculateTax { get; set; }

	public bool? ordINotVisible { get; set; }

	public float? ordIFCRI { get; set; }

	public bool? ordINotInSum { get; set; }

	public int? ordIWHId { get; set; }

	public decimal? ordIRound { get; set; }

	public string AppType { get; set; }

	public int? LanguageID { get; set; }

	public int? FirstRegisterUserId { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public DateTime? FirstRegisterDate { get; set; }

	public decimal? ordIRoundPlus { get; set; }

	public float? ordIPricePartRate { get; set; }

	public decimal? ordIPricePartI { get; set; }

	public decimal? ordIPricePartII { get; set; }

	public int? ordILinkAccItemId { get; set; }

	public int? ordIPrdPriceGroupID { get; set; }

	public string ordITracing { get; set; }

	public string ordILinkAccItemIdStr { get; set; }

	public decimal? ordIPriceSum { get; set; }

	public decimal? ordIDiscountISum { get; set; }

	public decimal? ordIDiscountSum { get; set; }

	public decimal? ordITaxSum { get; set; }

	public int? ordIDeliveryTermId { get; set; }

	public DateTime? ordIDeliveryDate { get; set; }

	public string ordIDeliveryDatePersian { get; set; }

	public string ordILinkAccWHIdStr { get; set; }

	public DateTime? ordIValidityExpireDate { get; set; }

	public string ordIValidityExpireDatePersian { get; set; }

	public float? ordIQuantityTotal { get; set; }

	public int? ordIPrdUnitIdI { get; set; }

	public float? ordIPrdUnitIRateResult { get; set; }

	public int? ordIPrdColorId { get; set; }

	public int? ordIPrdValidityCountingNum { get; set; }

	public int? ordIPrdValidityCountingMin { get; set; }
}
