using System.Collections.Generic;

namespace CRM.Models;

public class ArpaSaleCenterResponseViewModel
{
	public List<ArpaSaleCenterInfoViewModel> data { get; set; }

	public string error { get; set; }
}
