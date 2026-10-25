using System.Collections.Generic;

namespace CRM.Models;

public class HamrahanDeliverySiteInfoViewModel
{
	public long? recNo { get; set; }

	public string siteCode { get; set; }

	public string siteName { get; set; }

	public List<HamrahanLinkInfoViewModel> links { get; set; }
}
