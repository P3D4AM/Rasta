namespace CRM.Models;

public class CRMspSelectProjectInformationsTree_Result
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
}
