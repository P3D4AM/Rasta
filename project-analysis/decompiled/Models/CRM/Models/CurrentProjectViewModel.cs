namespace CRM.Models;

public class CurrentProjectViewModel
{
	public CRMspSelectCompanyProjectPreview_Result Project { get; set; }

	public int ProjectCurrentId { get; set; }

	public int ProjectNextId { get; set; }

	public int ProjectPreviousId { get; set; }

	public int ProjectFirstId { get; set; }

	public int ProjectLastId { get; set; }

	public bool IsFind { get; set; }

	public string Message { get; set; }

	public string prjToDoTimeStr { get; set; }

	public string prjToDoTimeRegisterStr { get; set; }

	public string prjToDoTimeDoneStr { get; set; }

	public string cnvsPrjDoingTime { get; set; }
}
