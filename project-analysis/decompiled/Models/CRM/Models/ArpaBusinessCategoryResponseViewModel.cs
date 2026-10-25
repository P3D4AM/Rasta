using System.Collections.Generic;

namespace CRM.Models;

public class ArpaBusinessCategoryResponseViewModel
{
	public List<ArpaBusinessCategoryInfoViewModel> data { get; set; }

	public string error { get; set; }
}
