using System.ComponentModel.DataAnnotations;
using CRM.Resources;

namespace CRM.Models;

public class PayRollListLanguageIViewModel
{
	[Key]
	public int PayRollListId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "PayRollListGroup")]
	public int? PayRollListGroupId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "PayRollListTitle")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	[MaxLength(300, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(300, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string ListTitle { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "PayRollListYear")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	public int ListYear { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "PayRollListMonth")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	public int ListMonth { get; set; }

	public string ListTitle_Lang { get; set; }
}
