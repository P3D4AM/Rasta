using System;

namespace CRM.Models;

public class CrmDailyLeaveDetailsViewModel
{
	public int? LeaveId { get; set; }

	public int? RequestUserId { get; set; }

	public int? ReplaceUserId { get; set; }

	public string ReplaceUser { get; set; }

	public string RequestUser { get; set; }

	public DateTime? FromDateTime { get; set; }

	public string FromDate { get; set; }

	public DateTime? ToDateTime { get; set; }

	public string ToDate { get; set; }

	public int? DayCount { get; set; }

	public string Reason { get; set; }

	public string Reason_Lang { get; set; }

	public int? LeaveTypeId { get; set; }

	public int? LeaveStatusId { get; set; }

	public string LeaveStatus { get; set; }

	public int? VerifierUserId { get; set; }

	public string VerifierUser { get; set; }

	public string RequestDateTimeStr { get; set; }

	public string Description { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public DateTime? FirstRegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	public DateTime RegisterDate { get; set; }

	public int? FirstRegisterUserId { get; set; }

	public int UserId { get; set; }

	public string EditUser { get; set; }

	public string FirstRegisterUser { get; set; }

	public string LeaveStatusStr { get; set; }

	public int? VerificationWorkFlowId { get; set; }

	public int? LeaveVerificationWorkFlowId { get; set; }

	public bool? ReplaceUserIsVerified { get; set; }

	public bool? IsCanceled { get; set; }

	public int? CancelerUserId { get; set; }

	public string CancelerUser { get; set; }

	public string CanceledDatePersian { get; set; }

	public string LeaveCancelStr { get; set; }

	public int MonthlyDailySum { get; set; }

	public int MonthlyHourlySumInMin { get; set; }

	public string MonthlyHourlySumTxt { get; set; }

	public int YearlyDailySum { get; set; }

	public int YearlyHourlySumInMin { get; set; }

	public string YealyHourlySumTxt { get; set; }

	public int TotallyDailySum { get; set; }

	public int TotallyHourlySumInMin { get; set; }

	public string TotallyHourlySumTxt { get; set; }

	public string MonthlyLeaveStr { get; set; }

	public string YearlyLeaveStr { get; set; }

	public string TotallyLeaveStr { get; set; }

	public string UserDepartment { get; set; }

	public string UserResponsible { get; set; }
}
