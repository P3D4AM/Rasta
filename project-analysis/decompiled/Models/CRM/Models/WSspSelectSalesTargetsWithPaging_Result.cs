using System;

namespace CRM.Models;

public class WSspSelectSalesTargetsWithPaging_Result
{
	public int SalesTargetId { get; set; }

	public string TargetTitle { get; set; }

	public int? TargetOrderCount { get; set; }

	public decimal? TargetOrderAmount { get; set; }

	public DateTime TargetFromDate { get; set; }

	public DateTime TargetToDate { get; set; }

	public string TargetFromDatePersian { get; set; }

	public string TargetToDatePersian { get; set; }

	public DateTime RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	public DateTime FirstRegisterDate { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public string LangTitleJson { get; set; }

	public string TargetDistributionDetailsJson { get; set; }

	public string TargetTermsJson { get; set; }

	public string TargetUserScopeJson { get; set; }
}
