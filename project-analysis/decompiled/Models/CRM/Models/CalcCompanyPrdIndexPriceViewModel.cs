using System;

namespace CRM.Models;

public class CalcCompanyPrdIndexPriceViewModel
{
	public int? ID { get; set; }

	public decimal? TotalAmount { get; set; }

	public DateTime? OrdDate { get; set; }

	public string OrdDateStr { get; set; }

	public string Formula { get; set; }
}
