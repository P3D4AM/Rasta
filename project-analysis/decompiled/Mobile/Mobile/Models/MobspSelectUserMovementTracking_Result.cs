using System;

namespace Mobile.Models;

public class MobspSelectUserMovementTracking_Result
{
	public int MovementTrackingId { get; set; }

	public string Coordinate { get; set; }

	public int FirstRegisterUserId { get; set; }

	public DateTime FirstRegisterDate { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public string FirstRegisterUser { get; set; }
}
