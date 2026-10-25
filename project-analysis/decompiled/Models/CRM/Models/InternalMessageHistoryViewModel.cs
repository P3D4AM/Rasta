using System;

namespace CRM.Models;

public class InternalMessageHistoryViewModel
{
	public int InternalMessageDetailID { get; set; }

	public int msgdTypeId { get; set; }

	public string msgdType { get; set; }

	public int msgdFromUserId { get; set; }

	public string msgdFromUser { get; set; }

	public int msgdToUserId { get; set; }

	public string msgdToUser { get; set; }

	public string msgdSendDate { get; set; }

	public DateTime msgdSendDateTime { get; set; }

	public string msgdReceiveDate { get; set; }

	public DateTime? msgdReceiveDateTime { get; set; }

	public string msgdReadDate { get; set; }

	public DateTime? msgdReadDateTime { get; set; }

	public bool? msgdIsRead { get; set; }
}
