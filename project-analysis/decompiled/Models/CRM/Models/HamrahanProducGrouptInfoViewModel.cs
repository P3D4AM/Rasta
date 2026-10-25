using System.Collections.Generic;

namespace CRM.Models;

public class HamrahanProducGrouptInfoViewModel
{
	public int? recNo { get; set; }

	public int? rnChild { get; set; }

	public string nameGroup { get; set; }

	public string codeGroup { get; set; }

	public List<HamrahanLinkInfoViewModel> links { get; set; }
}
