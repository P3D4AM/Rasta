using System;

namespace Mobile.Models;

public class FarazSmsGetReceiveResponseViewModel
{
	public string message { get; set; }

	public string from { get; set; }

	public string to { get; set; }

	public DateTime? time { get; set; }
}
