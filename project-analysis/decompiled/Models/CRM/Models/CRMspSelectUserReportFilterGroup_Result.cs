using System;

namespace CRM.Models;

public class CRMspSelectUserReportFilterGroup_Result
{
	public int FilterGroupID { get; set; }

	public string FilterGroupTitle { get; set; }

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

	public string AppType { get; set; }

	public int LanguageID { get; set; }
}
