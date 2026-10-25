using System;
using System.ComponentModel.DataAnnotations;
using CRM.Resources;

namespace CRM.Models;

public class CrmTelegBotSettingViewModel
{
	[Key]
	public int TelegBotSettingId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "TelegBotSettingToken")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	[MaxLength(1000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(1000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string Token { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "TelegBotSettingCaption")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	[MaxLength(500, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(500, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string Caption { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "TelegBotSettingUserName")]
	[MaxLength(500, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(500, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string UserName { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "TelegBotSettingDescription")]
	[MaxLength(1000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(1000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string Description { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "TelegBotSettingAbout")]
	[MaxLength(1000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(1000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string About { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "TelegBotSettingWelcomeMessage")]
	[MaxLength(4000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(4000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string WelcomeMessage { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "TelegBotSettingIsActive")]
	public bool IsActive { get; set; }

	public string AppType { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "TelegBotSettingLanguageCollation")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	public string LanguageCollation { get; set; }

	public int? FirstRegisterUserId { get; set; }

	public DateTime? FirstRegisterDate { get; set; }

	public int? UserId { get; set; }

	public DateTime? RegisterDate { get; set; }

	public string HelpAppType { get; set; }
}
