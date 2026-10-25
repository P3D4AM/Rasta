using System;

namespace Mobile.Models;

public class MobspTmpUserItemPast_Result
{
	public int? PrdId { get; set; }

	public double? PrdQuantity { get; set; }

	public decimal? Price { get; set; }

	public decimal? TotalPrice { get; set; }

	public string Description { get; set; }

	public string QuantityDesc { get; set; }

	public decimal? Discount { get; set; }

	public decimal? DiscountI { get; set; }

	public decimal? DiscountPercent { get; set; }

	public decimal? DiscountIPercent { get; set; }

	public int? PrdUnitId { get; set; }

	public int? CurrencyUnitId { get; set; }

	public int? OrderView { get; set; }

	public double? FCR { get; set; }

	public decimal? Tax { get; set; }

	public decimal? TaxIndex { get; set; }

	public bool? CalculateTax { get; set; }

	public bool? NotVisible { get; set; }

	public int? WHId { get; set; }

	public int? ObjItemId { get; set; }

	public int? PrdPriceGroupID { get; set; }

	public decimal? PriceSum { get; set; }

	public decimal? DiscountSum { get; set; }

	public decimal? DiscountISum { get; set; }

	public decimal? TaxSum { get; set; }

	public double? FCRI { get; set; }

	public string Tracing { get; set; }

	public int? DeliveryTermId { get; set; }

	public DateTime? DeliveryDate { get; set; }

	public string DeliveryDatePersian { get; set; }

	public DateTime? ValidityExpireDate { get; set; }

	public string ValidityExpireDatePersian { get; set; }

	public int? PrdColorId { get; set; }

	public int? PrdUnitIdI { get; set; }

	public double? PrdUnitIRateResult { get; set; }

	public string PrdNickname { get; set; }

	public string DeliveryTime { get; set; }

	public string DeliveryDay { get; set; }

	public DateTime? DeliveryEndDate { get; set; }

	public string DeliveryEndDatePersian { get; set; }

	public string DeliveryEndTime { get; set; }

	public string DeliveryEndDay { get; set; }

	public decimal? PrdAutoCalcRate { get; set; }

	public string DescriptionI { get; set; }

	public int? SaleCenterId { get; set; }

	public int? LinkedParentItemId { get; set; }

	public int? LinkedParentPrdId { get; set; }

	public double? PriceCurrencyRate { get; set; }

	public double? PrdWeight { get; set; }

	public int? LinkAccSettingDBId { get; set; }
}
