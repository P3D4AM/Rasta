using System.ComponentModel.DataAnnotations;
using CRM.Resources;

namespace CRM.Models;

public class CrmTelegSettingViewModel
{
	[Key]
	public int TelegSettingId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "TelegSettingPhoneNumber")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	[MaxLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string PhoneNumber { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "TelegSettingTelegramId")]
	public int? TelegramId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "TelegSettingAppApiId")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	public int AppApiId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "TelegSettingAppApiHash")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	[MaxLength(300, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(300, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string AppApiHash { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "TelegSettingAppTitle")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	[MaxLength(300, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(300, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string AppTitle { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "TelegSettingIsActive")]
	public bool IsActive { get; set; }

	public string AppType { get; set; }
}
