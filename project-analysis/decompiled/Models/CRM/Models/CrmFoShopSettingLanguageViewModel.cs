using System.ComponentModel.DataAnnotations;
using CRM.Resources;

namespace CRM.Models;

public class CrmFoShopSettingLanguageViewModel
{
	[Key]
	public int FoSettingId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "FoSettingPrdPriceVisible")]
	public bool? PrdPriceVisible { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "FoSettingPrdDisplayType")]
	public int? PrdDisplayType { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "FoSettingSHPDefaultPriceGroup")]
	public int? SHPDefaultPriceGroupId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "FoSettingShpSidebarMenuVisible")]
	public bool? ShpSidebarMenuVisible { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "FoSettingPrdFCRVisible")]
	public bool? PrdFCRVisible { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "FoSettingPrdPriceWithFCRVisible")]
	public bool? PrdPriceWithFCRVisible { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "FoSettingPrdPriceInDecimalVisible")]
	public bool? PrdPriceInDecimalVisible { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "FoSettingShpStartWithShop")]
	public bool? ShpStartWithShop { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "FoSettingShpSeoIsActive")]
	public bool? ShpSeoIsActive { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "FoSettingFoShowShopBtn")]
	public bool? FoShowShopBtn { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "FoSettingUniqueSaleCenterParentInOrd")]
	public bool? ShpUniqueSaleCenterParentInOrd { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "FoSettingShpLinkedPrdLbl")]
	[MaxLength(200, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(200, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string ShpLinkedPrdLbl { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "FoSettingShpDefLinkAccSettingDB")]
	public int? ShpDefLinkAccSettingDBId { get; set; }

	public string ShpLinkedPrdLbl_Lang { get; set; }
}
