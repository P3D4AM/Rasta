using System;

namespace Mobile.Models;

public class FOMobspSelectDiscountCodeByCmpId_Result
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

	public int? DisUseCntPerCmp { get; set; }

	public int? DisSingleCmpScoreId { get; set; }

	public bool? DisCanChangeToScore { get; set; }

	public int? DisCodeRuleId { get; set; }

	public string DisCodeRule { get; set; }

	public DateTime FirstRegisterDate { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public bool? CntIsExpired { get; set; }

	public bool? DateIsExpired { get; set; }

	public long? RowNumber { get; set; }

	public int? ALLPage { get; set; }
}
