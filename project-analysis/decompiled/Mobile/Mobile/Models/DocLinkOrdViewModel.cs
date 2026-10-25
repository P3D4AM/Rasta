using System.Collections.Generic;

namespace Mobile.Models;

public class DocLinkOrdViewModel
{
	public bool IsFind { get; set; }

	public string Message { get; set; }

	public MobspSelectOrderById_Result OrderInfo { get; set; }

	public List<MobspSelectOrderItems_Result> OrderItems { get; set; }

	public List<MobspReturnDocForSaleOrder_Result> Docs { get; set; }

	public List<MobspReturnDocItemsForSaleOrderItems_Result> DocItems { get; set; }
}
