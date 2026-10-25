namespace CRM.Models;

public class ShiftWorkingDayViewModel
{
	public bool IsActive { get; set; }

	public int DayNum { get; set; }

	public string EntryTime { get; set; }

	public string EntryTimeSoon { get; set; }

	public string EntryTimeLate { get; set; }

	public string ExitTime { get; set; }

	public string ExitTimeSoon { get; set; }

	public string ExitTimeLate { get; set; }

	public bool IsClose { get; set; }

	public string IsCloseEntryTime { get; set; }

	public string IsCloseExitTime { get; set; }

	public string IsCloseDurationTime { get; set; }
}
