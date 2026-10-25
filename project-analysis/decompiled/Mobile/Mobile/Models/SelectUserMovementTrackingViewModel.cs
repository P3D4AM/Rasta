using System;

namespace Mobile.Models;

public class SelectUserMovementTrackingViewModel
{
	public string UserIds { get; set; }

	public DateTime FromDate { get; set; }

	public DateTime ToDate { get; set; }

	public string FromTime { get; set; }

	public string ToTime { get; set; }

	public bool ShowPolygon { get; set; }

	public int? LanguageId { get; set; }
}
