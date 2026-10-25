using System.Collections.Generic;

namespace CRM.Models;

public class CompanyScoresViewModel
{
	public bool IsFind { get; set; }

	public string Message { get; set; }

	public long TotalPage { get; set; }

	public List<ScorespSelectCompanyScores_Result> CompanyScores { get; set; }
}
