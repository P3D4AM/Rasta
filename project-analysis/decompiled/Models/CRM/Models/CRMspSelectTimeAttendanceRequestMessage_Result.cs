namespace CRM.Models;

public class CRMspSelectTimeAttendanceRequestMessage_Result
{
	public int TimeAttendanceRequestId { get; set; }

	public int RequestTypeId { get; set; }

	public string RequestData { get; set; }

	public int? MessageId { get; set; }

	public int? MessageDetailId { get; set; }

	public int MsgdTypeId { get; set; }

	public int? msgdFromUserId { get; set; }

	public int? msgdPriorityId { get; set; }

	public int? msgdAttachRecId { get; set; }

	public int? msgdAttachRecIdI { get; set; }
}
