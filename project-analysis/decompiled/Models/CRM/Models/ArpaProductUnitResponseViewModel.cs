using System.Collections.Generic;

namespace CRM.Models;

public class ArpaProductUnitResponseViewModel
{
	public List<ArpaProductUnitInfoViewModel> data { get; set; }

	public string error { get; set; }
}
