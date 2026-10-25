namespace Mobile.Models;

public class IPPanelMetaViewModel
{
	public bool? status { get; set; }

	public string message { get; set; }

	public string message_code { get; set; }

	public IPPanelMetaErrorViewModel errors { get; set; }
}
