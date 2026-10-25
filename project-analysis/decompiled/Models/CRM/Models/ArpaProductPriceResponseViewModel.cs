using System.Collections.Generic;

namespace CRM.Models;

public class ArpaProductPriceResponseViewModel
{
	public List<ArpaProductPriceInfoViewModel> data { get; set; }

	public string error { get; set; }
}
