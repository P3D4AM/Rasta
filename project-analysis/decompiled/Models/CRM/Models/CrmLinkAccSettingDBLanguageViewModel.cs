using System.ComponentModel.DataAnnotations;
using CRM.Resources;

namespace CRM.Models;

public class CrmLinkAccSettingDBLanguageViewModel
{
	[Key]
	public int LinkAccSettingDBId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "LinkAccSettingDbTitle")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	[MaxLength(200, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(200, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string LinkAccSettingDbTitle { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "LinkAccSettingDbName")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	[MaxLength(200, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(200, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string LinkAccSettingDbName { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "LinkAccSettingDbIsActive")]
	public bool? IsActive { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "LinkAccSettingDbOrderView")]
	public int? OrderView { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "LinkAccSettingDbServerName")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	[MaxLength(200, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(200, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	[RegularExpression("^[A-Za-z0-9_\\-\\s]+$", ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "MsgErrorServerNameAllowedChars")]
	public string LinkAccSettingServerName { get; set; }
}
