using System.ComponentModel.DataAnnotations;
using CRM.Resources;

namespace CRM.Models.ViewModel.AI;

public class AIPromptGroupLanguageViewModel : PublicParameters
{
	public int PromptGroupId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "Title")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	[MaxLength(500, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(500, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string Title { get; set; }

	public string Title_Lang { get; set; }
}
