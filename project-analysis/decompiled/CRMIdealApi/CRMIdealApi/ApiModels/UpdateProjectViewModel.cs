using System;

namespace CRMIdealApi.ApiModels;

public class UpdateProjectViewModel
{
	public string UserName { get; set; }

	public string Password { get; set; }

	public int UserId { get; set; }

	public int ApiCompanyId { get; set; }

	public int ApiProjectId { get; set; }

	public string ApiPrjTitle { get; set; }

	public string ApiPrjDesc { get; set; }

	public string ApiPrjStartDate { get; set; }

	public DateTime? ApiPrjStartDateTime { get; set; }

	public int? ApiPrjStarterUserId { get; set; }

	public int? ApiPrjFinishedStatusId { get; set; }

	public bool? ApiPrjIsFinished { get; set; }

	public string ApiPrjFinishedDate { get; set; }

	public DateTime? ApiPrjFinishedDateTime { get; set; }

	public int? ApiPrjFinishedUserId { get; set; }

	public int? ApiPrjGradeId { get; set; }

	public int? ApiPrjPriorityId { get; set; }

	public int? ApiPrjGroupId { get; set; }

	public int? ApiPrjCnvsStatusGroupId { get; set; }

	public int? ApiPrjOrderView { get; set; }

	public string ApiPrjPostFix { get; set; }

	public string ApiPrjRemindDate { get; set; }

	public DateTime? ApiPrjRemindDateTime { get; set; }

	public bool? ApiPrjFOCmpCanSee { get; set; }

	public bool? ApiPrjIsTicket { get; set; }

	public int? ApiPrjUserDepartmentId { get; set; }

	public string ApiPrjSmsPrsIds { get; set; }

	public string ApiPrjSmsText { get; set; }

	public string ApiPrjSmsSendDatePersian { get; set; }

	public DateTime? ApiPrjSmsSendDate { get; set; }

	public bool? PrjPostFixNotDup { get; set; }

	public bool? PrjDescNotDup { get; set; }

	public int? ApiPrjCmpPresentationId { get; set; }

	public string ApiPrjCmpCampaignIds { get; set; }

	public string ApiPrjCmpCampaignName { get; set; }

	public string ApiPrjTitleGroup { get; set; }

	public int? ApiPrjCategoryId { get; set; }

	public long? ApiPrjNumR { get; set; }

	public string ApiPrjNumRef { get; set; }

	public int? LanguageId { get; set; }
}
