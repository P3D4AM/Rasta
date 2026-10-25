namespace CRM.Models.ViewModel.AI;

public class AISettingViewModel
{
	public int SettingId { get; set; }

	public string DefSystemPrompt { get; set; }

	public int DefModelId { get; set; }

	public string DefModelName { get; set; }

	public int DefProviderId { get; set; }

	public string DefProviderName { get; set; }

	public decimal DefTemperature { get; set; }

	public int? DefMaxTokens { get; set; }

	public int? ProviderTimeOut { get; set; }

	public int? MinRequestTokenBalance { get; set; }
}
