using System;

namespace Mobile.Models;

public class MobspIntMsgGetByTypeAndAttachRecId_Result
{
	public int InternalMessageDetailID { get; set; }

	public int? msgdInternalMessageId { get; set; }

	public int msgdTypeId { get; set; }

	public int? msgdAttachRecId { get; set; }

	public string FromUser { get; set; }

	public string ToUser { get; set; }

	public DateTime msgdSendDateTime { get; set; }

	public bool? msgdIsRead { get; set; }

	public string msgSubject { get; set; }
}
