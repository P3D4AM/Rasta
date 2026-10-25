using System.Collections.Generic;

namespace CRM.Models;

public class ArpaWarehouseResponseViewModel
{
	public List<ArpaWarehouseInfoViewModel> data { get; set; }

	public string error { get; set; }
}
