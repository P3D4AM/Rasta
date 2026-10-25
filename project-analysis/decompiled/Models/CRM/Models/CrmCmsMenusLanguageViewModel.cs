using System;
using System.ComponentModel.DataAnnotations;
using CRM.Resources;

namespace CRM.Models;

public class CrmCmsMenusLanguageViewModel
{
	[Key]
	public int MenuId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "CmsMenuTitle")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	[MaxLength(100, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(100, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string MenuTitle { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "CmsMenuType")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	[MaxLength(20, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(20, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string Type { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "CmsMenuModuleName")]
	[MaxLength(20, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(20, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string ModuleName { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "CmsMenuParent")]
	public int? ParentId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "CmsMenuDyForm")]
	public int? DyFormId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "CmsMenuPage")]
	public int? PageId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "CmsMenuNews")]
	public int? NewsId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "CmsMenuPrdFirstGroup")]
	public int? PrdFirstGroupId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "CmsMenuPrdSecondGroup")]
	public int? PrdSecondGroupId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "CmsMenuLink")]
	[MaxLength(1000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(1000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string Link { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "CmsMenuTargetMode")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	public int TargetMode { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "CmsMenuOnlyForLoginUser")]
	public bool? OnlyForLoginUser { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "CmsMenuIsActive")]
	public bool? IsActive { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "CmsMenuOrderView")]
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

	public string EditUser { get; set; }

	public string FirstRegisterUser { get; set; }

	public string MenuTitle_Lang { get; set; }
}
