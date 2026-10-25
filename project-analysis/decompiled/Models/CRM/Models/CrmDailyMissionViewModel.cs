using System;

namespace CRM.Models;

public class CrmDailyMissionViewModel
{
	public int LeaveId { get; set; }

	public int? LeaveTypeId { get; set; }

	public int? RequestUserId { get; set; }

	public int? ReplaceUserId { get; set; }

	public DateTime? FromDateTime { get; set; }

	public DateTime? ToDateTime { get; set; }

	public string FromDate { get; set; }

	public string ToDate { get; set; }

	public int? DayCount { get; set; }

	public int? VerifierUserId { get; set; }

	public string LeaveType { get; set; }

	public string RequestUser { get; set; }

	public string ReplaceUser { get; set; }

	public string LeaveStatus { get; set; }

	public string VerifierUser { get; set; }

	public int? VerificationWorkFlowId { get; set; }

	public string DatePeriodStr { get; set; }

	public string LeaveStatusStr { get; set; }
}
