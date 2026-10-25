using System;

namespace CRMIdealApi.ApiModels;

public class IssueOrderItemsViewModel
{
	public int? OrdIPrdId { get; set; }

	public string OrdIPrdCode { get; set; }

	public double? OrdIQuantity { get; set; }

	public decimal? OrdIPrice { get; set; }

	public decimal? OrdITotalPrice { get; set; }

	public string OrdIDescription { get; set; }

	public string OrdIQuantityDesc { get; set; }

	public decimal? OrdIDiscountI { get; set; }

	public decimal? OrdIDiscount { get; set; }

	public decimal? OrdIDiscountPercent { get; set; }

	public decimal? OrdIDiscountIPercent { get; set; }

	public int? OrdIPrdUnitId { get; set; }

	public int? OrdICurrencyUnitId { get; set; }

	public int? OrdIOrderView { get; set; }

	public double? OrdIFCR { get; set; }

	public decimal? OrdITax { get; set; }

	public decimal? OrdITaxIndex { get; set; }

	public bool? OrdICalculateTax { get; set; }

	public bool? OrdINotVisible { get; set; }

	public double? OrdIFCRI { get; set; }

	public bool? OrdINotInSum { get; set; }

	public decimal? OrdIRound { get; set; }

	public decimal? OrdIRoundPlus { get; set; }

	public double? OrdIPricePartRate { get; set; }

	public decimal? OrdIPricePartI { get; set; }

	public decimal? OrdIPricePartII { get; set; }

	public int? OrdIPrdPriceGroupID { get; set; }

	public string OrdITracing { get; set; }

	public DateTime? OrdIValidityExpireDate { get; set; }

	public int? OrdIValidityExpireDay { get; set; }

	public int? OrdIValidityExpireHour { get; set; }

	public int? OrdIValidityExpireMinute { get; set; }

	public int? OrdIPrdValidityCountingMin { get; set; }

	public int? OrdIPrdValidityCountingNum { get; set; }

	public int? OrdIDeliveryTermId { get; set; }

	public DateTime? OrdIDeliveryDate { get; set; }

	public string OrdIDeliveryTime { get; set; }

	public string OrdIDeliveryDay { get; set; }

	public DateTime? OrdIDeliveryEndDate { get; set; }

	public string OrdIDeliveryEndTime { get; set; }

	public string OrdIDeliveryEndDay { get; set; }

	public int? OrdIDeliveryUserId { get; set; }

	public decimal? OrdIPriceSum { get; set; }

	public decimal? OrdIDiscountSum { get; set; }

	public decimal? OrdITaxSum { get; set; }
}
