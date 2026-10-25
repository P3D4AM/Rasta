namespace CRM.Models;

public class RayvarzProductPriceResponseViewModel
{
	public bool? isValidationsApplied { get; set; }

	public long? unitPriceTemplateId { get; set; }

	public int? isActive { get; set; }

	public long? itemGroupId { get; set; }

	public string itemGroup { get; set; }

	public string fromDate { get; set; }

	public string toDate { get; set; }

	public string itemDataId { get; set; }

	public decimal? totalUnitPrice { get; set; }

	public decimal? partialUnitPrice { get; set; }
}
