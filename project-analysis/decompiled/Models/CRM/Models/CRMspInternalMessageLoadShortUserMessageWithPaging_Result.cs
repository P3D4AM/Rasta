using System;

namespace CRM.Models;

public class CRMspInternalMessageLoadShortUserMessageWithPaging_Result
{
	public int? InternalMessageID { get; set; }

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

	public bool? msgActiveInCycle { get; set; }

	public int? msgdAttachRecId { get; set; }

	public string msgdAttachRecDesc { get; set; }

	public int? msgdAttachRecIdI { get; set; }

	public string msgdAttachRecDescI { get; set; }

	public string msgdExtraData { get; set; }

	public int? msgdAttachRecTypeId { get; set; }

	public int? msgCompanyId { get; set; }

	public string CompanyName { get; set; }

	public int? msgProjectId { get; set; }

	public bool? msgProjectIsTicket { get; set; }

	public string msgProject { get; set; }

	public int? msgAttachFileCount { get; set; }

	public int? msgdCId { get; set; }

	public string CenterName { get; set; }

	public string CenterCode { get; set; }
}
