using System;

namespace CRM.Models;

public class CRMspInternalMessageInCyleDetailBymsgId_Result
{
	public int InternalMessageID { get; set; }

	public string msgSubject { get; set; }

	public string msgBody { get; set; }

	public int InternalMessageDetailID { get; set; }

	public int msgdTypeId { get; set; }

	public string MessageType { get; set; }

	public int? msgMasterId { get; set; }

	public int msgdFromUserId { get; set; }

	public string FROMUser { get; set; }

	public int msgdToUserId { get; set; }

	public string ToUser { get; set; }

	public string ToOtherUser { get; set; }

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

	public string msgdReadDate { get; set; }

	public string msgdReadTime { get; set; }

	public DateTime? msgdReadDateTime { get; set; }

	public string ReadDateTime { get; set; }

	public int? msgdPriorityId { get; set; }

	public string InternalMessagePriority { get; set; }

	public bool? msgdIsDraft { get; set; }

	public bool? msgdIsDeleted { get; set; }

	public string msgdAttachFile { get; set; }

	public int? msgdAttachRecId { get; set; }

	public string msgdAttachRecDesc { get; set; }

	public int? msgdAttachRecIdI { get; set; }

	public string msgdAttachRecDescI { get; set; }

	public int? msgdAttachRecTypeId { get; set; }

	public long? DocNumber { get; set; }

	public int? OprID { get; set; }

	public int? CompanyID { get; set; }

	public int? ProjectID { get; set; }

	public int? msgdGroupId { get; set; }

	public string InternalMessageGroup { get; set; }

	public int UserId { get; set; }

	public short Year1 { get; set; }

	public short Month1 { get; set; }

	public DateTime RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	public bool? msgActiveInCycle { get; set; }

	public int? msgLastGroupId { get; set; }

	public int? msgIsFinalised { get; set; }

	public string msgdExtraData { get; set; }

	public int? msgCId { get; set; }

	public string CenterName { get; set; }

	public string CenterCode { get; set; }
}
