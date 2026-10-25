namespace CRM.Models;

public class CRMspIntMsgGetUnReadMessgeForUsers_Result
{
	public int? UserId { get; set; }

	public int MessageCnt { get; set; }

	public int VerifyCnt { get; set; }

	public int? MsgdTypeId { get; set; }

	public int? InternalMessageID { get; set; }
}
