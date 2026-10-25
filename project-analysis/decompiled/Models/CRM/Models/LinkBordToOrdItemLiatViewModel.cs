using System.Collections.Generic;

namespace CRM.Models;

public class LinkBordToOrdItemLiatViewModel
{
	public List<WSspSelectBuyOrderItemsWithOrdItemQuantity_Result> BordItems { get; set; }

	public List<WSspSelectOrderItemsWithBordItemQuantity_Result> OrdItems { get; set; }
}
