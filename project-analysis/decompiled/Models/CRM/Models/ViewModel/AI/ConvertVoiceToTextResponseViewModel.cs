namespace CRM.Models.ViewModel.AI;

public class ConvertVoiceToTextResponseViewModel
{
	public string Text { get; set; }

	public int InputTokens { get; set; }

	public int OutputTokens { get; set; }

	public int TotalTokens { get; set; }
}
