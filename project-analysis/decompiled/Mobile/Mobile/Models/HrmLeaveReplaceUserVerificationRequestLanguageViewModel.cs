namespace Mobile.Models;

public class HrmLeaveReplaceUserVerificationRequestLanguageViewModel
{
	public int LeaveId { get; set; }

	public string VerifyText { get; set; }

	public string VerifyText_Lang { get; set; }

	public int Status { get; set; }

	public int? LanguageId { get; set; }

	public int? CenterId { get; set; }
}
