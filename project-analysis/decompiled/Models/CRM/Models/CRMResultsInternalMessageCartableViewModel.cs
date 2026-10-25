using System;
using System.ComponentModel.DataAnnotations;
using CRM.Resources;

namespace CRM.Models;

public class CRMResultsInternalMessageCartableViewModel
{
	[Key]
	public int InternalMessageID { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "msgSubject")]
	public string msgSubject { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "msgBody")]
	public string msgBody { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "msgdTypeId")]
	public int? msgdTypeId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "MessageType")]
	public string MessageType { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "InternalMessageDetailID")]
	public int? InternalMessageDetailID { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "msgdFromUserId")]
	public int? msgdFromUserId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "FromUser")]
	public string FromUser { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "msgdToUserId")]
	public int? msgdToUserId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ToUser")]
	public string ToUser { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "OtherUser")]
	public string OtherUser { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ToAndOtherUser")]
	public string ToAndOtherUser { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "msgdSendDate")]
	public string msgdSendDate { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "msgdSendTime")]
	public string msgdSendTime { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "msgdSendDateTime")]
	public DateTime? msgdSendDateTime { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "SendDateTime")]
	public string SendDateTime { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "msgdReceiveDate")]
	public string msgdReceiveDate { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "msgdReceiveTime")]
	public string msgdReceiveTime { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "msgdReceiveDateTime")]
	public DateTime? msgdReceiveDateTime { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ReceiveDateTime")]
	public string ReceiveDateTime { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "msgdIsRead")]
	public bool? msgdIsRead { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "msgdPriorityId")]
	public int? msgdPriorityId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "InternalMessagePriority")]
	public string InternalMessagePriority { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "msgdGroupId")]
	public int? msgdGroupId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "InternalMessageGroup")]
	public string InternalMessageGroup { get; set; }

	public int UserId { get; set; }
}
