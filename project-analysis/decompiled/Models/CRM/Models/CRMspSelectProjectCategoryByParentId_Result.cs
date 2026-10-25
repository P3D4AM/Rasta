using System;

namespace CRM.Models;

public class CRMspSelectProjectCategoryByParentId_Result
{
	public int ProjectCategoryId { get; set; }

	public int ParentId { get; set; }

	public string ParentName { get; set; }

	public string ParentHistory { get; set; }

	public string CategoryName { get; set; }

	public string CategoryFullName { get; set; }

	public int? Depth { get; set; }

	public bool? IsLeaf { get; set; }

	public int? CnvsStatusGroupId { get; set; }

	public string CnvsStatusGroup { get; set; }

	public int? OrderView { get; set; }

	public int FirstRegisterUserId { get; set; }

	public DateTime FirstRegisterDate { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public int UserId { get; set; }

	public int Year1 { get; set; }

	public short Month1 { get; set; }

	public DateTime RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	public Guid GUId { get; set; }

	public string AppType { get; set; }

	public int LanguageID { get; set; }

	public string FirstRegisterUser { get; set; }

	public string EditUser { get; set; }
}
