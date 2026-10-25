using System;

namespace Mobile.Models;

public class MobspSelectBuyOrderItems_Result
{
	public int BuyOrderItemId { get; set; }

	public int BuyOrderId { get; set; }

	public int bordIPrdId { get; set; }

	public double bordIQuantity { get; set; }

	public decimal bordICost { get; set; }

	public decimal bordITotalCost { get; set; }

	public string bordIDescription { get; set; }

	public int UserId { get; set; }

	public int FPId { get; set; }

	public DateTime RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	public string bordIQuantityDesc { get; set; }

	public decimal bordIDiscount { get; set; }

	public decimal bordIDiscountI { get; set; }

	public decimal bordIDiscountPercent { get; set; }

	public decimal bordIDiscountIPercent { get; set; }

	public int bordIPrdUnitId { get; set; }

	public int bordICurrencyUnitId { get; set; }

	public int bordIOrderView { get; set; }

	public double bordIFCR { get; set; }

	public decimal bordITax { get; set; }

	public decimal bordITaxIndex { get; set; }

	public bool bordICalculateTax { get; set; }

	public bool bordINotVisible { get; set; }

	public double bordIFCRI { get; set; }

	public bool bordINotInSum { get; set; }

	public int bordIWHId { get; set; }

	public string AppType { get; set; }

	public int LanguageID { get; set; }

	public int FirstRegisterUserId { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public DateTime? FirstRegisterDate { get; set; }

	public string bordIPrdName { get; set; }

	public string bordIPrdCode { get; set; }

	public string bordIPrdFGName { get; set; }

	public string bordIPrdSGName { get; set; }

	public string RegisterUser { get; set; }

	public string bordIPrdUnitName { get; set; }

	public string bordIPrdCurrencyUnitCost { get; set; }

	public string bordIPrdUnit { get; set; }

	public string bordICurrencyUnit { get; set; }

	public string bordIPrdFirstBarcode { get; set; }

	public string bordIWH { get; set; }

	public string FirstRegisterUser { get; set; }

	public string PrdLocation { get; set; }

	public double? PrdWeight { get; set; }
}
