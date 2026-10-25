using System.Collections.Generic;

namespace Mobile.Models;

public class IPPanelGetStatusResponseViewModel
{
	public List<PPanelGetStatusDataResponseViewModel> data { get; set; }

	public IPPanelMetaViewModel meta { get; set; }
}
