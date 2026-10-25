namespace Mobile.Models;

public class LeaveReplaceUserVerificationRequestLanguageViewModel
{
	public int LeaveId { get; set; }

	public string VerifyText { get; set; }

	public string VerifyText_Lang { get; set; }

	public int? LanguageId { get; set; }

	public int? MsgId { get; set; }

	public int MsgTypeId { get; set; }

	public int? CenterId { get; set; }
}
