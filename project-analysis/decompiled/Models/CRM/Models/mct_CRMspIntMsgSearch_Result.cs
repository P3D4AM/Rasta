using System;

namespace CRM.Models;

public class mct_CRMspIntMsgSearch_Result
{
	public int? InternalMessageID { get; set; }

	public string msgSubject { get; set; }

	public int? msgdTypeId { get; set; }

	public string MessageType { get; set; }

	public int? msgdOldTypeId { get; set; }

	public int? InternalMessageDetailID { get; set; }

	public int? msgdFromUserId { get; set; }

	public string FromUser { get; set; }

	public int? msgdToUserId { get; set; }

	public string ToUser { get; set; }

	public DateTime? msgdSendDateTime { get; set; }

	public DateTime? msgdReceiveDateTime { get; set; }

	public bool? msgdIsRead { get; set; }

	public int? msgdPriorityId { get; set; }

	public string InternalMessagePriority { get; set; }

	public int? msgdGroupId { get; set; }

	public int? UserId { get; set; }

	public int? msgMasterId { get; set; }

	public int? msgIsFinalised { get; set; }

	public int? msgLastGroupId { get; set; }

	public bool? msgActiveInCycle { get; set; }

	public DateTime? msgdReadDateTime { get; set; }

	public int? msgCId { get; set; }

	public string CenterName { get; set; }

	public string CenterCode { get; set; }
}
