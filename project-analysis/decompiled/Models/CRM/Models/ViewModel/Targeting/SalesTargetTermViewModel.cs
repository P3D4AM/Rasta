using System.Collections.Generic;

namespace CRM.Models.ViewModel.Targeting;

public class SalesTargetTermViewModel
{
	public string Key { get; set; }

	public List<SalesTargetTermItemViewModel> Items { get; set; }
}
