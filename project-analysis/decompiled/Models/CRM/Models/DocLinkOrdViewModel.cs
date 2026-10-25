using System.Collections.Generic;

namespace CRM.Models;

public class DocLinkOrdViewModel
{
	public bool IsFind { get; set; }

	public string Message { get; set; }

	public WSspSelectOrderById_Result OrderInfo { get; set; }

	public List<WSspSelectOrderItems_Result> OrderItems { get; set; }

	public List<WSspReturnDocForSaleOrder_Result> Docs { get; set; }

	public List<WSspReturnDocItemsForSaleOrderItems_Result> DocItems { get; set; }
}
