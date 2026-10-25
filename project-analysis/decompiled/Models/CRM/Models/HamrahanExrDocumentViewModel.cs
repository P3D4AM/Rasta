using System.Collections.Generic;

namespace CRM.Models;

public class HamrahanExrDocumentViewModel
{
	public int company { get; set; }

	public int? indexDocument { get; set; }

	public int? indexKind { get; set; }

	public int? indexKind1 { get; set; }

	public int? rnCashier { get; set; }

	public int userID { get; set; }

	public string documentDate { get; set; }

	public List<HamrahanExrDocumentDetailViewModel> details { get; set; }
}
