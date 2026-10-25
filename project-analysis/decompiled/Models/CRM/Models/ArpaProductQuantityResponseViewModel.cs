using System.Collections.Generic;

namespace CRM.Models;

public class ArpaProductQuantityResponseViewModel
{
	public List<ArpaProductQuantityInfoViewModel> data { get; set; }

	public string error { get; set; }
}
