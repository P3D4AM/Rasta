using System;

namespace CRM.Models;

public class CRMspCmsSelectMenus_Result
{
	public int MenuId { get; set; }

	public string MenuTitle { get; set; }

	public string Type { get; set; }

	public string TypeTitle { get; set; }

	public string ModuleName { get; set; }

	public string ModuleTitle { get; set; }

	public int? ParentId { get; set; }

	public string ParentTitle { get; set; }

	public int? DyFormId { get; set; }

	public string DyFormTitle { get; set; }

	public string DyFormName { get; set; }

	public int? PageId { get; set; }

	public string PageTitle { get; set; }

	public string PageName { get; set; }

	public int? NewsId { get; set; }

	public string NewsTitle { get; set; }

	public string NewsHeadLine { get; set; }

	public int? PrdFirstGroupId { get; set; }

	public string PrdFirstGroup { get; set; }

	public int? PrdSecondGroupId { get; set; }

	public string PrdSecondGroup { get; set; }

	public string Link { get; set; }

	public int TargetMode { get; set; }

	public string TargetModeTitle { get; set; }

	public bool? OnlyForLoginUser { get; set; }

	public bool? IsActive { get; set; }

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
}
