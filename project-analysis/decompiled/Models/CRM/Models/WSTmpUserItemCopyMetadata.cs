using System;

namespace CRM.Models;

public class WSTmpUserItemCopyMetadata
{
	public int ItemId { get; set; }

	public int? PrdId { get; set; }

	public double? PrdQuantity { get; set; }

	public string QuantityDesc { get; set; }

	public decimal? Price { get; set; }

	public decimal? Discount { get; set; }

	public decimal? DiscountI { get; set; }

	public decimal? DiscountPercent { get; set; }

	public decimal? DiscountIPercent { get; set; }

	public decimal? TotalPrice { get; set; }

	public string Description { get; set; }

	public int? PrdUnitId { get; set; }

	public int? CurrencyUnitId { get; set; }

	public int? OrderView { get; set; }

	public double? FCR { get; set; }

	public string tmp1 { get; set; }

	public string tmp2 { get; set; }

	public int UserId { get; set; }

	public string CopyType { get; set; }

	public decimal? Tax { get; set; }

	public decimal? TaxIndex { get; set; }

	public bool? CalculateTax { get; set; }

	public bool? NotVisible { get; set; }

	public Guid? GUId { get; set; }

	public double? FCRI { get; set; }

	public bool? NotInSum { get; set; }

	public int? WHId { get; set; }

	public string AppType { get; set; }
}
