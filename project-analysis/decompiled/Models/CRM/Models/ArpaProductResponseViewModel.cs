using System.Collections.Generic;

namespace CRM.Models;

public class ArpaProductResponseViewModel
{
	public List<ArpaProductInfoViewModel> data { get; set; }

	public string error { get; set; }
}
