using System.Collections.Generic;

namespace Mobile.Models;

public class HrmDropDownItem
{
	public int Id { get; set; }

	public int ParentId { get; set; }

	public string Title { get; set; }

	public Dictionary<string, string> ExtraField { get; set; }
}
