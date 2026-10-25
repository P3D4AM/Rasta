using System.ComponentModel.DataAnnotations;
using CRM.Resources;

namespace CRM.Models;

public class CrmFoShpLogoSettingLanguageViewModel
{
	[Key]
	public int FoSettingId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "FoSettingShpLogoPathWidth110")]
	[MaxLength(1000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(1000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string ShpLogoPathWidth110 { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "FoSettingShpLogoPathWidth215")]
	[MaxLength(1000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(1000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string ShpLogoPathWidth215 { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "FoSettingShpPrdDefPhotoAdd")]
	[MaxLength(1000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(1000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string ShpPrdDefPhotoAdd { get; set; }
}
