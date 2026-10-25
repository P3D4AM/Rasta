namespace CRM.Models;

public class PPanelGetStatusDataResponseViewModel
{
	public string recipient { get; set; }

	public string message { get; set; }

	public bool? is_readable { get; set; }

	public string msg_parts { get; set; }

	public string message_status { get; set; }
}
