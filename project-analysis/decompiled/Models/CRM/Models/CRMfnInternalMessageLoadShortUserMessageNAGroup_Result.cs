using System;

namespace CRM.Models;

public class CRMfnInternalMessageLoadShortUserMessageNAGroup_Result
{
	public int InternalMessageID { get; set; }

	public string msgSubject { get; set; }

	public string msgBody { get; set; }

	public int msgdTypeId { get; set; }

	public string MessageType { get; set; }

	public int? msgdOldTypeId { get; set; }

	public int InternalMessageDetailID { get; set; }

	public int msgdFromUserId { get; set; }

	public string FromUser { get; set; }

	public int msgdToUserId { get; set; }

	public string ToUser { get; set; }

	public string OtherUser { get; set; }

	public string ToAndOtherUser { get; set; }

	public string msgdSendDate { get; set; }

	public string msgdSendTime { get; set; }

	public DateTime msgdSendDateTime { get; set; }

	public string SendDateTime { get; set; }

	public string msgdReceiveDate { get; set; }

	public string msgdReceiveTime { get; set; }

	public DateTime? msgdReceiveDateTime { get; set; }

	public string ReceiveDateTime { get; set; }

	public bool? msgdIsRead { get; set; }

	public int? msgdPriorityId { get; set; }

	public string InternalMessagePriority { get; set; }

	public int? msgdGroupId { get; set; }

	public string InternalMessageGroup { get; set; }

	public int UserId { get; set; }

	public int msgMasterId { get; set; }

	public int? msgIsFinalised { get; set; }

	public int? msgLastGroupId { get; set; }

	public bool? msgActiveInCycle { get; set; }

	public int? msgCId { get; set; }

	public string CenterName { get; set; }

	public string CenterCode { get; set; }
}
