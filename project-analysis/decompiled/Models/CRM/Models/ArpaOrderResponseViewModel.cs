using System.Collections.Generic;

namespace CRM.Models;

public class ArpaOrderResponseViewModel
{
	public List<ArpaOrderInfoViewModel> data { get; set; }

	public string error { get; set; }
}
