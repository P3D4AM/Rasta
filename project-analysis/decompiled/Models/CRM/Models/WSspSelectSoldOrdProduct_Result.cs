using System;

namespace CRM.Models;

public class WSspSelectSoldOrdProduct_Result
{
	public long? RowNumber { get; set; }

	public int? OrderId { get; set; }

	public int? OrderOprId { get; set; }

	public string OrderOpr { get; set; }

	public int? OrderItemID { get; set; }

	public long? ordNumber { get; set; }

	public string ordDate { get; set; }

	public DateTime? ordDateTime { get; set; }

	public int? ordStatusId { get; set; }

	public int? ordIPrdId { get; set; }

	public string PrdName { get; set; }

	public string PrdCode { get; set; }

	public double? ordIQuantity { get; set; }

	public double? ordIFCR { get; set; }

	public double? ordIFCRI { get; set; }

	public int? ordIWHId { get; set; }

	public string WrhsName { get; set; }

	public string WrhsCode { get; set; }

	public string ordITracing { get; set; }

	public string DocItemIds { get; set; }

	public double? Returned_ordIQuantity { get; set; }

	public double? ordIDocQuantity { get; set; }

	public double RemindQty { get; set; }
}
