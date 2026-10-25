using System.Collections.Generic;

namespace CRM.Models;

public class HamrahanProductInfoByGroupViewModel
{
	public int? recNo { get; set; }

	public string nameObject { get; set; }

	public string codeObject { get; set; }

	public string nameScruple { get; set; }

	public List<HamrahanLinkInfoViewModel> links { get; set; }
}
