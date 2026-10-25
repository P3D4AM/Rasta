namespace Mobile.Models;

public class TimeAttendanceEditRequestResultViewModel
{
	public MobspSelectTimeAttendanceRequestMessage_Result FirstRequest { get; set; }

	public MobspSelectTimeAttendanceRequestMessage_Result SecondRequest { get; set; }

	public MobspSelectTimeAttendanceByDate_Result CurrentRecord { get; set; }
}
