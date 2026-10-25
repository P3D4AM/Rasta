namespace Mobile.Models;

public class FOMobspSelectCrmConversationStatus_Result
{
	public int ConversationStatusID { get; set; }

	public short? StatusOrder { get; set; }

	public string Status { get; set; }

	public string StatusDesc { get; set; }

	public int? ProgressPercent { get; set; }

	public int? GroupId { get; set; }
}
