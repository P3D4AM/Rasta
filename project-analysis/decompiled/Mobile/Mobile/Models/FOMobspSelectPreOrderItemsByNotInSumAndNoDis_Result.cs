using System;

namespace Mobile.Models;

public class FOMobspSelectPreOrderItemsByNotInSumAndNoDis_Result
{
	public int PreOrderItemID { get; set; }

	public int PreOrderId { get; set; }

	public int pordIPrdId { get; set; }

	public double? pordIQuantity { get; set; }

	public decimal? pordIPrice { get; set; }

	public decimal? pordITotalPrice { get; set; }

	public string pordIDescription { get; set; }

	public int UserId { get; set; }

	public int FPId { get; set; }

	public short Month1 { get; set; }

	public DateTime RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	public string pordIQuantityDesc { get; set; }

	public decimal? pordIDiscount { get; set; }

	public decimal? pordIDiscountI { get; set; }

	public decimal? pordIDiscountPercent { get; set; }

	public decimal? pordIDiscountIPercent { get; set; }

	public Guid? GUId { get; set; }

	public int? pordIPrdUnitId { get; set; }

	public int? pordICurrencyUnitId { get; set; }

	public int? pordIOrderView { get; set; }

	public double? pordIFCR { get; set; }

	public decimal? pordITax { get; set; }

	public decimal? pordITaxIndex { get; set; }

	public bool? pordICalculateTax { get; set; }

	public bool? pordINotVisible { get; set; }

	public double? pordIFCRI { get; set; }

	public bool? pordINotInSum { get; set; }

	public int? pordIWHId { get; set; }

	public decimal? pordIRound { get; set; }

	public string AppType { get; set; }

	public int? LanguageID { get; set; }

	public int? FirstRegisterUserId { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public DateTime? FirstRegisterDate { get; set; }

	public decimal? pordIRoundPlus { get; set; }

	public string PrdName { get; set; }

	public string PrdCode { get; set; }

	public string PrdFGName { get; set; }

	public string PrdSGName { get; set; }

	public string PrdUnitName { get; set; }

	public string PrdCurrencyUnitPrice { get; set; }

	public int? pordIPrdPriceGroupID { get; set; }

	public string pordITracing { get; set; }

	public decimal? pordIPriceSum { get; set; }

	public decimal? pordIDiscountSum { get; set; }

	public decimal? pordIDiscountISum { get; set; }

	public decimal? pordITaxSum { get; set; }

	public string pordIPrdUnit { get; set; }

	public string pordICurrencyUnit { get; set; }

	public int? pordIDeliveryTermId { get; set; }

	public string pordIDeliveryTerm { get; set; }

	public DateTime? pordIDeliveryDate { get; set; }

	public string pordIDeliveryDatePersian { get; set; }

	public int? pordICostSheetItemId { get; set; }
}
