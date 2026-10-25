namespace CRM.Models;

public class IPPanelGetMessageReqViewModel
{
	public long page { get; set; }

	public long per_page { get; set; }

	public IPPanelGetMessageFromIdReqViewModel filters { get; set; }
}
