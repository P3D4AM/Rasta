using System;

namespace CRM.Models;

public class WSspReturnDocItemsForSaleOrderItems_Result
{
	public int DocID { get; set; }

	public int OprId { get; set; }

	public string OprName { get; set; }

	public int DocNumber { get; set; }

	public string DocDate { get; set; }

	public DateTime? DocDateTime { get; set; }

	public int DocItemID { get; set; }

	public int? OrderItemId { get; set; }

	public int? OprType { get; set; }
}
