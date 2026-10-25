using System;

namespace CRM.Models;

public class WSspSelectCompanyOrderForDistributePayment_Result
{
	public string ordDate { get; set; }

	public DateTime? ordDateTime { get; set; }

	public long ordNumber { get; set; }

	public decimal? ordTotalAmount { get; set; }

	public decimal? sumOrdPayAmount { get; set; }

	public decimal? RemainOrdAmount { get; set; }

	public string OrderOpr { get; set; }

	public string OrderStatus { get; set; }

	public int? ordStatusId { get; set; }

	public int? OrderOprID { get; set; }

	public int OrderID { get; set; }
}
