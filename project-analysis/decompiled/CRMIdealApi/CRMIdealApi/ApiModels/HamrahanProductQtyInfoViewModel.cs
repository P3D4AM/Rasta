using System.Collections.Generic;

namespace CRMIdealApi.ApiModels;

public class HamrahanProductQtyInfoViewModel
{
	public int? rnPhysical { get; set; }

	public string namePhysical { get; set; }

	public int? rnObject { get; set; }

	public int? rnScruple { get; set; }

	public string nameScruple { get; set; }

	public string codeObject { get; set; }

	public string nameObject { get; set; }

	public double? cellarValue { get; set; }

	public decimal? rsvValue { get; set; }

	public decimal? rate { get; set; }

	public List<HamrahanLinkInfoViewModel> links { get; set; }
}
