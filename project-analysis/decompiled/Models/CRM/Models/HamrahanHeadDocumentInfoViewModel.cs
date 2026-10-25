using System.Collections.Generic;

namespace CRM.Models;

public class HamrahanHeadDocumentInfoViewModel
{
	public int? company { get; set; }

	public string fiscalYear { get; set; }

	public int? indexDocument { get; set; }

	public string documentDate { get; set; }

	public List<HamrahanLinkInfoViewModel> links { get; set; }
}
