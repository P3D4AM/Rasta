using System;

namespace CRM.Models;

public class CRMspSelectProjectTitleGroups_Result
{
	public int ProjectTitleGroupId { get; set; }

	public string ProjectTitleGroup { get; set; }

	public string ProjectTitleGroupDesc { get; set; }

	public int? ProjectTitleGroupUserDepartmentId { get; set; }

	public string ProjectTitleGroupUserDepartment { get; set; }

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

	public string FirstRegisterUser { get; set; }

	public string EditUser { get; set; }

	public bool? ProjectTitleGroupAgreementActive { get; set; }

	public string ProjectTitleGroupAgreementDesc { get; set; }

	public string ProjectTitleGroupSubjectDefaultContext { get; set; }

	public bool? ProjectTitleGroupTicketCountCurrentWithStop { get; set; }

	public int? ProjectTitleGroupTicketAllowInCurrentCount { get; set; }

	public string ProjectTitleGroupColor { get; set; }
}
