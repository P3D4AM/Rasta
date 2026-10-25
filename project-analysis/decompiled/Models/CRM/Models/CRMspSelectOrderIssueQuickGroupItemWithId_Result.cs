using System;

namespace CRM.Models;

public class CRMspSelectOrderIssueQuickGroupItemWithId_Result
{
	public int IssueQuickGroupItemID { get; set; }

	public int IssueQuickGroupId { get; set; }

	public int? PrdId { get; set; }

	public string Prd { get; set; }

	public string PrdJs { get; set; }

	public string BoxTitle { get; set; }

	public string BoxTitleJs { get; set; }

	public int? BoxHeight { get; set; }

	public int? BoxWidth { get; set; }

	public int? BoxRow { get; set; }

	public int? BoxCol { get; set; }

	public string BoxColor { get; set; }

	public string BoxTextColor { get; set; }

	public bool? InActive { get; set; }

	public int? OrderView { get; set; }

	public int FirstRegisterUserId { get; set; }

	public string FirstRegisterUser { get; set; }

	public DateTime FirstRegisterDate { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public int UserId { get; set; }

	public string EditUser { get; set; }

	public short Year1 { get; set; }

	public short Month1 { get; set; }

	public DateTime RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	public Guid GUId { get; set; }

	public string AppType { get; set; }

	public int LanguageID { get; set; }
}
