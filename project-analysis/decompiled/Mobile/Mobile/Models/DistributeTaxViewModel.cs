namespace Mobile.Models;

public class DistributeTaxViewModel
{
	public int MasterId { get; set; }

	public string ItemIds { get; set; }

	public decimal? Tax { get; set; }

	public decimal? TaxIndex { get; set; }

	public int? LanguageId { get; set; }

	public bool AddToTax { get; set; }
}
