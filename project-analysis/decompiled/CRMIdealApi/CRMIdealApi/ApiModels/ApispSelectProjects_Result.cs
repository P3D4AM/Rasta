using System;

namespace CRMIdealApi.ApiModels;

public class ApispSelectProjects_Result
{
	public int ApiProjectID { get; set; }

	public int ApiPrjCompanyId { get; set; }

	public string ApiPrjCompany { get; set; }

	public string ApiPrjTitle { get; set; }

	public string ApiProjectTitle { get; set; }

	public string ApiPrjDesc { get; set; }

	public string ApiPrjStartDate { get; set; }

	public string ApiPrjStartDay { get; set; }

	public string ApiPrjStartTime { get; set; }

	public DateTime? ApiPrjStartDateTime { get; set; }

	public int? ApiPrjStarterUserId { get; set; }

	public string ApiPrjStarterUser { get; set; }

	public int? ApiPrjFinishedStatusId { get; set; }

	public bool? ApiPrjIsFinished { get; set; }

	public string ApiPrjFinishedDate { get; set; }

	public string ApiPrjFinishedDay { get; set; }

	public string ApiPrjFinishedTime { get; set; }

	public DateTime? ApiPrjFinishedDateTime { get; set; }

	public int? ApiPrjFinishedUserId { get; set; }

	public string ApiPrjFinishedUser { get; set; }

	public int? ApiPrjGradeId { get; set; }

	public string ApiPrjGrade { get; set; }

	public int? ApiPrjPriorityId { get; set; }

	public string ApiPrjPriority { get; set; }

	public int? ApiPrjGroupId { get; set; }

	public string ApiPrjGroup { get; set; }

	public int? ApiPrjcnvsStatusGroupId { get; set; }

	public string ApiPrjcnvsStatusGroup { get; set; }

	public int? ApiPrjOrderView { get; set; }

	public string ApiPrjPostFix { get; set; }

	public string ApiPrjRemindDate { get; set; }

	public DateTime? ApiPrjRemindDateTime { get; set; }

	public bool? ApiPrjFOCmpCanSee { get; set; }

	public bool? ApiPrjIsTicket { get; set; }

	public int? ApiPrjUserDepartmentId { get; set; }

	public string ApiPrjUserDepartment { get; set; }

	public bool? ApiPrjHaveSms { get; set; }

	public string ApiPrjSmsPrsIds { get; set; }

	public string ApiPrjSmsText { get; set; }

	public DateTime? ApiPrjSmsSendDate { get; set; }

	public string ApiPrjSmsSendDatePersian { get; set; }

	public int ApiUserId { get; set; }

	public string ApiEditUser { get; set; }

	public DateTime ApiRegisterDate { get; set; }

	public DateTime? ApiFirstRegisterDate { get; set; }

	public int? ApiFirstRegisterUserId { get; set; }

	public string ApiFirstRegisterUser { get; set; }

	public int? ApiPrjCmpPresentationId { get; set; }

	public string ApiPrjCmpPresentation { get; set; }

	public string ApiPrjCmpmpCampaignIds { get; set; }

	public string ApiPrjCmpmpCampaign { get; set; }

	public int? ApiPrjCategoryId { get; set; }

	public string ApiPrjCategory { get; set; }

	public string ApiPrjTitleGroup { get; set; }

	public long? ApiRowNumber { get; set; }

	public int? ApiTotalCount { get; set; }
}
