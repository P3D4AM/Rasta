using System.Collections.Generic;

namespace CRM.Models;

public class HamrahanCustomerGroupInfoViewModel
{
	public long? rnGroupCustomer { get; set; }

	public string parentCode { get; set; }

	public string parentName { get; set; }

	public string groupCode { get; set; }

	public string groupName { get; set; }

	public List<HamrahanLinkInfoViewModel> links { get; set; }
}
