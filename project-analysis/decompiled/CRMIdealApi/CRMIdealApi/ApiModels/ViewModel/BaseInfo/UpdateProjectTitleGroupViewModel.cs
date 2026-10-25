namespace CRMIdealApi.ApiModels.ViewModel.BaseInfo;

public class UpdateProjectTitleGroupViewModel : PublicParametersWithOutCenter
{
	public string ApiProjectTitleGroup { get; set; }

	public string ApiProjectTitleGroupDesc { get; set; }

	public int? ApiProjectTitleGroupUserDepartmentId { get; set; }

	public bool? ApiProjectTitleGroupAgreementActive { get; set; }

	public string ApiProjectTitleGroupAgreementDesc { get; set; }

	public string ApiProjectTitleGroupSubjectDefaultContext { get; set; }

	public bool? ApiProjectTitleGroupTicketCountCurrentWithStop { get; set; }

	public int? ApiProjectTitleGroupTicketAllowInCurrentCount { get; set; }

	public string ProjectTitleGroupColor { get; set; }

	public int ApiProjectTitleGroupId { get; set; }
}
