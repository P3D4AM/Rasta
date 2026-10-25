using System.Collections.Generic;

namespace Mobile.Models;

public class IssueOrderFromPreOrderResultViewModel
{
	public string Message { get; set; }

	public int InsertedOrderID { get; set; }

	public long InsertedOrderNumber { get; set; }

	public List<MobspReturnOrderFromPreOrder_Result> PordOrders { get; set; }

	public List<MobspSelectPreOrderItems_Result> PreOrderItems { get; set; }

	public int InsertedOrderProjectID { get; set; }
}
