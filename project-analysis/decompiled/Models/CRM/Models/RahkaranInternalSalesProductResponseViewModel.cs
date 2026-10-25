using System.Collections.Generic;

namespace CRM.Models;

public class RahkaranInternalSalesProductResponseViewModel
{
	public string defaultUnitRef { get; set; }

	public string id { get; set; }

	public bool? isFreeProduct { get; set; }

	public string name { get; set; }

	public string number { get; set; }

	public string partLatinName { get; set; }

	public string partNature { get; set; }

	public string partNatureTitle { get; set; }

	public string partRef { get; set; }

	public string partTechnicalSpecification { get; set; }

	public string stateTitle { get; set; }

	public List<RahkaranInternalSalesProductUnitInfoViewModel> units { get; set; }
}
