using System;

namespace CRM.Models;

public class WSspSelectOrdersForSalesTarget_Result
{
	public int OrderID { get; set; }

	public long ordNumber { get; set; }

	public DateTime? ordDateTime { get; set; }

	public decimal? TotalAmount { get; set; }

	public decimal EligibleAmount { get; set; }

	public string DynamicColumns { get; set; }

	public int? TotalCount { get; set; }

	public string ordDate { get; set; }

	public decimal? EligibleCount { get; set; }
}
