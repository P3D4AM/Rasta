using System.Collections.Generic;

namespace CRM.Models;

public class ArpaProductPriceGroupResponseViewModel
{
	public List<ArpaProductPriceGroupInfoViewModel> data { get; set; }

	public string error { get; set; }
}
