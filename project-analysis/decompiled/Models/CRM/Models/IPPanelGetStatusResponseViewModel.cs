using System.Collections.Generic;

namespace CRM.Models;

public class IPPanelGetStatusResponseViewModel
{
	public List<PPanelGetStatusDataResponseViewModel> data { get; set; }

	public IPPanelMetaViewModel meta { get; set; }
}
