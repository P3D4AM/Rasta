namespace CRM.Models;

public class CRMspDySelectNotFormUserAccess_Result
{
	public int FormId { get; set; }

	public string FormName { get; set; }

	public int? ParentFormId { get; set; }

	public string ParentForm { get; set; }

	public int? CrmSysPartId { get; set; }

	public string CrmSysPartTitle { get; set; }

	public int? FOSysPartId { get; set; }

	public string FOSysPartTitle { get; set; }

	public string CrmSysPartShow { get; set; }

	public string FOSysPartShow { get; set; }
}
