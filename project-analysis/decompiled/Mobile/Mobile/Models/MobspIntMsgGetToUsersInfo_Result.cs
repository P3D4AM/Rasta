using System;

namespace Mobile.Models;

public class MobspIntMsgGetToUsersInfo_Result
{
	public int msgdToUserId { get; set; }

	public string ToUser { get; set; }

	public string msgdReceiveDate { get; set; }

	public string msgdReceiveTime { get; set; }

	public DateTime? msgdReceiveDateTime { get; set; }

	public string msgdReadDate { get; set; }

	public DateTime? msgdReadDateTime { get; set; }

	public string msgdReadTime { get; set; }
}
