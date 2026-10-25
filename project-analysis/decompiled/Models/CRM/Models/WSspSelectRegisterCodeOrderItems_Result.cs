using System;

namespace CRM.Models;

public class WSspSelectRegisterCodeOrderItems_Result
{
	public int OrderId { get; set; }

	public string ordDate { get; set; }

	public DateTime? ordDateTime { get; set; }

	public long ordNumber { get; set; }

	public int? ordStatusId { get; set; }

	public int OrderItemID { get; set; }

	public int ordIPrdId { get; set; }

	public string PrdName { get; set; }

	public string PrdModuleName { get; set; }

	public decimal RemainOrdAmount { get; set; }

	public string ordPayDocDate { get; set; }

	public DateTime? ordPayDocDateTime { get; set; }

	public double? ordIQuantity { get; set; }

	public double? ordIFCR { get; set; }

	public double? ordIFCRI { get; set; }

	public double? ordIQuantityTotal { get; set; }
}
