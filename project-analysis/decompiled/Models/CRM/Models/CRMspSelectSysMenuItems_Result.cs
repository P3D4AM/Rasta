using System;

namespace CRM.Models;

public class CRMspSelectSysMenuItems_Result
{
	public int MenuItemID { get; set; }

	public string MenuType { get; set; }

	public int? ParentMenuId { get; set; }

	public int? RootMenuId { get; set; }

	public int? FormId { get; set; }

	public int? FormActionId { get; set; }

	public string ModuleNames { get; set; }

	public string MenuItemName { get; set; }

	public string MenuItemTitle { get; set; }

	public string ResourceName { get; set; }

	public string MenuItemClassName { get; set; }

	public string MenuItemStyleCode { get; set; }

	public string MenuItemSelectedStyleCode { get; set; }

	public string Link { get; set; }

	public string LinkTarget { get; set; }

	public string OnClick { get; set; }

	public string MenuIconClassName { get; set; }

	public string MenuIconStyleCode { get; set; }

	public bool? MenuHaveDividerInBottom { get; set; }

	public bool? InActive { get; set; }

	public bool? InVisible { get; set; }

	public bool? IsDisabled { get; set; }

	public int FirstRegisterUserId { get; set; }

	public string FirstRegisterUser { get; set; }

	public DateTime FirstRegisterDate { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public string AppType { get; set; }

	public int LanguageID { get; set; }

	public int? OrderView { get; set; }
}
