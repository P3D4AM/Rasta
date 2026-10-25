using System.Collections.Generic;

namespace CRM.Models;

public class ArpaProvinceResponseViewModel
{
	public List<ArpaProvinceInfoViewModel> data { get; set; }

	public string error { get; set; }
}
