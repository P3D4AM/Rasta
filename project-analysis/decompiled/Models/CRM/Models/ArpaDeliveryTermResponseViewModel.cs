using System.Collections.Generic;

namespace CRM.Models;

public class ArpaDeliveryTermResponseViewModel
{
	public List<ArpaDeliveryTermInfoViewModel> data { get; set; }

	public string error { get; set; }
}
