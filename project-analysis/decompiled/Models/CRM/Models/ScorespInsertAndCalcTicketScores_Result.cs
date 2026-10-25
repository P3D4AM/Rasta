using System;

namespace CRM.Models;

public class ScorespInsertAndCalcTicketScores_Result
{
	public int? ScoreId { get; set; }

	public int? RuleId { get; set; }

	public int? ProjectId { get; set; }

	public string Project { get; set; }

	public DateTime? RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	public DateTime? ObjFirstRegisterDate { get; set; }

	public string ObjFirstRegisterDatePersian { get; set; }

	public string RuleTitle { get; set; }

	public bool? RuleIsCmpScore { get; set; }

	public decimal? CmpScore { get; set; }

	public int? CmpScore_CmpId { get; set; }

	public string CmpScore_Cmp { get; set; }

	public bool? RuleIsUserScore { get; set; }

	public decimal? UserScore { get; set; }

	public int? UserScore_EPId { get; set; }

	public string UserScore_EP { get; set; }

	public int? UserScore_UserId { get; set; }

	public string UserScore_User { get; set; }

	public DateTime? CalcExpireDate { get; set; }

	public string CalcExpireDatePersian { get; set; }
}
