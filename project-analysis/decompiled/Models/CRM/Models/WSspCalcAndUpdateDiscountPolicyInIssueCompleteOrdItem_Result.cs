namespace CRM.Models;

public class WSspCalcAndUpdateDiscountPolicyInIssueCompleteOrdItem_Result
{
	public int? OrdItemId { get; set; }

	public int? ordIPrdId { get; set; }

	public double? ordIQuantity { get; set; }

	public decimal? ordIPrice { get; set; }

	public decimal? ordIDiscount { get; set; }

	public decimal? ordIDiscountPercent { get; set; }

	public int? ordIPrdPriceGroupID { get; set; }

	public double? ordIFCR { get; set; }

	public double? ordIFCRI { get; set; }

	public bool? ordICalculateTax { get; set; }

	public decimal? ordITax { get; set; }

	public decimal? ordITaxIndex { get; set; }

	public decimal? ordITaxSum { get; set; }

	public int? LinkedItemRowNum { get; set; }

	public int? LinkedParentItemRowNum { get; set; }

	public int? LinkedParentPrdRowNum { get; set; }

	public int? PrdUnitId { get; set; }

	public int? PrdUnitIdI { get; set; }

	public decimal? ordIPriceSum { get; set; }

	public decimal? ordIDiscountSum { get; set; }

	public decimal? ordITotalPrice { get; set; }

	public int? DiscountPolicyId { get; set; }

	public string DPTitle { get; set; }

	public int? PrdUnitIdII { get; set; }
}
