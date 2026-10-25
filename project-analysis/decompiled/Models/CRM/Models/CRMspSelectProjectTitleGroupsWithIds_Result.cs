namespace CRM.Models;

public class CRMspSelectProjectTitleGroupsWithIds_Result
{
	public int ProjectTitleGroupId { get; set; }

	public string ProjectTitleGroup { get; set; }

	public string ProjectTitleGroupDesc { get; set; }

	public int? ProjectTitleGroupUserDepartmentId { get; set; }

	public string ProjectTitleGroupUserDepartment { get; set; }

	public bool? ProjectTitleGroupAgreementActive { get; set; }

	public string ProjectTitleGroupAgreementDesc { get; set; }

	public string ProjectTitleGroupSubjectDefaultContext { get; set; }

	public bool? ProjectTitleGroupTicketCountCurrentWithStop { get; set; }

	public int? ProjectTitleGroupTicketAllowInCurrentCount { get; set; }

	public string ProjectTitleGroupColor { get; set; }
}
