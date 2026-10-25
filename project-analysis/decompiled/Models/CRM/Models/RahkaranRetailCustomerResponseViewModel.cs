using System.Collections.Generic;

namespace CRM.Models;

public class RahkaranRetailCustomerResponseViewModel
{
	public List<RahkaranRetailCustomerInfoViewModel> result { get; set; }

	public RahkaranRetailMetaDataViewModel metadata { get; set; }
}
