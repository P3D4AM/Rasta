using System.ComponentModel.DataAnnotations;
using CRM.Resources;

namespace CRM.Models.ViewModel.AI;

public class AIPromptLanguageViewModel : PublicParameters
{
	public int PromptId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "Title")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	[MaxLength(500, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(500, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string PrTitle { get; set; }

	public string PrDesc { get; set; }

	public string PrSystemRole { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "Prompt")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	public string PrData { get; set; }

	public bool? PrIsDisabled { get; set; }

	public int PromptGroupId { get; set; }

	public string PromptGroup { get; set; }

	public int? OrderView { get; set; }

	public string PrTitle_Lang { get; set; }

	public string PrDesc_Lang { get; set; }

	public string PrSystemRole_Lang { get; set; }

	public string PrData_Lang { get; set; }
}
