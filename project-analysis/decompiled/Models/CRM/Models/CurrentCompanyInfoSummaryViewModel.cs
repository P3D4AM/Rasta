namespace CRM.Models;

public class CurrentCompanyInfoSummaryViewModel
{
	public mct_CrmCompany_Result Company { get; set; }

	public string CompanyMultiGroup { get; set; }

	public int CurrentId { get; set; }

	public int NextId { get; set; }

	public int PreviousId { get; set; }

	public int FirstId { get; set; }

	public int LastId { get; set; }

	public string Message { get; set; }

	public bool IsFind { get; set; }

	public CompanyAccountingSummaryViewModel Accounting { get; set; }

	public CrmCompanyLoGo CmpLogo { get; set; }
}
