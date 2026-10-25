using System;

namespace CRMIdealApi.ApiModels;

public class UpdatePreOrderItemsViewModel
{
	public string UserName { get; set; }

	public string Password { get; set; }

	public int UserId { get; set; }

	public int? ApiPreOrderId { get; set; }

	public int ApiPreOrderItemId { get; set; }

	public int? ApiPordIPrdId { get; set; }

	public double? ApiPordIQuantity { get; set; }

	public decimal? ApiPordIPrice { get; set; }

	public decimal? ApiPordITotalPrice { get; set; }

	public string ApiPordIDescription { get; set; }

	public string ApiPordIQuantityDesc { get; set; }

	public decimal? ApiPordIDiscount { get; set; }

	public decimal? ApiPordIDiscountI { get; set; }

	public decimal? ApiPordIDiscountPercent { get; set; }

	public decimal? ApiPordIDiscountIPercent { get; set; }

	public int? ApiPordIPrdUnitId { get; set; }

	public int? ApiPordICurrencyUnitId { get; set; }

	public int? ApiPordIOrderView { get; set; }

	public double? ApiPordIFCR { get; set; }

	public decimal? ApiPordITax { get; set; }

	public decimal? ApiPordITaxIndex { get; set; }

	public bool? ApiPordICalculateTax { get; set; }

	public bool? ApiPordINotVisible { get; set; }

	public double? ApiPordIFCRI { get; set; }

	public bool? ApiPordINotInSum { get; set; }

	public int? ApiPordIWHId { get; set; }

	public decimal? ApiPordIRound { get; set; }

	public decimal? ApiPordIRoundPlus { get; set; }

	public int? ApiPordIPrdPriceGroupId { get; set; }

	public string ApiPordITracing { get; set; }

	public int? LanguageId { get; set; }

	public DateTime? ApiPordIValidityExpireDate { get; set; }

	public string ApiPordIValidityExpireDatePersian { get; set; }

	public int? ApiPordIDeliveryTermId { get; set; }

	public DateTime? ApiPordIDeliveryDate { get; set; }

	public string ApiPordIDeliveryDatePersian { get; set; }

	public string ApiPordIDeliveryTime { get; set; }

	public string ApiPordIDeliveryDay { get; set; }

	public DateTime? ApiPordIDeliveryEndDate { get; set; }

	public string ApiPordIDeliveryEndDatePersian { get; set; }

	public string ApiPordIDeliveryEndTime { get; set; }

	public string ApiPordIDeliveryEndDay { get; set; }

	public int? ApiPordILinkAccItemId { get; set; }

	public string ApiPordILinkAccItemIdStr { get; set; }

	public string ApiPordILinkAccWHIdStr { get; set; }

	public DateTime? ApiPordILinkAccFirstTransferDate { get; set; }

	public DateTime? ApiPordILinkAccLastTransferDate { get; set; }

	public string ApiPordILinkAccData { get; set; }

	public decimal? ApiPordIPriceSum { get; set; }

	public decimal? ApiPordIDiscountSum { get; set; }

	public decimal? ApiPordITaxSum { get; set; }
}
