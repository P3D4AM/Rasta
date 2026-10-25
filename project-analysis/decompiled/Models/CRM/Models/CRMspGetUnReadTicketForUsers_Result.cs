namespace CRM.Models;

public class CRMspGetUnReadTicketForUsers_Result
{
	public int? UserId { get; set; }

	public int InProgressCnt { get; set; }

	public int NewCnt { get; set; }

	public int? AllCnt { get; set; }
}
