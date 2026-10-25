using System;

namespace CRM.Models;

public class CRMspSelectOrderIssueQuickGroups_Result
{
	public int IssueQuickGroupID { get; set; }

	public string GroupTitle { get; set; }

	public string GroupTitleJs { get; set; }

	public bool? IsDefault { get; set; }

	public int? BoxRowsCount { get; set; }

	public int? BoxColsCount { get; set; }

	public string ColorCode { get; set; }

	public string TextColorCode { get; set; }

	public string Description { get; set; }

	public string DescriptionJs { get; set; }

	public int? BoxHeight { get; set; }

	public int? BoxWidth { get; set; }

	public string BoxColor { get; set; }

	public string BoxTextColor { get; set; }

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

	public string GroupItemsJs { get; set; }
}
