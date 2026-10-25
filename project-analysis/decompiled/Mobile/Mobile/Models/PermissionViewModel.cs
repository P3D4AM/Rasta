using System.Collections.Generic;

namespace Mobile.Models;

public class PermissionViewModel
{
	public string FormName { get; set; }

	public Dictionary<string, bool> ActionName { get; set; }
}
