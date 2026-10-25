using System.Collections.Generic;

namespace CRM.Models;

public class IPPanelSendSmsPeerToPeerViewModel
{
	public string sending_type { get; set; }

	public string from_number { get; set; }

	public List<IPPanelSendSmsPeerToPeerInfoViewModel> @params { get; set; }
}
