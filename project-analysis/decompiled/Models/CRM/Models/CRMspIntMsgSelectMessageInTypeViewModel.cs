using System;
using System.ComponentModel.DataAnnotations;
using CRM.Resources;

namespace CRM.Models;

public class CRMspIntMsgSelectMessageInTypeViewModel
{
	[Key]
	public int InternalMessageID { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "msgSubject")]
	public string msgSubject { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "msgBody")]
	public string msgBody { get; set; }

	public int InternalMessageDetailID { get; set; }

	public int msgdTypeId { get; set; }

	public string MessageType { get; set; }

	public int? msgMasterId { get; set; }

	public int msgdFromUserId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "msgdFromUserId")]
	public string FROMUser { get; set; }

	public int msgdToUserId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "msgdToUserId")]
	public string ToUser { get; set; }

	public string ToOtherUser { get; set; }

	public string ToAndOtherUser { get; set; }

	public string msgdSendDate { get; set; }

	public string msgdSendTime { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "msgdSendDateTime")]
	public DateTime msgdSendDateTime { get; set; }

	public string SendDateTime { get; set; }

	public string msgdReceiveDate { get; set; }

	public string msgdReceiveTime { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "msgdReceiveDateTime")]
	public DateTime? msgdReceiveDateTime { get; set; }

	public string ReceiveDateTime { get; set; }

	public bool? msgdIsRead { get; set; }

	public string msgdReadDate { get; set; }

	public string msgdReadTime { get; set; }

	public DateTime? msgdReadDateTime { get; set; }

	public string ReadDateTime { get; set; }

	public int? msgdPriorityId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "InternalMessagePriority")]
	public string InternalMessagePriority { get; set; }

	public bool? msgdIsDraft { get; set; }

	public bool? msgdIsDeleted { get; set; }

	public string msgdAttachFile { get; set; }

	public int? msgdAttachRecId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "msgdAttachRecDesc")]
	public string msgdAttachRecDesc { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "DocNumber")]
	public long? DocNumber { get; set; }

	public int? OprID { get; set; }

	public int? CompanyID { get; set; }

	public int? ProjectID { get; set; }

	public int? msgdGroupId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "InternalMessageGroup")]
	public string InternalMessageGroup { get; set; }

	public int UserId { get; set; }

	public short Year1 { get; set; }

	public short Month1 { get; set; }

	public DateTime RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	public bool? msgActiveInCycle { get; set; }

	public int? msgLastGroupId { get; set; }

	public int? msgIsFinalised { get; set; }

	public int? msgdAttachRecIdI { get; set; }

	public string msgdAttachRecDescI { get; set; }

	public int? msgdAttachRecTypeId { get; set; }

	public string msgdExtraData { get; set; }
}
