namespace CRM.Models;

public class LkWSOrderItemsInfoViewModel
{
	public string ordLinkAccOrderIdStr { get; set; }

	public string ordLinkAccOrderNumber { get; set; }

	public double? ordIQuantity { get; set; }

	public decimal? ordIPrice { get; set; }

	public decimal? ordITotalPrice { get; set; }

	public string ordIDescription { get; set; }

	public string ordIQuantityDesc { get; set; }

	public decimal? ordIDiscount { get; set; }

	public decimal? ordIDiscountPercent { get; set; }

	public double? ordIFCR { get; set; }

	public decimal? ordITax { get; set; }

	public decimal? ordITaxIndex { get; set; }

	public bool? ordICalculateTax { get; set; }

	public double? ordIFCRI { get; set; }

	public decimal? ordIRound { get; set; }

	public decimal? ordIRoundPlus { get; set; }

	public decimal? ordIRoundSum { get; set; }

	public decimal? ordIRoundPlusSum { get; set; }

	public string ordIDescriptionI { get; set; }

	public decimal? ordIDiscountSum { get; set; }

	public decimal? ordITaxSum { get; set; }

	public string ordILinkAccItemIdStr { get; set; }

	public string ordILinkAccData { get; set; }

	public double? ordIPrdUnitIRateResult { get; set; }

	public double? ordIPrdWeight { get; set; }

	public int ordIPrdId { get; set; }

	public string PrdName { get; set; }

	public string PrdLinkAccPrdCode { get; set; }

	public string PrdLinkAccPrdIdStr { get; set; }

	public string Unit { get; set; }

	public string UnitLinkAccUnitIdStr { get; set; }

	public string UnitI { get; set; }

	public string UnitLinkAccUnitIdStrI { get; set; }

	public int? ordIWHId { get; set; }

	public string WrhsName { get; set; }

	public string WrhsLinkAccWhCode { get; set; }

	public string WrhsLinkAccWhIdStr { get; set; }
}
