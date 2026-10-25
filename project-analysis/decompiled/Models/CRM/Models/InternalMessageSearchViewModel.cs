namespace CRM.Models;

public class InternalMessageSearchViewModel
{
	public string FromDate { get; set; }

	public string ToDate { get; set; }

	public string MsgdUserId { get; set; }

	public string MsgdToUserId { get; set; }

	public string MsgdFromUserId { get; set; }

	public string MsgdTypeId { get; set; }

	public string MsgdIsRead { get; set; }

	public string MsgSubject { get; set; }

	public string MsgBody { get; set; }
}
