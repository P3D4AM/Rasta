namespace Mobile.Models;

public class HrmTimeAttendanceDateStatusViewModel
{
	public string tmDate { get; set; }

	public string tmCurrentEntryTime { get; set; }

	public string tmCurrentExitTime { get; set; }

	public string tmCurrentEntryRegisterIP { get; set; }

	public string tmCurrentExitRegisterIP { get; set; }

	public string tmDuplicateEntryTime { get; set; }

	public int? tmDuplicateEntryRequestId { get; set; }

	public string tmDuplicateExitTime { get; set; }

	public int? tmDuplicateExitRequestId { get; set; }

	public bool EntryRequestIsRequired { get; set; }

	public bool HasAttendance { get; set; }
}
