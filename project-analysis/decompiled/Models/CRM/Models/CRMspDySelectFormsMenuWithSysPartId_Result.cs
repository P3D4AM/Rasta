namespace CRM.Models;

public class CRMspDySelectFormsMenuWithSysPartId_Result
{
	public int FormId { get; set; }

	public string FormName { get; set; }

	public string FormTitle { get; set; }

	public int? CrmSysPartId { get; set; }

	public int? FOSysPartId { get; set; }

	public string CrmSysPartShow { get; set; }

	public string FOSysPartShow { get; set; }
}
