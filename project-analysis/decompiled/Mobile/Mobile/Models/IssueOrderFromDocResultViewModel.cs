using System.Collections.Generic;

namespace Mobile.Models;

public class IssueOrderFromDocResultViewModel
{
	public string Message { get; set; }

	public List<MobspReturnOrderFromDoc_Result> OrderList { get; set; }

	public List<MobspSelectDocItems_Result> DocItemList { get; set; }
}
