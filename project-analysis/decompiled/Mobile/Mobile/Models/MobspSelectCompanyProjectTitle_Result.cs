namespace Mobile.Models;

public class MobspSelectCompanyProjectTitle_Result
{
	public string prjTitle { get; set; }

	public int? ProjectTitleStatusGroupId { get; set; }

	public int? ProjectTitleGroupId { get; set; }

	public int? ProjectTitleGradeId { get; set; }

	public int? ProjectTitlePriorityId { get; set; }

	public string ProjectTitleDesc { get; set; }

	public string prjStatusGroup { get; set; }

	public int? ProjectCategoryId { get; set; }

	public int? PrjTitleGroupId { get; set; }

	public string PrjTitleGroup { get; set; }

	public string PrjPostFix { get; set; }

	public int? PrjRemindDay { get; set; }

	public bool? PrjFOCmpCanSee { get; set; }

	public bool? PrjIsTicket { get; set; }
}
