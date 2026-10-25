using System;

namespace CRMIdealApi.ApiModels;

public class ApispSelectPreOrderItems_Result
{
	public int ApiPreOrderItemID { get; set; }

	public int ApiPreOrderId { get; set; }

	public string ApiPreOrder { get; set; }

	public int ApipordIPrdId { get; set; }

	public string ApipordIPrd { get; set; }

	public double? ApipordIQuantity { get; set; }

	public decimal? ApipordIPrice { get; set; }

	public decimal? ApipordITotalPrice { get; set; }

	public string ApipordIDescription { get; set; }

	public int ApiFPId { get; set; }

	public string ApipordIQuantityDesc { get; set; }

	public decimal? ApipordIDiscount { get; set; }

	public decimal? ApipordIDiscountI { get; set; }

	public decimal? ApipordIDiscountPercent { get; set; }

	public decimal? ApipordIDiscountIPercent { get; set; }

	public int? ApipordIPrdUnitId { get; set; }

	public string ApipordIPrdUnit { get; set; }

	public int? ApipordICurrencyUnitId { get; set; }

	public string ApipordICurrencyUnit { get; set; }

	public int? ApipordIOrderView { get; set; }

	public double? ApipordIFCR { get; set; }

	public decimal? ApipordITax { get; set; }

	public decimal? ApipordITaxIndex { get; set; }

	public bool? ApipordICalculateTax { get; set; }

	public bool? ApipordINotVisible { get; set; }

	public double? ApipordIFCRI { get; set; }

	public bool? ApipordINotInSum { get; set; }

	public int? ApipordIWHId { get; set; }

	public string ApipordIWH { get; set; }

	public decimal? ApipordIRound { get; set; }

	public decimal? ApipordIRoundPlus { get; set; }

	public int? ApipordIPrdPriceGroupID { get; set; }

	public string ApipordIPrdPriceGroup { get; set; }

	public string ApipordITracing { get; set; }

	public int ApiUserId { get; set; }

	public string ApiEditUser { get; set; }

	public DateTime ApiRegisterDate { get; set; }

	public int? ApiFirstRegisterUserId { get; set; }

	public string ApiFirstRegisterUser { get; set; }

	public DateTime? ApiFirstRegisterDate { get; set; }

	public decimal? ApipordIPriceSum { get; set; }

	public decimal? ApipordIDiscountSum { get; set; }

	public decimal? ApipordIDiscountISum { get; set; }

	public decimal? ApipordITaxSum { get; set; }

	public string ApipordIPrdLinkAccPrdCode { get; set; }

	public DateTime? ApipordIValidityExpireDate { get; set; }

	public int? ApipordIDeliveryTermId { get; set; }

	public DateTime? ApipordIDeliveryDate { get; set; }

	public string ApipordIDeliveryTime { get; set; }

	public string ApipordIDeliveryDay { get; set; }

	public DateTime? ApipordIDeliveryEndDate { get; set; }

	public string ApipordIDeliveryEndTime { get; set; }

	public string ApipordIDeliveryEndDay { get; set; }

	public int? ApiPordILinkAccItemId { get; set; }

	public string ApiPordILinkAccItemIdStr { get; set; }

	public string ApiPordILinkAccWHIdStr { get; set; }

	public DateTime? ApiPordILinkAccFirstTransferDate { get; set; }

	public DateTime? ApiPordILinkAccLastTransferDate { get; set; }

	public string ApiPordILinkAccData { get; set; }

	public int? ApiPordICId { get; set; }
}
