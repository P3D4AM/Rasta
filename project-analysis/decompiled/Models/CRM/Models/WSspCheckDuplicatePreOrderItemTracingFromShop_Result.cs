using System;

namespace CRM.Models;

public class WSspCheckDuplicatePreOrderItemTracingFromShop_Result
{
	public int? PreOrderItemID { get; set; }

	public int? PreOrderId { get; set; }

	public long? pordNumber { get; set; }

	public DateTime? pordDateTime { get; set; }

	public int? pordIPrdId { get; set; }

	public string PrdName { get; set; }
}
