namespace CRM.Models.ViewModel.Targeting;

public class SalesTargetDistributionItemViewModel
{
	public string Val { get; set; }

	public int? OrderCount { get; set; }

	public decimal? OrderAmount { get; set; }

	public string Text { get; set; }

	public bool? TargetNotif { get; set; }
}
