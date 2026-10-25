using System;

namespace CRM.Models;

public class CRMspResultsUserLocationCartable_Result
{
	public int UserId { get; set; }

	public string FullName { get; set; }

	public int UserRollId { get; set; }

	public string RollName { get; set; }

	public string CoordinateLatitude { get; set; }

	public string CoordinateLongitude { get; set; }

	public DateTime? CoordinateLastDate { get; set; }

	public string CoordinateLastDatePersian { get; set; }
}
