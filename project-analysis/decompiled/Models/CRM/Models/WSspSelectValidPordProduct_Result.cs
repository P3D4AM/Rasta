using System;

namespace CRM.Models;

public class WSspSelectValidPordProduct_Result
{
	public long? RowNumber { get; set; }

	public int? PreOrderId { get; set; }

	public int? PreOrderItemID { get; set; }

	public long? pordNumber { get; set; }

	public long? pordNumberRevision { get; set; }

	public string pordDate { get; set; }

	public DateTime? pordDateTime { get; set; }

	public int? pordStatusId { get; set; }

	public string pordExpireDate { get; set; }

	public DateTime? pordExpireDateTime { get; set; }

	public int? pordIPrdId { get; set; }

	public string PrdName { get; set; }

	public string PrdCode { get; set; }

	public double? pordIQuantity { get; set; }

	public double? pordIFCR { get; set; }

	public double? pordIFCRI { get; set; }

	public int? pordIWHId { get; set; }

	public string WrhsName { get; set; }

	public string WrhsCode { get; set; }

	public string pordITracing { get; set; }

	public double pordOrdQuantity { get; set; }

	public double pordDocQuantity { get; set; }

	public double ordDocQuantity { get; set; }

	public double nopord_ordDocQuantity { get; set; }

	public double RemindQty { get; set; }
}
