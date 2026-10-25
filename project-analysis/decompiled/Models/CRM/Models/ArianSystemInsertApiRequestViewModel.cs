using System.Collections.Generic;

namespace CRM.Models;

public class ArianSystemInsertApiRequestViewModel
{
	public List<ArianSystemInsertApiRequestParamViewModel> Params { get; set; }

	public string id { get; set; }
}
