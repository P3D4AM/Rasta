namespace CRM.Models;

public class UserLocationViewModel
{
	public int UserId { get; set; }

	public string FullName { get; set; }

	public string RollName { get; set; }

	public string CoordinateLatitude { get; set; }

	public string CoordinateLongitude { get; set; }

	public string CoordinateLastDate { get; set; }

	public string CoordinateLastTime { get; set; }

	public string CmpAccess { get; set; }
}
