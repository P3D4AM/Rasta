using System.ComponentModel.DataAnnotations;
using CRM.Resources;

namespace CRM.Models;

public class CrmLinkAccSettingUsersLanguageViewModel
{
	[Key]
	public int LinkAccSettingUserId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "LinkAccSettingReferUserName")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	public int CrmUserId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "LinkAccSettingReferUserUName")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	[MaxLength(100, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(100, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string UserName { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "LinkAccSettingReferUserPassword")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	[MaxLength(100, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(100, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string Password { get; set; }

	public int LinkAccSettingDBId { get; set; }
}
