using System.Collections.Generic;

namespace CRM.Models;

public class HamrahanExrDocumentInfoViewModel
{
	public long? recNo { get; set; }

	public int? company { get; set; }

	public string advertNo { get; set; }

	public string documentNo { get; set; }

	public List<HamrahanExrDocumentDetailsInfoViewModel> details { get; set; }

	public List<HamrahanLinkInfoViewModel> links { get; set; }
}
