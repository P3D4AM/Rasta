namespace Mobile.Models;

public class MobspSelectShiftWorkingTimeByDate_Result
{
	public int ShiftWorkingTimeId { get; set; }

	public int swtShiftWorkingId { get; set; }

	public string swtShiftWorking { get; set; }

	public string swtTitle { get; set; }

	public int? DayNum { get; set; }

	public string EntryTime { get; set; }

	public int? EntryTimeMin { get; set; }

	public string EntryTimeSoon { get; set; }

	public int? EntryTimeSoonMin { get; set; }

	public string EntryTimeLate { get; set; }

	public int? EntryTimeLateMin { get; set; }

	public string ExitTime { get; set; }

	public int? ExitTimeMin { get; set; }

	public string ExitTimeSoon { get; set; }

	public int? ExitTimeSoonMin { get; set; }

	public string ExitTimeLate { get; set; }

	public int? ExitTimeLateMin { get; set; }

	public int? IsClose { get; set; }

	public string IsCloseDurationTime { get; set; }

	public int? IsCloseDurationTimeMin { get; set; }
}
