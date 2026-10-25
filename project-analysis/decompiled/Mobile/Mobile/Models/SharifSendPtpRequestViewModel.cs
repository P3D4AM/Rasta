using System.Collections.Generic;

namespace Mobile.Models;

public class SharifSendPtpRequestViewModel
{
	public List<string> Mobile { get; set; }

	public List<string> Message { get; set; }

	public string DateTime { get; set; }

	public int SystemId { get; set; }

	public string Password { get; set; }
}
