namespace CRM.Models;

public class CRMspDySelectParentFormsBySysPartIds_Result
{
	public int FormId { get; set; }

	public string FormName { get; set; }

	public string FormTitle { get; set; }

	public int? CrmSysPartId { get; set; }

	public int? FOSysPartId { get; set; }

	public string CrmSysPartTitle { get; set; }

	public string FormNameWithSysPart { get; set; }
}
