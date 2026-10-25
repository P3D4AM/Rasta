using System;

namespace CRM.Models;

public class CRMspResultsInternalMessageCartable_Result
{
	public int? msgMasterId { get; set; }

	public int InternalMessageID { get; set; }

	public string msgSubject { get; set; }

	public string msgBody { get; set; }

	public int? msgdFromUserId { get; set; }

	public string FromUser { get; set; }

	public int? msgdPriorityId { get; set; }

	public string InternalMessagePriority { get; set; }

	public string msgdSendDate { get; set; }

	public string msgdSendTime { get; set; }

	public DateTime? msgdSendDateTime { get; set; }

	public string SendDateTime { get; set; }

	public bool? msgdIsRead { get; set; }
}
