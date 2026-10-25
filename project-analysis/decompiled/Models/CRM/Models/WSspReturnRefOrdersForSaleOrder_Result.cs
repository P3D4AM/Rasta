using System;

namespace CRM.Models;

public class WSspReturnRefOrdersForSaleOrder_Result
{
	public int OrderID { get; set; }

	public int? OrderOprID { get; set; }

	public string OrderOpr { get; set; }

	public long ordNumber { get; set; }

	public string ordDate { get; set; }

	public DateTime? ordDateTime { get; set; }
}
