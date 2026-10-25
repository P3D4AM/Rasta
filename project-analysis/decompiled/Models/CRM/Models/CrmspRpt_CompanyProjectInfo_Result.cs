using System;

namespace CRM.Models;

public class CrmspRpt_CompanyProjectInfo_Result
{
	public string rptDate { get; set; }

	public string rptDay { get; set; }

	public int? rptUserId { get; set; }

	public string rptUserName { get; set; }

	public int ProjectID { get; set; }

	public int prjCompanyId { get; set; }

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

	public string prjFirstRegisterDate { get; set; }

	public int prjFirstRegisterUserId { get; set; }

	public string prjFirstRegisterUser { get; set; }

	public int prjUserId { get; set; }

	public string prjUser { get; set; }

	public DateTime prjRegisterDate { get; set; }

	public string prjRegisterDatePersian { get; set; }

	public string prjRemindDate { get; set; }

	public DateTime? prjRemindDateTime { get; set; }

	public bool? prjFOCmpCanSee { get; set; }

	public bool? prjIsTicket { get; set; }

	public int? prjUserDepartmentId { get; set; }

	public string prjUserDepartment { get; set; }
}
