namespace CRM.Models;

public class CRMspSelectMenuModelItems_Result
{
	public int MenuModelItemID { get; set; }

	public int MenuModelId { get; set; }

	public string MenuModel { get; set; }

	public int MenuItemId { get; set; }

	public string MenuItem { get; set; }

	public int? MenuTypeId { get; set; }

	public string MenuType { get; set; }

	public int? ParentMenuId { get; set; }

	public int? RootMenuId { get; set; }

	public int? FormId { get; set; }

	public string Form { get; set; }

	public int? FormActionId { get; set; }

	public string FormAction { get; set; }

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

	public int LanguageID { get; set; }

	public int? OrderView { get; set; }
}
