using System.Collections.Generic;

namespace CRM.Models;

public class ArpaSettlementTypeResponseViewModel
{
	public List<ArpaSettlementTypeInfoViewModel> data { get; set; }

	public string error { get; set; }
}
