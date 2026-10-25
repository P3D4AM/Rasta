using System.Collections.Generic;

namespace CRM.Models;

public class RahkaranRetailShopInfoViewModel
{
	public long? id { get; set; }

	public string name { get; set; }

	public string code { get; set; }

	public List<RahkaranRetailStoresInfoViewModel> stores { get; set; }
}
