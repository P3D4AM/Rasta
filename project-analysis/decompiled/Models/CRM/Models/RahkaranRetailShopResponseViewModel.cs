using System.Collections.Generic;

namespace CRM.Models;

public class RahkaranRetailShopResponseViewModel
{
	public List<RahkaranRetailShopInfoViewModel> result { get; set; }

	public RahkaranRetailMetaDataViewModel metadata { get; set; }
}
