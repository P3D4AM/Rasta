using System.Collections.Generic;

namespace CRM.Models.ViewModel.Targeting;

public class SalesTargetDistributionViewModel
{
	public string Key { get; set; }

	public List<SalesTargetDistributionItemViewModel> Items { get; set; }
}
