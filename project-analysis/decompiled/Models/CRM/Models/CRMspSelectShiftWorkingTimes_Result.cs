using System;

namespace CRM.Models;

public class CRMspSelectShiftWorkingTimes_Result
{
	public int ShiftWorkingTimeId { get; set; }

	public int swtShiftWorkingId { get; set; }

	public string swtTitle { get; set; }

	public bool? swtIsDisabled { get; set; }

	public short? swtCalendareTypeId { get; set; }

	public short? swtTypeId { get; set; }

	public string swtWeekDays { get; set; }

	public int? swtMonthStartDay { get; set; }

	public int? swtMonthEndDay { get; set; }

	public string swtMonthNums { get; set; }

	public int? swtYearStart { get; set; }

	public int? swtYearEnd { get; set; }

	public bool? swtSoonEntryTimeNeedVerify { get; set; }

	public int? swtSoonEntryTimeWorkflowId { get; set; }

	public string swtSoonEntryTimeWorkflow { get; set; }

	public bool? swtLateEntryTimeNeedVerify { get; set; }

	public int? swtLateEntryTimeWorkflowId { get; set; }

	public string swtLateEntryTimeWorkflow { get; set; }

	public bool? swtSoonExitTimeNeedVerify { get; set; }

	public int? swtSoonExitTimeWorkflowId { get; set; }

	public string swtSoonExitTimeWorkflow { get; set; }

	public bool? swtLateExitTimeNeedVerify { get; set; }

	public int? swtLateExitTimeWorkflowId { get; set; }

	public string swtLateExitTimeWorkflow { get; set; }

	public int? OrderView { get; set; }

	public DateTime FirstRegisterDateTime { get; set; }
}
