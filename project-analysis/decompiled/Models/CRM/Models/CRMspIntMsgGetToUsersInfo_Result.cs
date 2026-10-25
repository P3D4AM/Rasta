using System;

namespace CRM.Models;

public class CRMspIntMsgGetToUsersInfo_Result
{
	public int msgdToUserId { get; set; }

	public string ToUser { get; set; }

	public string msgdReceiveDate { get; set; }

	public string msgdReceiveTime { get; set; }

	public DateTime? msgdReceiveDateTime { get; set; }

	public string ReceiveDateTime { get; set; }

	public string msgdReadDate { get; set; }

	public DateTime? msgdReadDateTime { get; set; }

	public string msgdReadTime { get; set; }

	public string ReadDateTime { get; set; }
}
