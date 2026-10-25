using System.Collections.Generic;

namespace CRM.Models;

public class ArpaProductAIGroupResponseViewModel
{
	public List<ArpaProductAIGroupInfoViewModel> data { get; set; }

	public string error { get; set; }
}
