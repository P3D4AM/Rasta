using System.Collections.Generic;

namespace Mobile.Models;

public class HrmPermissionViewModel
{
	public string FormName { get; set; }

	public Dictionary<string, bool> ActionName { get; set; }
}
