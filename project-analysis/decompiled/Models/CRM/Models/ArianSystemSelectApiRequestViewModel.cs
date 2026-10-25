using System.Collections.Generic;

namespace CRM.Models;

public class ArianSystemSelectApiRequestViewModel
{
	public List<ArianSystemSelectApiRequestParamViewModel> Params { get; set; }

	public string id { get; set; }
}
