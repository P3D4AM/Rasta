using System.Collections.Generic;

namespace Mobile.Models;

public class FoPreOrderDetailsViewModel
{
	public SHPMobspSelectPreOrderWithId_Result PreOrder { get; set; }

	public List<SHPMobspSelectPreOrderItems_Result> PreOrderItems { get; set; }

	public List<SHPMobspSelectPreOrderPayments_Result> PreOrderPayments { get; set; }
}
