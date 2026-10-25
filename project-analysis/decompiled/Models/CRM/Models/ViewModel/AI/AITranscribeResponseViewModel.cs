namespace CRM.Models.ViewModel.AI;

public class AITranscribeResponseViewModel
{
	public string text { get; set; } = string.Empty;


	public AITranscribeUsageViewModel usage { get; set; }

	public AITranscribeEstimatedCostViewModel estimated_cost { get; set; }

	public string service_tier { get; set; }
}
