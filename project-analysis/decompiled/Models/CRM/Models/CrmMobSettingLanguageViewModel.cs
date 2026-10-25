using System.ComponentModel.DataAnnotations;
using CRM.Resources;

namespace CRM.Models;

public class CrmMobSettingLanguageViewModel
{
	[Key]
	public int ID { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "MobAccessCmpDistance")]
	public double? MobAccessCmpDistance { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "lblCoLogoMobAppPath")]
	[MaxLength(1000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(1000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string CoLogoMobAppPath { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "lblCoNameMobApp")]
	[MaxLength(200, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(200, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string CoNameMobApp { get; set; }

	public string CoNameMobApp_Lang { get; set; }

	public int? MobCmpQuickRegDupReaction { get; set; }
}
