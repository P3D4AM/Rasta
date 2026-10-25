namespace CRM.Models;

public class IPPanelGetMessageViewModel
{
	public long? messages_inbox_id { get; set; }

	public string from { get; set; }

	public string number { get; set; }

	public string message { get; set; }

	public string type { get; set; }

	public long? time { get; set; }

	public string seen { get; set; }
}
