namespace CRM.Models;

public class WSspSelectBuyOrderItemsWithOrdItemQuantity_Result
{
	public int BuyOrderItemId { get; set; }

	public int BuyOrderId { get; set; }

	public int bordIPrdId { get; set; }

	public double? bordIQuantity { get; set; }

	public decimal? bordICost { get; set; }

	public decimal? bordITotalCost { get; set; }

	public string bordIDescription { get; set; }

	public string bordIQuantityDesc { get; set; }

	public decimal? bordIDiscount { get; set; }

	public decimal? bordIDiscountI { get; set; }

	public decimal? bordIDiscountPercent { get; set; }

	public decimal? bordIDiscountIPercent { get; set; }

	public int? bordIPrdUnitId { get; set; }

	public int? bordICurrencyUnitId { get; set; }

	public int? bordIOrderView { get; set; }

	public double? bordIFCR { get; set; }

	public decimal? bordITax { get; set; }

	public decimal? bordITaxIndex { get; set; }

	public bool? bordICalculateTax { get; set; }

	public bool? bordINotVisible { get; set; }

	public double? bordIFCRI { get; set; }

	public bool? bordINotInSum { get; set; }

	public int? bordIWHId { get; set; }

	public string bordIWrhsName { get; set; }

	public int? bordIPrdCostGroupID { get; set; }

	public string bordITracing { get; set; }

	public decimal? bordICostSum { get; set; }

	public decimal? bordIDiscountSum { get; set; }

	public decimal? bordIDiscountISum { get; set; }

	public decimal? bordITaxSum { get; set; }

	public double? bordIQuantityTotal { get; set; }

	public int? bordIPrdUnitIdI { get; set; }

	public double? bordIPrdUnitIRateResult { get; set; }

	public int? bordIPrdColorId { get; set; }

	public string bordIPrdNickname { get; set; }

	public string PrdName { get; set; }

	public string PrdCode { get; set; }

	public string PrdFGName { get; set; }

	public string PrdSGName { get; set; }

	public string PrdUnitName { get; set; }

	public string PrdCurrencyUnitPrice { get; set; }

	public string bordIPrdUnit { get; set; }

	public string bordIPrdUnitI { get; set; }

	public string bordICurrencyUnit { get; set; }

	public decimal? bordIPriceInQuan { get; set; }

	public double? OrdItemQuantity { get; set; }

	public double CurrentQuantity { get; set; }

	public bool? PrdCanChangePrice { get; set; }

	public string ListPrdPriceGroup { get; set; }

	public string bordILinkAccWHIdStr { get; set; }

	public int? bordILinkAccSettingDBId { get; set; }
}
