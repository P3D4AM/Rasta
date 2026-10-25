using System;

namespace CRM.Models;

public class CRMspSelectCrmProjectBycmpAndUser_Result
{
	public int ProjectID { get; set; }

	public int prjCompanyId { get; set; }

	public string prjTitle { get; set; }

	public string prjDesc { get; set; }

	public string prjStartDate { get; set; }

	public string prjStartDay { get; set; }

	public string prjStartTime { get; set; }

	public DateTime? prjStartDateTime { get; set; }

	public int? prjStarterUserId { get; set; }

	public int? prjFinishedStatusId { get; set; }

	public bool? prjIsFinished { get; set; }

	public string prjFinishedDate { get; set; }

	public string prjFinishedDay { get; set; }

	public string prjFinishedTime { get; set; }

	public DateTime? prjFinishedDateTime { get; set; }

	public int? prjFinishedUserId { get; set; }

	public int? prjGradeId { get; set; }

	public int? prjPriorityId { get; set; }

	public string prjFirstRegisterDate { get; set; }

	public int prjFirstRegisterUserId { get; set; }

	public int UserId { get; set; }

	public short Year1 { get; set; }

	public short Month1 { get; set; }

	public DateTime RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	public Guid? GUId { get; set; }

	public int? prjGroupId { get; set; }

	public int? prjcnvsStatusGroupId { get; set; }

	public int? prjOrderView { get; set; }

	public string AppType { get; set; }

	public string prjPostFix { get; set; }

	public int? LanguageID { get; set; }

	public int? FirstRegisterUserId { get; set; }

	public DateTime? FirstRegisterDateTime { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public DateTime? prjFirstRegisterDateTime { get; set; }

	public DateTime? FirstRegisterDate { get; set; }

	public string prjRemindDate { get; set; }

	public DateTime? prjRemindDateTime { get; set; }

	public bool? prjFOCmpCanSee { get; set; }

	public bool? prjIsTicket { get; set; }

	public int? prjUserDepartmentId { get; set; }

	public bool? prjHaveSms { get; set; }

	public string prjSmsPrsIds { get; set; }

	public string prjSmsText { get; set; }

	public DateTime? prjSmsSendDate { get; set; }

	public string prjSmsSendDatePersian { get; set; }

	public string prjInquiryNum { get; set; }

	public long? prjNumR { get; set; }

	public string prjNumRef { get; set; }

	public DateTime? prjToDoTime { get; set; }

	public DateTime? prjToDoTimeRegister { get; set; }

	public DateTime? prjToDoTimeDone { get; set; }
}
