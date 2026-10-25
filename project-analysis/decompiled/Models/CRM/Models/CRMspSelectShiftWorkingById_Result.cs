using System;

namespace CRM.Models;

public class CRMspSelectShiftWorkingById_Result
{
	public int ShiftWorkingID { get; set; }

	public string swTitle { get; set; }

	public int? OrderView { get; set; }

	public int? swMaxSoonEntryTime { get; set; }

	public int? swMaxLateExitTime { get; set; }

	public DateTime FirstRegisterDateTime { get; set; }

	public string User { get; set; }

	public string FirstRegisterDate { get; set; }

	public string ShiftWorkingLangJson { get; set; }

	public int? swMaxLateEntryTime { get; set; }

	public int? swMaxIsCloseDurationTime { get; set; }

	public int? swMaxSoonExitTime { get; set; }
}
