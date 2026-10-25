using System.Collections.Generic;

namespace CRM.Models;

public class HamrahanUserInfoViewModel
{
	public long? recNo { get; set; }

	public long? refFormal { get; set; }

	public long? rnGroupFormal { get; set; }

	public string codeFormal { get; set; }

	public string sellerName { get; set; }

	public List<HamrahanLinkInfoViewModel> links { get; set; }
}
