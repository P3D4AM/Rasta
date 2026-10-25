using System;

namespace Mobile.Models;

public class FOMobspSelectCompanyProjectById_Result
{
	public int ProjectID { get; set; }

	public int prjCompanyId { get; set; }

	public string CompanyName { get; set; }

	public string prjTitle { get; set; }

	public string prjDesc { get; set; }

	public string prjStartDay { get; set; }

	public string prjStartTime { get; set; }

	public DateTime? prjStartDate { get; set; }

	public string prjStartDatePerWithSlash { get; set; }

	public int? prjStarterUserId { get; set; }

	public string prjStarterUser { get; set; }

	public int? prjFinishedStatusId { get; set; }

	public bool? prjIsFinished { get; set; }

	public string prjFinishedDay { get; set; }

	public string prjFinishedTime { get; set; }

	public DateTime? prjFinishedDate { get; set; }

	public string prjFinishedDatePerWithSlash { get; set; }

	public int? prjFinishedUserId { get; set; }

	public string prjFinishedUser { get; set; }

	public int? prjGradeId { get; set; }

	public string prjGrade { get; set; }

	public int? prjPriorityId { get; set; }

	public string prjPriority { get; set; }

	public string prjPriorityColor { get; set; }

	public int? FirstRegisterUserId { get; set; }

	public string FirstRegisterUser { get; set; }

	public DateTime? FirstRegisterDate { get; set; }

	public string FirstRegisterDatePerWithSlash { get; set; }

	public int UserId { get; set; }

	public string RegisterUser { get; set; }

	public DateTime RegisterDate { get; set; }

	public string RegisterDatePerWithSlash { get; set; }

	public int? prjGroupId { get; set; }

	public string prjGroup { get; set; }

	public int? prjcnvsStatusGroupId { get; set; }

	public string prjcnvsStatusGroup { get; set; }

	public int? prjOrderView { get; set; }

	public string prjPostFix { get; set; }

	public DateTime? prjRemindDate { get; set; }

	public string prjRemindDatePerWithSlash { get; set; }

	public string ProjectTitle { get; set; }

	public string TitlePercent { get; set; }

	public int? ProjectPercent { get; set; }

	public int? ProjectCompletionCount { get; set; }

	public int? ConversationCount { get; set; }

	public string LastCnvsStatus { get; set; }

	public bool? prjFOCmpCanInsCnvs { get; set; }

	public bool? prjFOCmpCanNotInsCnvs { get; set; }
}
