using System.ComponentModel.DataAnnotations;
using CRM.Resources;

namespace CRM.Models;

public class CrmFoRegisterSettingLanguageViewModel
{
	[Key]
	public int FoSettingId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "FoSettingRegTitle")]
	[MaxLength(100, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(100, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string RegTitle { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "FoSettingRegFormTitle")]
	[MaxLength(100, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(100, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string RegFormTitle { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "FoSettingRegBgImagePath")]
	[MaxLength(1000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(1000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string RegBgImagePath { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "FoSettingRegBgColor")]
	[MaxLength(20, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(20, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string RegBgColor { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "FoSettingRegBtnBgColor")]
	[MaxLength(20, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(20, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string RegBtnBgColor { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "FoSettingRegBtnFontColor")]
	[MaxLength(20, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(20, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string RegBtnFontColor { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "FoSettingRegLinkColor")]
	[MaxLength(20, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(20, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string RegLinkColor { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "FoSettingRegLoginLinkTitle")]
	[MaxLength(100, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(100, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string RegLoginLinkTitle { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "FoSettingRegPosition")]
	public int? RegPosition { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "FoSettingRegTextBorderColor")]
	[MaxLength(20, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(20, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string RegTextBorderFColor { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "FoSettingRegTextBorderColor")]
	[MaxLength(20, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(20, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string RegTextBorderTColor { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "FoSettingRegDyFormId")]
	public int? RegDyFormId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "FoSettingRegNullableFields")]
	public string RegNullableFields { get; set; }

	public string RegNullableFieldsByTitle { get; set; }

	public string RegTitle_Lang { get; set; }

	public string RegFormTitle_Lang { get; set; }

	public string RegLoginLinkTitle_Lang { get; set; }
}
