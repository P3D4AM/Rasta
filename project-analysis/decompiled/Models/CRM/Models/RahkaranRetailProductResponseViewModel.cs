using System.Collections.Generic;

namespace CRM.Models;

public class RahkaranRetailProductResponseViewModel
{
	public List<RahkaranRetailProductInfoViewModel> result { get; set; }

	public RahkaranRetailMetaDataViewModel metadata { get; set; }
}
