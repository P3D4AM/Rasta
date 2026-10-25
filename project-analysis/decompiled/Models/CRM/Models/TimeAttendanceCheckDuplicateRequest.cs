namespace CRM.Models;

public class TimeAttendanceCheckDuplicateRequest
{
	public int RequestId { get; set; }

	public string tmDate { get; set; }

	public string tmTime { get; set; }

	public string tmUser { get; set; }
}
