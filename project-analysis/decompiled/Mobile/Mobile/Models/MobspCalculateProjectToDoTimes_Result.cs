using System;

namespace Mobile.Models;

public class MobspCalculateProjectToDoTimes_Result
{
	public DateTime? prjToDoTime { get; set; }

	public DateTime? prjToDoTimeRegister { get; set; }

	public DateTime? prjToDoTimeDone { get; set; }

	public int? prjToDoTotalYear { get; set; }

	public int? prjToDoTotalMonth { get; set; }

	public int? prjToDoTotalDay { get; set; }

	public int? prjToDoTotalHour { get; set; }

	public int? prjToDoTotalMinute { get; set; }

	public int? IsCurrTimeAfterToDoTime { get; set; }

	public int? prjToDoRemainYear { get; set; }

	public int? prjToDoRemainMonth { get; set; }

	public int? prjToDoRemainDay { get; set; }

	public int? prjToDoRemainHour { get; set; }

	public int? prjToDoRemainMinute { get; set; }

	public int IsDoneTimeAfterToDoTime { get; set; }

	public int? prjToDoDoneRemainYear { get; set; }

	public int? prjToDoDoneRemainMonth { get; set; }

	public int? prjToDoDoneRemainDay { get; set; }

	public int? prjToDoDoneRemainHour { get; set; }

	public int? prjToDoDoneRemainMinute { get; set; }
}
