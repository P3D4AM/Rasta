using System;

namespace CRMIdealApi.ApiModels;

public class ApispSelectProjectTitles_Result
{
	public int ProjectTitleID { get; set; }

	public string ProjectTitle { get; set; }

	public int? ProjectTitleGroupId { get; set; }

	public int? ProjectTitleStatusGroupId { get; set; }

	public int? ProjectTitleGradeId { get; set; }

	public int? ProjectTitlePriorityId { get; set; }

	public string ProjectTitleDesc { get; set; }

	public DateTime RegisterDate { get; set; }

	public DateTime? FirstRegisterDate { get; set; }

	public bool? ActivePrjNumRWithTitle { get; set; }

	public string ProjectTitleGroup { get; set; }

	public string ProjectTitleStatusGroup { get; set; }

	public string ProjectTitleGrade { get; set; }

	public string ProjectTitlePriority { get; set; }

	public int? PrjTitleGroupId { get; set; }

	public string PrjTitleGroup { get; set; }

	public string PrjPostFix { get; set; }

	public int? PrjRemindDay { get; set; }

	public bool? PrjFOCmpCanSee { get; set; }

	public bool? PrjIsTicket { get; set; }
}
