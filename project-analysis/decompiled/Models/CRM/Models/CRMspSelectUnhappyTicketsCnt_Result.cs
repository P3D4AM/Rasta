namespace CRM.Models;

public class CRMspSelectUnhappyTicketsCnt_Result
{
	public int? TotalCntTicketsCnt { get; set; }

	public int? TotalTicketsCntSendedBefore { get; set; }

	public int? TotalTicketsCntSeperateByUsers { get; set; }

	public int? TotalIntMsgSendedSeperateByUsers { get; set; }

	public int? TotalSmsSendedToTankSeperateByUsers { get; set; }
}
