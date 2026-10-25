namespace CRM.Models;

public class ArianSystemProductRemainingResponseViewModel
{
	public decimal? FirstPeriod { get; set; }

	public decimal? Import { get; set; }

	public decimal? Export { get; set; }

	public decimal? Remain { get; set; }

	public bool? HasDetectionInv { get; set; }

	public string GroupCode1 { get; set; }
}
