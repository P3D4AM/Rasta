namespace CRM.Models.ViewModel.AI;

public class AIConvertVoiceToTextDataViewModel
{
	public AIModelViewModel Model { get; set; }

	public AIProviderViewModel Provider { get; set; }

	public AISettingViewModel Setting { get; set; }

	public AIResponseTypeViewModel ResponseType { get; set; }

	public ConvertVoiceToTextResponseViewModel Response { get; set; }
}
