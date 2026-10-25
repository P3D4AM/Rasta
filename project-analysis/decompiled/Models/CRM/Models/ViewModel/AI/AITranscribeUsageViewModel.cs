namespace CRM.Models.ViewModel.AI;

public class AITranscribeUsageViewModel
{
	public string type { get; set; }

	public int input_tokens { get; set; }

	public int output_tokens { get; set; }

	public int total_tokens { get; set; }

	public AITranscribeInputTokenDetailsViewModel input_token_details { get; set; }
}
