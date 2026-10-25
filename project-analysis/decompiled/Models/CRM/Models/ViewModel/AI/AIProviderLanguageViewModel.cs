using System.ComponentModel.DataAnnotations;
using CRM.Resources;

namespace CRM.Models.ViewModel.AI;

public class AIProviderLanguageViewModel : PublicParameters
{
	public int ProviderId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "Name")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	[MaxLength(300, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(300, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string ProviderName { get; set; }

	public string ApiKey { get; set; }

	public string ApiBaseUrl { get; set; }

	public string ProviderName_Lang { get; set; }
}
