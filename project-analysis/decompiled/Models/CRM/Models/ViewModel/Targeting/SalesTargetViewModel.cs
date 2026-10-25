using System;
using System.Collections.Generic;

namespace CRM.Models.ViewModel.Targeting;

public class SalesTargetViewModel
{
	public int SalesTargetId { get; set; }

	public string TargetTitle { get; set; }

	public string TargetTitle_Lang { get; set; }

	public int? TargetOrderCount { get; set; }

	public decimal? TargetOrderAmount { get; set; }

	public DateTime TargetFromDateTime { get; set; }

	public DateTime TargetToDateTime { get; set; }

	public string TargetFromDate { get; set; }

	public string TargetToDate { get; set; }

	public string TargetDistributionDetailsJson { get; set; }

	public SalesTargetDistributionViewModel TargetDistributionDetails { get; set; }

	public string TargetTermsJson { get; set; }

	public List<SalesTargetTermViewModel> TargetTerms { get; set; }

	public SalesTargetUserScopeViewModel TargetUserScope { get; set; }

	public string TargetUserScopeJson { get; set; }

	public DateTime RegisterDateTime { get; set; }

	public string RegisterDate { get; set; }

	public string FirstRegisterDate { get; set; }

	public string FirstRegisterUser { get; set; }

	public string RegisterUser { get; set; }

	public string TargetType { get; set; }
}
