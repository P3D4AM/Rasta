using System.Collections.Generic;

namespace CRM.Models;

public class HamrahanProductInfoViewModel
{
	public long? rnPhysical { get; set; }

	public string namePhysical { get; set; }

	public long? rnObject { get; set; }

	public long? rnScruple { get; set; }

	public string nameScruple { get; set; }

	public string codeObject { get; set; }

	public string nameObject { get; set; }

	public double? cellarValue { get; set; }

	public double? rate { get; set; }

	public List<HamrahanLinkInfoViewModel> links { get; set; }
}
