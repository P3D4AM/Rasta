using System;

namespace CRM.Models;

public class WSspRpt_HourlySaleInfo_Result
{
	public int OrderID { get; set; }

	public long ordNumber { get; set; }

	public int? OprId { get; set; }

	public string OprName { get; set; }

	public DateTime? ordDateTime { get; set; }

	public string ordDate { get; set; }

	public decimal? ordTotalAmount { get; set; }

	public int? ordReferUserId { get; set; }

	public string ordReferUser { get; set; }

	public long? RowNumber { get; set; }

	public int? AllPage { get; set; }
}
