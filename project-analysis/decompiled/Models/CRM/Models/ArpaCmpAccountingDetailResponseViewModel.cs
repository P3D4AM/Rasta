using System.Collections.Generic;

namespace CRM.Models;

public class ArpaCmpAccountingDetailResponseViewModel
{
	public List<ArpaCmpAccountingDetailInfoViewModel> data { get; set; }

	public string error { get; set; }
}
