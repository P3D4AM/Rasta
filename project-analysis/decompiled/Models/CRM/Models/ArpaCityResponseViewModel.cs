using System.Collections.Generic;

namespace CRM.Models;

public class ArpaCityResponseViewModel
{
	public List<ArpaCityInfoViewModel> data { get; set; }

	public string error { get; set; }
}
