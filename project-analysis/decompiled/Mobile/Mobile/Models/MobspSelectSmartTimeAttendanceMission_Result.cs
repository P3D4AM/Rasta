using System;

namespace Mobile.Models;

public class MobspSelectSmartTimeAttendanceMission_Result
{
	public int LeaveId { get; set; }

	public string PlaceCoordinateLatitude { get; set; }

	public string PlaceCoordinateLongitude { get; set; }

	public DateTime? FromDateTime { get; set; }

	public DateTime? ToDateTime { get; set; }
}
