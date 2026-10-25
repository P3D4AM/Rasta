namespace CRM.Models;

public class CRMspSelectDelayTicketsCnt_Result
{
	public int? TotalTicketsCnt { get; set; }

	public int? TotalTicketsCntSendedBefore { get; set; }

	public int? TotalTicketsCntSeperateByUsers { get; set; }

	public int? TotalIntMsgSendedSeperateByUsers { get; set; }

	public int? TotalSmsSendedToTankSeperateByUsers { get; set; }
}
