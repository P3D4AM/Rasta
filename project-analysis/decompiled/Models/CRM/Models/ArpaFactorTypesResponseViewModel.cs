using System.Collections.Generic;

namespace CRM.Models;

public class ArpaFactorTypesResponseViewModel
{
	public List<ArpaFactorTypesInfoViewModel> data { get; set; }

	public string error { get; set; }
}
