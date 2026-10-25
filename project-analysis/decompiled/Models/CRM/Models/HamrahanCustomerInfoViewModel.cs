using System.Collections.Generic;

namespace CRM.Models;

public class HamrahanCustomerInfoViewModel
{
	public long? rnCustomer { get; set; }

	public int? refFormal { get; set; }

	public string customerCode { get; set; }

	public string codeFormal { get; set; }

	public string nameFormal { get; set; }

	public long? refGroup { get; set; }

	public string groupName { get; set; }

	public List<HamrahanLinkInfoViewModel> links { get; set; }
}
