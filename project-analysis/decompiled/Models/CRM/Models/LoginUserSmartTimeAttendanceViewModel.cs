using System;

namespace CRM.Models;

public class LoginUserSmartTimeAttendanceViewModel
{
	public int UserId { get; set; }

	public string SmartTimeAttendanceQRCode { get; set; }

	public string SmartTimeAttendanceMainQRCode { get; set; }

	public DateTime SmartTimeAttendanceFirstRegisterDate { get; set; }

	public DateTime? SmartTimeAttendanceRegisterDate { get; set; }

	public string SmartTimeAttendanceParamJson { get; set; }
}
