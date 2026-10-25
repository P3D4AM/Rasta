using System.Collections.Generic;

namespace CRMIdealApi.ApiModels;

public class ArpaProductQuantityResponseViewModel
{
	public List<ArpaProductQuantityInfoViewModel> data { get; set; }

	public string error { get; set; }
}
