using System.Collections.Generic;

namespace CRM.Models;

public class ArpaUserGroupResponseViewModel
{
	public List<ArpaUserGroupViewModel> data { get; set; }

	public string error { get; set; }
}
