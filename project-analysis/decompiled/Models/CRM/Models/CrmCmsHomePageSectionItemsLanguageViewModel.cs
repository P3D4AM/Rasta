using System;
using System.ComponentModel.DataAnnotations;
using CRM.Resources;

namespace CRM.Models;

public class CrmCmsHomePageSectionItemsLanguageViewModel
{
	[Key]
	public int HomePageSectionItemId { get; set; }

	public int HomePageSectionId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "CmsHomePageSectionItemPrd")]
	public int? SectionItemPrdId { get; set; }

	public string SectionItemPrdName { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "CmsHomePageSectionItemShowExpDate")]
	public string SectionItemShowExpDate { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "CmsHomePageSectionItemShowExpTime")]
	public string SectionItemShowExpTime { get; set; }

	public DateTime? SectionItemShowExpDateTime { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "CmsHomePageSectionItemIsActive")]
	public bool? SectionItemIsActive { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "CmsHomePageSectionItemOrderView")]
	public int? SectionItemOrderView { get; set; }

	public string FirstRegisterUser { get; set; }

	public string EditUser { get; set; }

	public int FirstRegisterUserId { get; set; }

	public DateTime FirstRegisterDate { get; set; }

	public int UserId { get; set; }

	public DateTime RegisterDate { get; set; }

	public string AppType { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "CmsHomePageSectionItemSysPartId")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	public int? SectionItemSysPartId { get; set; }

	public string SectionItemSysPartTitle { get; set; }

	public int? SectionItemObjId { get; set; }

	public string SectionItemObjName { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "CmsHomePageSectionItemLinkType")]
	public int? SectionItemLinkType { get; set; }
}
