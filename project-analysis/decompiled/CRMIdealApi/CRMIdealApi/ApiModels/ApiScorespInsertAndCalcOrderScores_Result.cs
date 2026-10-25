using System;

namespace CRMIdealApi.ApiModels;

public class ApiScorespInsertAndCalcOrderScores_Result
{
	public int? InsertedScoreId { get; set; }

	public double? Score { get; set; }

	public DateTime? ExpireDate { get; set; }

	public string ExpireDatePersian { get; set; }

	public int? RuleId { get; set; }

	public string RuleTitle { get; set; }

	public int? CompanyId { get; set; }

	public int? OrderId { get; set; }

	public string Company { get; set; }

	public int? MoneyBagInsertedId { get; set; }

	public decimal? MoneyBagAmount { get; set; }

	public decimal? MoneyBagAmountPercent { get; set; }

	public bool? IsRepeatPrd { get; set; }

	public string ConditionsErrorJs { get; set; }
}
