using System;
using System.ComponentModel.DataAnnotations;
using CRM.Resources;

namespace CRM.Models;

public class CrmCmsGalleryLanguageViewModel
{
	[Key]
	public int GalleryId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "CrmCmsGalleryTitle")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	[MaxLength(200, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(200, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string GalleryTitle { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "CrmCmsGalleryInterval")]
	public int? GalleryInterval { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "CrmCmsGalleryEffect")]
	public int? GalleryEffect { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "CrmCmsGalleryIsActive")]
	public bool? IsActive { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "CrmCmsGalleryIsShowTitle")]
	public bool? IsShowTitle { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "CrmCmsGalleryOrderView")]
	public int? OrderView { get; set; }

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

	[Display(ResourceType = typeof(Labels), Name = "CrmCmsGallerySystemPartIds")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	public string GallerySystemPartIds { get; set; }

	public string GalleryTitle_Lang { get; set; }
}
