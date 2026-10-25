using System;

namespace CRMIdealApi.ApiModels;

public class InsertOrderItemViewModel
{
	public string UserName { get; set; }

	public string Password { get; set; }

	public int UserId { get; set; }

	public int? ApiOrderId { get; set; }

	public long? ApiOrdNumber { get; set; }

	public int? ApiOrdIPrdId { get; set; }

	public string ApiOrdIPrdCode { get; set; }

	public double? ApiOrdIQuantity { get; set; }

	public decimal? ApiOrdIPrice { get; set; }

	public decimal? ApiOrdITotalPrice { get; set; }

	public string ApiOrdIDescription { get; set; }

	public string ApiOrdIQuantityDesc { get; set; }

	public decimal? ApiOrdIDiscountI { get; set; }

	public decimal? ApiOrdIDiscount { get; set; }

	public decimal? ApiOrdIDiscountPercent { get; set; }

	public decimal? ApiOrdIDiscountIPercent { get; set; }

	public int? ApiOrdIPrdUnitId { get; set; }

	public int? ApiOrdICurrencyUnitId { get; set; }

	public int? ApiOrdIOrderView { get; set; }

	public double? ApiOrdIFCR { get; set; }

	public decimal? ApiOrdITax { get; set; }

	public decimal? ApiOrdITaxIndex { get; set; }

	public bool? ApiOrdICalculateTax { get; set; }

	public bool? ApiOrdINotVisible { get; set; }

	public double? ApiOrdIFCRI { get; set; }

	public bool? ApiOrdINotInSum { get; set; }

	public decimal? ApiOrdIRound { get; set; }

	public decimal? ApiOrdIRoundPlus { get; set; }

	public double? ApiOrdIPricePartRate { get; set; }

	public decimal? ApiOrdIPricePartI { get; set; }

	public decimal? ApiOrdIPricePartII { get; set; }

	public int? ApiOrdIWHId { get; set; }

	public int? ApiOrdIPrdPriceGroupID { get; set; }

	public string ApiOrdITracing { get; set; }

	public DateTime? ApiOrdIValidityExpireDate { get; set; }

	public int? ApiOrdIValidityExpireDay { get; set; }

	public int? ApiOrdIValidityExpireHour { get; set; }

	public int? ApiOrdIValidityExpireMinute { get; set; }

	public int? LanguageId { get; set; }

	public int? ApiOrdIPrdValidityCountingMin { get; set; }

	public int? ApiOrdIPrdValidityCountingNum { get; set; }

	public int? ApiOrdIDeliveryTermId { get; set; }

	public DateTime? ApiOrdIDeliveryDate { get; set; }

	public string ApiOrdIDeliveryTime { get; set; }

	public string ApiOrdIDeliveryDay { get; set; }

	public DateTime? ApiOrdIDeliveryEndDate { get; set; }

	public string ApiOrdIDeliveryEndTime { get; set; }

	public string ApiOrdIDeliveryEndDay { get; set; }

	public int? ApiOrdIDeliveryUserId { get; set; }

	public int? CenterId { get; set; }

	public string CenterCode { get; set; }

	public int? ApiOrdILinkAccItemId { get; set; }

	public string ApiOrdILinkAccItemIdStr { get; set; }

	public string ApiOrdILinkAccWHIdStr { get; set; }

	public DateTime? ApiOrdILinkAccFirstTransferDate { get; set; }

	public DateTime? ApiOrdILinkAccLastTransferDate { get; set; }

	public string ApiOrdILinkAccData { get; set; }

	public decimal? ApiOrdIPriceSum { get; set; }

	public decimal? ApiOrdIDiscountSum { get; set; }

	public decimal? ApiOrdITaxSum { get; set; }
}
