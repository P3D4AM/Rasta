namespace Mobile.Models;

public class MobspSelectCompanyProjects_Result
{
	public int ProjectID { get; set; }

	public int prjCompanyId { get; set; }

	public string prjTitle { get; set; }

	public bool prjIsFinished { get; set; }

	public int prjcnvsStatusGroupId { get; set; }

	public string prjcnvsStatusGroup { get; set; }

	public string prjPostFix { get; set; }

	public string ProjectTitle { get; set; }

	public string prjCompany { get; set; }

	public string TitlePercent { get; set; }

	public int? ActiveCount { get; set; }

	public int? ArchiveCount { get; set; }
}
