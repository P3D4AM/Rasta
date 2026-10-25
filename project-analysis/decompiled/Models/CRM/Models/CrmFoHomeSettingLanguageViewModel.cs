using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using CRM.Resources;

namespace CRM.Models;

public class CrmFoHomeSettingLanguageViewModel
{
	[Key]
	public int FoSettingId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "FoSettingShpHomeGalleryIdI")]
	public int? ShpHomeGalleryIdI { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "FoSettingShpHomeGalleryIdII")]
	public int? ShpHomeGalleryIdII { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "FoSettingShpHomeGalleryIdIII")]
	public int? ShpHomeGalleryIdIII { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "FoSettingShpHomePrdPartTitle")]
	[MaxLength(100, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(100, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string ShpHomePrdPartTitle { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "FoSettingShpHomeTopHeaderBgColor")]
	[MaxLength(20, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(20, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string ShpHomeTopHeaderBgColor { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "FoSettingShpHomeTopHeaderFontColor")]
	[MaxLength(20, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(20, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string ShpHomeTopHeaderFontColor { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "FoSettingShpFooter")]
	public int? ShpFooterId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "FoSettingShpHomeTopHeaderContent")]
	[UIHint("RichText")]
	[AllowHtml]
	public string ShpHomeTopHeaderContent { get; set; }

	public string ShpHomePrdPartTitle_Lang { get; set; }

	[UIHint("RichText")]
	[AllowHtml]
	public string ShpHomeTopHeaderContent_Lang { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "FoSettingHomeGalleryIdI")]
	public int? FoHomeGalleryIdI { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "FoSettingHomeGalleryIdII")]
	public int? FoHomeGalleryIdII { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "FoSettingHomeGalleryIdIII")]
	public int? FoHomeGalleryIdIII { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "FoSettingMobFoHomeGalleryId")]
	public int? MobFoHomeGalleryId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "FoSettingFoFileAttachCount")]
	public int? FoFileAttachCount { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "FoSettingFoShowControlPrdValidity")]
	public bool? FoShowControlPrdValidity { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "FoSettingFoShowPordByTspMethod")]
	public bool? FoShowPordByTspMethod { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "FoSettingFoShowOrdByTspMethod")]
	public bool? FoShowOrdByTspMethod { get; set; }
}
