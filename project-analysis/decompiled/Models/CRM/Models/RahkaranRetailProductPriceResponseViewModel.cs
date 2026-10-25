using System.Collections.Generic;

namespace CRM.Models;

public class RahkaranRetailProductPriceResponseViewModel
{
	public List<RahkaranRetailProductPriceInfoViewModel> result { get; set; }

	public RahkaranRetailMetaDataViewModel metadata { get; set; }
}
