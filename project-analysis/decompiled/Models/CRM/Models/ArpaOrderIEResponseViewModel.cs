using System.Collections.Generic;

namespace CRM.Models;

public class ArpaOrderIEResponseViewModel
{
	public List<ArpaOrderIEInfoResponseViewModel> data { get; set; }

	public string error { get; set; }

	public bool? status { get; set; }
}
