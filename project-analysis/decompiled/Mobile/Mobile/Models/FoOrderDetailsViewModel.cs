using System.Collections.Generic;

namespace Mobile.Models;

public class FoOrderDetailsViewModel
{
	public FOMobspSelectOrderWithId_Result Order { get; set; }

	public List<FOMobspSelectOrderItems_Result> OrderItems { get; set; }

	public List<FOMobspSelectOrderPayments_Result> OrderPayments { get; set; }
}
