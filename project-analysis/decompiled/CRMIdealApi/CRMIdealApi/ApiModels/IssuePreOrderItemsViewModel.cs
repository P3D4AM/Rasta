using System;

namespace CRMIdealApi.ApiModels;

public class IssuePreOrderItemsViewModel
{
	public int PordItemId { get; set; }

	public int? PordIPrdId { get; set; }

	public string PordIPrdCode { get; set; }

	public double? PordIQuantity { get; set; }

	public decimal? PordIPrice { get; set; }

	public decimal? PordITotalPrice { get; set; }

	public string PordIDescription { get; set; }

	public string PordIQuantityDesc { get; set; }

	public decimal? PordIDiscount { get; set; }

	public decimal? PordIDiscountI { get; set; }

	public decimal? PordIDiscountPercent { get; set; }

	public decimal? PordIDiscountIPercent { get; set; }

	public int? PordIPrdUnitId { get; set; }

	public int? PordICurrencyUnitId { get; set; }

	public int? PordIOrderView { get; set; }

	public double? PordIFCR { get; set; }

	public decimal? PordITax { get; set; }

	public decimal? PordITaxIndex { get; set; }

	public bool? PordICalculateTax { get; set; }

	public bool? PordINotVisible { get; set; }

	public double? PordIFCRI { get; set; }

	public bool? PordINotInSum { get; set; }

	public int? PordIWHId { get; set; }

	public decimal? PordIRound { get; set; }

	public decimal? PordIRoundPlus { get; set; }

	public int? PordIPrdPriceGroupId { get; set; }

	public string PordITracing { get; set; }

	public DateTime? PordIValidityExpireDate { get; set; }

	public int? PordIDeliveryTermId { get; set; }

	public DateTime? PordIDeliveryDate { get; set; }

	public string PordIDeliveryTime { get; set; }

	public string PordIDeliveryDay { get; set; }

	public DateTime? PordIDeliveryEndDate { get; set; }

	public string PordIDeliveryEndTime { get; set; }

	public string PordIDeliveryEndDay { get; set; }

	public decimal? PordIPriceSum { get; set; }

	public decimal? PordIDiscountSum { get; set; }

	public decimal? PordITaxSum { get; set; }
}
