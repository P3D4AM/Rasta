using System;

namespace Mobile.Models;

public class HRMMobspSelectRequestHistory_Result
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

	public string msgBody { get; set; }

	public int? msgdFromUserId { get; set; }

	public int? msgdToUserId { get; set; }

	public string msgdExtraData { get; set; }

	public int? AllPage { get; set; }
}
