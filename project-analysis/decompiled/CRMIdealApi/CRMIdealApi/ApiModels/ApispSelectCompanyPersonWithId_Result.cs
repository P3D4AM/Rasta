namespace CRMIdealApi.ApiModels;

public class ApispSelectCompanyPersonWithId_Result
{
	public int CompanyPersonID { get; set; }

	public int prsCompanyId { get; set; }

	public string CompanyName { get; set; }

	public string prsLName { get; set; }

	public string prsFName { get; set; }

	public string PersonName { get; set; }

	public int? prsTitleId { get; set; }

	public string prsTitle { get; set; }

	public string Person { get; set; }
}
