using System;

namespace CRM.Models;

public class CRMspSelectShiftWorkings_Result
{
	public int ShiftWorkingID { get; set; }

	public string swTitle { get; set; }

	public int? swMaxSoonEntryTime { get; set; }

	public int? swMaxLateExitTime { get; set; }

	public DateTime FirstRegisterDate { get; set; }

	public int? swMaxLateEntryTime { get; set; }

	public int? swMaxSoonExitTime { get; set; }

	public int? swMaxIsCloseDurationTime { get; set; }
}
