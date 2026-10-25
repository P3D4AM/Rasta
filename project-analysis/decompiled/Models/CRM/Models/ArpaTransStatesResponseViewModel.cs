using System.Collections.Generic;

namespace CRM.Models;

public class ArpaTransStatesResponseViewModel
{
	public List<ArpaTransStatesInfoViewModel> data { get; set; }

	public string error { get; set; }
}
