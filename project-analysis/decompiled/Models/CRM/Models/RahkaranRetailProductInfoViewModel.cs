using System.Collections.Generic;

namespace CRM.Models;

public class RahkaranRetailProductInfoViewModel
{
	public long? id { get; set; }

	public string name { get; set; }

	public long? partId { get; set; }

	public string code { get; set; }

	public string specification { get; set; }

	public List<RahkaranRetailProductUnitInfoViewModel> units { get; set; }
}
