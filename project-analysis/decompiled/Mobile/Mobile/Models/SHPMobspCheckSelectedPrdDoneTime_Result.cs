using System;

namespace Mobile.Models;

public class SHPMobspCheckSelectedPrdDoneTime_Result
{
	public string PrdIds { get; set; }

	public DateTime? PrdDate { get; set; }

	public int? PrdSaleCenterId { get; set; }

	public int? PrdSaleCenterParentId { get; set; }

	public string PrdStartTime { get; set; }

	public int? PrdStartTimeMin { get; set; }

	public string PrdEndTime { get; set; }

	public int? PrdEndTimeMin { get; set; }

	public int? TotalDoneTimeMin { get; set; }

	public string DetectedDoneTime { get; set; }
}
