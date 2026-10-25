namespace CRM.Models;

public class CRMspRpt_ProjectInformationTree_Result
{
	public int RootId { get; set; }

	public string FieldTitle { get; set; }

	public string FieldValue { get; set; }

	public string Field { get; set; }

	public int ProjectInformationId { get; set; }

	public int ProjectId { get; set; }

	public string prjTitle { get; set; }

	public int? prjCompanyId { get; set; }

	public string Company { get; set; }

	public int FieldTitleId { get; set; }

	public int? SortCode { get; set; }

	public string CompanyTitle { get; set; }

	public string cmpName { get; set; }

	public string cmpCity { get; set; }

	public string cmpGroupIIName { get; set; }

	public string cmpGroupIIIName { get; set; }

	public string prjPostFix { get; set; }

	public string prjDesc { get; set; }

	public string rptDate { get; set; }

	public string rptDay { get; set; }

	public string UserName { get; set; }
}
