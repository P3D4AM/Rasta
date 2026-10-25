namespace Mobile.Models;

public class IPPanelSendSmsWebServiceViewModel
{
	public string sending_type { get; set; }

	public string from_number { get; set; }

	public string message { get; set; }

	public IPPanelSendSmsWebServiceInfoViewModel @params { get; set; }
}
