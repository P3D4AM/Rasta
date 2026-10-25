using System.Collections.Generic;

namespace CRM.Models;

public class ArpaProductGroupResponseViewModel
{
	public List<ArpaProductGroupInfoViewModel> data { get; set; }

	public string error { get; set; }
}
