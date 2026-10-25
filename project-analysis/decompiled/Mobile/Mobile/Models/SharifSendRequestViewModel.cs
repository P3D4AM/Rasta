using System.Collections.Generic;

namespace Mobile.Models;

public class SharifSendRequestViewModel
{
	public List<string> Mobile { get; set; }

	public string Message { get; set; }

	public string DateTime { get; set; }

	public int SystemId { get; set; }

	public string Password { get; set; }
}
