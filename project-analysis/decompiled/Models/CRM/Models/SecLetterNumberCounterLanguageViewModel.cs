using System.ComponentModel.DataAnnotations;
using CRM.Resources;

namespace CRM.Models;

public class SecLetterNumberCounterLanguageViewModel
{
	[Key]
	public int LetterNumberCounterId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "LtrNumCntLetterTypeId")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	public int LetterTypeId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "LtrNumCntTitle")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	[MaxLength(200, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(200, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string LtrNumCntTitle { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "LtrNumCntBeginner")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	public long LtrNumCntBeginner { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "LtrNumCntPreNumber")]
	[MaxLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string LtrNumCntPreNumber { get; set; }

	public string LtrNumCntTitle_Lang { get; set; }
}
