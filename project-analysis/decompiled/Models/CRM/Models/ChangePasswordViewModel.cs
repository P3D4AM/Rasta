using System.ComponentModel.DataAnnotations;
using CRM.Resources;

namespace CRM.Models;

public class ChangePasswordViewModel
{
	[Key]
	public int UserId { get; set; }

	public string FName { get; set; }

	public string LName { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "FLName")]
	public string FLName => FName + " " + LName;

	[Display(ResourceType = typeof(Labels), Name = "CurrentPassword")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	[MaxLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	[DataType(DataType.Password)]
	public string Password { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "NewPassword")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	[MaxLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(50, MinimumLength = 4, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	[MinLength(4, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitMinExceededNumber")]
	[RegularExpression("^.{4,}$", ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitMinExceeded4Number")]
	[DataType(DataType.Password)]
	public string NewPassword { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "RepeatNewPassword")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	[MaxLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(50, MinimumLength = 4, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	[MinLength(4, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitMinExceededNumber")]
	[RegularExpression("^.{4,}$", ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitMinExceeded4Number")]
	[DataType(DataType.Password)]
	[Compare("NewPassword", ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "NotMatchRepeatPassword")]
	public string RepeatNewPassword { get; set; }
}
