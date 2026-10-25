using System;

namespace Mobile.Models;

public class MobspSelectDocItemsWithPordIPrice_Result
{
	public int DocItemID { get; set; }

	public int DocId { get; set; }

	public int PrdId { get; set; }

	public double? Quantity { get; set; }

	public int? CostId { get; set; }

	public decimal? Cost { get; set; }

	public string Description { get; set; }

	public short? IsFix { get; set; }

	public int? WHId { get; set; }

	public int UserId { get; set; }

	public short Month1 { get; set; }

	public int FPId { get; set; }

	public DateTime RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	public Guid? GUId { get; set; }

	public bool? NotVisible { get; set; }

	public string AppType { get; set; }

	public int? LanguageID { get; set; }

	public int? FirstRegisterUserId { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public DateTime? FirstRegisterDate { get; set; }

	public string prdName { get; set; }

	public string prdCode { get; set; }

	public string PrdFirstBarcode { get; set; }

	public string PrdSGroup { get; set; }

	public string PrdFGroup { get; set; }

	public string PrdGroup { get; set; }

	public double? FCR { get; set; }

	public double? FCRI { get; set; }

	public string Tracing { get; set; }

	public int? DocILinkAccItemId { get; set; }

	public string DocILinkAccItemIdStr { get; set; }

	public int? PrdUnitId { get; set; }

	public string PrdUnit { get; set; }

	public double? QuantityTotal { get; set; }

	public int? PrdUnitIdI { get; set; }

	public string PrdUnitI { get; set; }

	public double? PrdUnitIRateResult { get; set; }

	public decimal? pordIPrice { get; set; }

	public int? pordIPrdPriceGroupID { get; set; }

	public double? pordIPriceCurrencyRate { get; set; }

	public double? DocIPrdWeight { get; set; }

	public decimal? pordITaxIndex { get; set; }

	public decimal? pordIDiscount { get; set; }

	public decimal? pordIDiscountPercent { get; set; }

	public double? OrdItemQuantity { get; set; }

	public double? CurrentQuantity { get; set; }
}
