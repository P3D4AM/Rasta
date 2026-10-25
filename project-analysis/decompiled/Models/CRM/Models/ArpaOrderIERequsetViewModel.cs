using System.Collections.Generic;

namespace CRM.Models;

public class ArpaOrderIERequsetViewModel
{
	public ArpaOrderIEViewModel data { get; set; }

	public List<ArpaOrderItemsIEViewModel> Items { get; set; }

	public List<ArpaOrderIRoundEViewModel> AddSub { get; set; }
}
