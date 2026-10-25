using System.Collections.Generic;

namespace Mobile.Models;

public class DbObjectFieldViewModel
{
	public string ObjectName { get; set; }

	public Dictionary<string, bool> FieldName { get; set; }
}
