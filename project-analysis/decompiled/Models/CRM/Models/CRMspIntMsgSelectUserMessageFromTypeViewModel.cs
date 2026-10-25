using System;
using System.ComponentModel.DataAnnotations;
using CRM.Resources;

namespace CRM.Models;

public class CRMspIntMsgSelectUserMessageFromTypeViewModel
{
	[Key]
	[Display(ResourceType = typeof(Labels), Name = "InternalMessageID")]
	public int InternalMessageID { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "msgSubject")]
	public string msgSubject { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "msgBody")]
	public string msgBody { get; set; }

	public int? msgdTypeId { get; set; }

	public string MessageType { get; set; }

	public int? msgdOldTypeId { get; set; }

	public int? InternalMessageDetailID { get; set; }

	public int? msgdFromUserId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "FromUser")]
	public string FromUser { get; set; }

	public int? msgdToUserId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ToUser")]
	public string ToUser { get; set; }

	public string OtherUser { get; set; }

	public string ToAndOtherUser { get; set; }

	public string msgdSendDate { get; set; }

	public string msgdSendTime { get; set; }

	public DateTime? msgdSendDateTime { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "SendDateTime")]
	public string SendDateTime { get; set; }

	public string msgdReceiveDate { get; set; }

	public string msgdReceiveTime { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "msgdReceiveDateTime")]
	public DateTime? msgdReceiveDateTime { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "msgdReceiveDateTime")]
	public string ReceiveDateTime { get; set; }

	public bool? msgdIsRead { get; set; }

	public int? msgdPriorityId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "InternalMessagePriority")]
	public string InternalMessagePriority { get; set; }

	public int? msgdGroupId { get; set; }

	public string InternalMessageGroup { get; set; }

	public int UserId { get; set; }

	public int? msgMasterId { get; set; }

	public int? msgIsFinalised { get; set; }

	public int? msgLastGroupId { get; set; }

	public bool? msgActiveInCycle { get; set; }

	public DateTime? msgdReadDateTime { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "SendDateTime")]
	public string ReadDateTime { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "InternalMessageCompanyName")]
	public string CompanyName { get; set; }
}
