namespace CRM.Models;

public class ResultInsertQuickCmpPrsPrjCnvs
{
	public int CompanyId { get; set; }

	public int CompanyPersonId { get; set; }

	public int ProjectId { get; set; }

	public int ConversationId { get; set; }

	public string Message { get; set; }

	public bool IsDone { get; set; }

	public string MsgForPolicyInfoSms { get; set; }

	public string TitleForPolicyInfoSms { get; set; }
}
