using System;

namespace CRM.Models;

public class CRMspRpt_CompanyProjectAndCnvsInfoWithFilterData_Result
{
	public string rptUserName { get; set; }

	public string rptDate { get; set; }

	public string rptDay { get; set; }

	public int ProjectID { get; set; }

	public int prjCompanyId { get; set; }

	public string Company { get; set; }

	public string CompanyReferUser { get; set; }

	public int? CompanyNumber { get; set; }

	public string CompanyCode { get; set; }

	public string CompanyCountry { get; set; }

	public string CompanyProvince { get; set; }

	public string CompanyCity { get; set; }

	public string CompanyAddress { get; set; }

	public string CompanyTel { get; set; }

	public string CompanyTelII { get; set; }

	public string CompanyFax { get; set; }

	public string ProjectTitle { get; set; }

	public string prjTitle { get; set; }

	public string prjDesc { get; set; }

	public string prjStartDate { get; set; }

	public string prjStartDay { get; set; }

	public string prjStartTime { get; set; }

	public DateTime? prjStartDateTime { get; set; }

	public int? prjStarterUserId { get; set; }

	public string prjStarterUser { get; set; }

	public int? prjFinishedStatusId { get; set; }

	public string prjFinishedStatus { get; set; }

	public bool? prjIsFinished { get; set; }

	public string prjFinishedDate { get; set; }

	public string prjFinishedDay { get; set; }

	public string prjFinishedTime { get; set; }

	public DateTime? prjFinishedDateTime { get; set; }

	public int? prjFinishedUserId { get; set; }

	public string prjFinishedUser { get; set; }

	public int? prjGradeId { get; set; }

	public string prjGrade { get; set; }

	public int? prjPriorityId { get; set; }

	public string prjPriority { get; set; }

	public int prjUserId { get; set; }

	public string prjRegisterUser { get; set; }

	public DateTime prjRegisterDate { get; set; }

	public string prjRegisterDatePersian { get; set; }

	public int? prjGroupId { get; set; }

	public string prjGroup { get; set; }

	public int? prjcnvsStatusGroupId { get; set; }

	public string prjcnvsStatusGroup { get; set; }

	public int? prjOrderView { get; set; }

	public string prjPostFix { get; set; }

	public int? prjFirstRegisterUserId { get; set; }

	public string prjFirstRegisterUser { get; set; }

	public string prjFirstRegisterDatePersian { get; set; }

	public DateTime? prjFirstRegisterDate { get; set; }

	public string prjRemindDate { get; set; }

	public DateTime? prjRemindDateTime { get; set; }

	public bool? prjFOCmpCanSee { get; set; }

	public bool? prjIsTicket { get; set; }

	public int? prjUserDepartmentId { get; set; }

	public string prjUserDepartment { get; set; }

	public int? ConversationID { get; set; }

	public int? cnvsProjectId { get; set; }

	public int? cnvsCompanyId { get; set; }

	public string cnvsDate { get; set; }

	public string cnvsDay { get; set; }

	public string cnvsTime { get; set; }

	public DateTime? cnvsDateTime { get; set; }

	public int? cnvsTopicId { get; set; }

	public string cnvsTopic { get; set; }

	public string cnvsSubject { get; set; }

	public string cnvsDesc { get; set; }

	public int? cnvsPersonId { get; set; }

	public string Person { get; set; }

	public string PersonMobile { get; set; }

	public string PersonEmail { get; set; }

	public string PersonEmailII { get; set; }

	public int? cnvsUserId { get; set; }

	public string cnvsUser { get; set; }

	public int? cnvsReferUserId { get; set; }

	public string cnvsReferUser { get; set; }

	public string cnvsReferDesc { get; set; }

	public int? cnvsStatusId { get; set; }

	public string cnvsStatus { get; set; }

	public int? cnvsPriorityId { get; set; }

	public string cnvsPriority { get; set; }

	public string cnvsRemindDate { get; set; }

	public string cnvsRemindTime { get; set; }

	public DateTime? cnvsRemindDateTime { get; set; }

	public bool? cnvsRemindOk { get; set; }

	public bool? cnvsIsBookMark { get; set; }

	public int? cnvsRegisterUserId { get; set; }

	public string cnvsRegisterUser { get; set; }

	public DateTime? cnvsRegisterDate { get; set; }

	public string cnvsRegisterDatePersian { get; set; }

	public int? cnvsFirstRegisterUserId { get; set; }

	public string cnvsFirstRegisterUser { get; set; }

	public string cnvsFirstRegisterDatePersian { get; set; }

	public DateTime? cnvsFirstRegisterDate { get; set; }

	public string cnvsRemindDateForAllarm { get; set; }

	public DateTime? cnvsRemindDateTimeForAllarm { get; set; }

	public bool? cnvsFOCmpCanSee { get; set; }

	public bool? cnvsIsTicket { get; set; }

	public string cnvsCoordinateLatitude { get; set; }

	public string cnvsCoordinateLongitude { get; set; }

	public DateTime? cnvsCoordinateLastDate { get; set; }

	public string cnvsCoordinateLastDatePersian { get; set; }

	public bool? cnvsTicketIsRead { get; set; }

	public TimeSpan? cnvsDoingTime { get; set; }

	public bool? cnvsIsCopy { get; set; }

	public int prjId { get; set; }

	public long? cnvsDoingTimeSec { get; set; }

	public int? cnvsStatusResultId { get; set; }

	public string cnvsStatusResult { get; set; }

	public string cnvsDoingTimeFrom { get; set; }

	public string cnvsDoingTimeTo { get; set; }
}
