using System.ComponentModel.DataAnnotations;
using CRM.Resources;

namespace CRM.Models;

public class CrmMobHRMSettingLanguageViewModel
{
	public int SysSettingId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "lblCoLogoMobHRMAppPath")]
	[MaxLength(1000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(1000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string CoLogoMobHRMAppPath { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "lblCoNameMobHRMApp")]
	[MaxLength(200, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(200, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string CoNameMobHRMApp { get; set; }

	public string CoNameMobHRMApp_Lang { get; set; }
}
