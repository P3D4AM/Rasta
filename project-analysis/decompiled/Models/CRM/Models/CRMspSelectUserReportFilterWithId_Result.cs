using System;

namespace CRM.Models;

public class CRMspSelectUserReportFilterWithId_Result
{
	public int UserReportFilterID { get; set; }

	public int? rptFilterGroupId { get; set; }

	public string rptFilterGroup { get; set; }

	public string rptTitle { get; set; }

	public string rptFilterTermsTxt { get; set; }

	public bool? rptIsPublic { get; set; }

	public string rptIsPublicForUsersId { get; set; }

	public string rptIsPublicForUsers { get; set; }

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

	public string rptResultColumnsJson { get; set; }
}
