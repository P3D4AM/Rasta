using System;

namespace Mobile.Models;

public class SmsMeliPayamakGetMessagesDataResultViewModel
{
	public long MsgID { get; set; }

	public string Body { get; set; }

	public DateTime SendDate { get; set; }

	public string Receiver { get; set; }

	public string Sender { get; set; }
}
