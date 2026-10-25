using System;

namespace Mobile.Models;

public class MobHrmspInternalMessageLoadShortUserMessageByTypes_Result
{
	public long? RowNumber { get; set; }

	public int InternalMessageID { get; set; }

	public string msgSubject { get; set; }

	public int? msgdTypeId { get; set; }

	public string MessageType { get; set; }

	public int? InternalMessageDetailID { get; set; }

	public string FromUser { get; set; }

	public DateTime? msgdSendDateTime { get; set; }

	public DateTime? msgdReceiveDateTime { get; set; }

	public bool? msgdIsRead { get; set; }

	public string InternalMessagePriority { get; set; }

	public string CompanyName { get; set; }

	public string msgBody { get; set; }

	public int? CompanyID { get; set; }

	public int? ProjectID { get; set; }

	public bool? msgProjectIsTicket { get; set; }

	public string msgProject { get; set; }

	public int? msgAttachFileCount { get; set; }

	public int? msgdAttachRecTypeId { get; set; }

	public int? msgdAttachRecId { get; set; }

	public int? msgdPriorityId { get; set; }

	public int? msgdFromUserId { get; set; }

	public int? msgdToUserId { get; set; }
}
