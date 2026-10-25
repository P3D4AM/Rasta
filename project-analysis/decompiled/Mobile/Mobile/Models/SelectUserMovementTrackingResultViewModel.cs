using System.Collections.Generic;

namespace Mobile.Models;

public class SelectUserMovementTrackingResultViewModel
{
	public List<MobspSelectUserMovementTracking_Result> Tracking { get; set; }

	public List<MobspSelectUserMovementTrackingPolygonWithPolygonUserId_Result> Polygon { get; set; }
}
