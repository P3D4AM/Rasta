using System;
using System.ComponentModel.DataAnnotations;
using CRM.Resources;

namespace CRM.Models;

public class CrmCmsGalleryItemsLanguageViewModel
{
	[Key]
	public int GalleryItemId { get; set; }

	public int GalleryId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "CrmCmsGalleryItemTitle")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	[MaxLength(200, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(200, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string ItemTitle { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "CrmCmsGalleryItemTitleFontColor")]
	[MaxLength(20, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(20, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string ItemTitleFontColor { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "CrmCmsGalleryItemDesc")]
	[MaxLength(500, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(500, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string ItemDesc { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "CrmCmsGalleryItemDescFontColor")]
	[MaxLength(20, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(20, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string ItemDescFontColor { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "CrmCmsGalleryItemLink")]
	[MaxLength(1000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(1000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string ItemLink { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "CrmCmsGalleryItemLinkTitle")]
	[MaxLength(500, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(500, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string ItemLinkTitle { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "CrmCmsGalleryItemLinkBgColor")]
	[MaxLength(20, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(20, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string ItemLinkBgColor { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "CrmCmsGalleryItemLinkFontColor")]
	[MaxLength(20, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(20, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string ItemLinkFontColor { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "CrmCmsGalleryItemTargetMode")]
	public int? TargetMode { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "CrmCmsGalleryItemIsActive")]
	public bool? IsActive { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "CrmCmsGalleryItemIsShowTitle")]
	public bool? IsShowTitle { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "CrmCmsGalleryItemIsShowDesc")]
	public bool? IsShowDesc { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "CrmCmsGalleryItemOrderView")]
	public int? OrderView { get; set; }

	public string FileName { get; set; }

	public string FolderName { get; set; }

	public string FilePath { get; set; }

	public int FirstRegisterUserId { get; set; }

	public DateTime FirstRegisterDate { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public int UserId { get; set; }

	public short Year1 { get; set; }

	public short Month1 { get; set; }

	public DateTime RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	public Guid GUId { get; set; }

	public string AppType { get; set; }

	public int LanguageID { get; set; }

	public string ItemTitle_Lang { get; set; }

	public string ItemDesc_Lang { get; set; }

	public string ItemLinkTitle_Lang { get; set; }
}
