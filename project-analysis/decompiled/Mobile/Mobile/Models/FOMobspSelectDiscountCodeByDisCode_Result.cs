using System;

namespace Mobile.Models;

public class FOMobspSelectDiscountCodeByDisCode_Result
{
	public int DiscountCodeId { get; set; }

	public string DisTitle { get; set; }

	public string DisCode { get; set; }

	public decimal? DisAmount { get; set; }

	public decimal? DisAmountPercent { get; set; }

	public DateTime DisExpDate { get; set; }

	public string DisExpDatePersian { get; set; }

	public int? DisCmpId { get; set; }

	public int? DisPrdId { get; set; }

	public int DisUseCnt { get; set; }

	public int? UsedCount { get; set; }

	public string DisCmpName { get; set; }

	public string DisPrdName { get; set; }

	public double? ScoreRate { get; set; }
}
