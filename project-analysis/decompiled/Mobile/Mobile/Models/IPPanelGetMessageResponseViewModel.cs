using System.Collections.Generic;

namespace Mobile.Models;

public class IPPanelGetMessageResponseViewModel
{
	public List<IPPanelGetMessageViewModel> data { get; set; }

	public IPPanelMetaViewModel meta { get; set; }
}
