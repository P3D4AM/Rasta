namespace CRM.Models;

public class LeaveReplaceUserVerificationRequestLanguageViewModel
{
	public int LeaveId { get; set; }

	public string VerifyText { get; set; }

	public string VerifyText_Lang { get; set; }

	public int Status { get; set; }

	public int? MsgId { get; set; }
}
