namespace CRM.Models;

public class WSIssueOrderItemsCompleteViewModel
{
	public string ordIPrdId { get; set; }

	public string ordIPrice { get; set; }

	public string ordIPrdPriceGroupID { get; set; }

	public string ordIQuantity { get; set; }

	public string ordIDiscount { get; set; }

	public string ordIDiscountPercent { get; set; }

	public string ordIFCR { get; set; }

	public string ordIFCRI { get; set; }

	public string ordITax { get; set; }

	public string ordITaxIndex { get; set; }

	public bool? ordICalculateTax { get; set; }

	public string ordITaxSum { get; set; }

	public string LinkedItemRowNum { get; set; }

	public string LinkedParentItemRowNum { get; set; }

	public string LinkedParentPrdRowNum { get; set; }

	public string PrdUnitId { get; set; }

	public string PrdUnitIdI { get; set; }

	public int? ordIWHId { get; set; }
}
