using System.Collections.Generic;

namespace CRM.Models;

public class ArpaBusinessResponseViewModel
{
	public List<ArpaBusinessInfoViewModel> data { get; set; }

	public string error { get; set; }
}
