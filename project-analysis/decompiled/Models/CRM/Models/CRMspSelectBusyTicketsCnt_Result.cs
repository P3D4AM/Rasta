namespace CRM.Models;

public class CRMspSelectBusyTicketsCnt_Result
{
	public int? TotalCntTicketsCnt { get; set; }

	public int? TotalTicketsCntSendedBefore { get; set; }

	public int? TotalTicketsCntSeperateByUsers { get; set; }

	public int? TotalIntMsgSendedSeperateByUsers { get; set; }

	public int? TotalSmsSendedToTankSeperateByUsers { get; set; }
}
