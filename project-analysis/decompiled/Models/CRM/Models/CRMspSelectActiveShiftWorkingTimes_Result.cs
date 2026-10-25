using System;

namespace CRM.Models;

public class CRMspSelectActiveShiftWorkingTimes_Result
{
	public int ShiftWorkingTimeID { get; set; }

	public int swtShiftWorkingID { get; set; }

	public string swtShiftWorking { get; set; }

	public string swtTitle { get; set; }

	public bool? swtIsDisabled { get; set; }

	public short? swtCalendareTypeId { get; set; }

	public string swtWeekDays { get; set; }

	public int? swtMonthStartDay { get; set; }

	public int? swtMonthEndDay { get; set; }

	public string swtMonthNums { get; set; }

	public int? swtYearStart { get; set; }

	public int? swtYearEnd { get; set; }

	public bool? swtSoonEntryTimeNeedVerify { get; set; }

	public int? swtSoonEntryTimeWorkflowId { get; set; }

	public bool? swtLateEntryTimeNeedVerify { get; set; }

	public int? swtLateEntryTimeWorkflowId { get; set; }

	public bool? swtSoonExitTimeNeedVerify { get; set; }

	public int? swtSoonExitTimeWorkflowId { get; set; }

	public bool? swtLateExitTimeNeedVerify { get; set; }

	public int? swtLateExitTimeWorkflowId { get; set; }

	public int? OrderView { get; set; }

	public int FirstRegisterUserId { get; set; }

	public string FirstRegisterUser { get; set; }

	public DateTime FirstRegisterDate { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public int UserId { get; set; }

	public string EditUser { get; set; }

	public short Year1 { get; set; }

	public short Month1 { get; set; }

	public DateTime RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	public Guid GUId { get; set; }

	public string AppType { get; set; }

	public int LanguageID { get; set; }

	public short? swtTypeId { get; set; }
}
