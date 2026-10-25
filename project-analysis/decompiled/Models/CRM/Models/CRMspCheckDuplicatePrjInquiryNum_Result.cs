namespace CRM.Models;

public class CRMspCheckDuplicatePrjInquiryNum_Result
{
	public int ProjectID { get; set; }

	public int prjCompanyId { get; set; }

	public string CompanyName { get; set; }

	public int? CompanyNumber { get; set; }

	public string prjPostFix { get; set; }

	public string prjTitle { get; set; }

	public string Project { get; set; }

	public long? prjNumR { get; set; }

	public string prjInquiryNum { get; set; }
}
