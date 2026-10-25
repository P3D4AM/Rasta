using System.ComponentModel.DataAnnotations;
using CRM.Resources;

namespace Mobile.Models;

public class MobLoginViewModel
{
	[Display(ResourceType = typeof(Labels), Name = "MobLoginUsername")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	[MaxLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string UserName { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "MobLoginPassword")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	[MaxLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string Password { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "MobLoginCaptchaCode")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	public string CaptchaCode { get; set; }

	public string MainCaptchaCode { get; set; }
}
