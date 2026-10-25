using System.Collections.Generic;

namespace CRM.Models;

public class HamrahanDetailDocumentInfoViewModel
{
	public int? dRecNo { get; set; }

	public int? company { get; set; }

	public int? refRecNo { get; set; }

	public List<HamrahanLinkInfoViewModel> links { get; set; }
}
