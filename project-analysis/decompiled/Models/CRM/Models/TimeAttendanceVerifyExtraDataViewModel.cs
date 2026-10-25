namespace CRM.Models;

public class TimeAttendanceVerifyExtraDataViewModel
{
	public string tmDate { get; set; }

	public string tmTime { get; set; }

	public string tmRegisterIP { get; set; }

	public string tmDescription { get; set; }

	public int? tmUserId { get; set; }

	public string UserLat { get; set; }

	public string UserLng { get; set; }

	public bool? RequestVerified { get; set; }

	public int? tmShiftWorkingId { get; set; }

	public int? tmShiftWorkingTimeId { get; set; }
}
