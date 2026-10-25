using System;

namespace CRM.Models;

public class CRMspSelectProjectTitlesById_Result
{
	public int ProjectTitleID { get; set; }

	public string ProjectTitle { get; set; }

	public int? ProjectTitleGroupId { get; set; }

	public int? ProjectTitleStatusGroupId { get; set; }

	public int? ProjectTitleGradeId { get; set; }

	public int? ProjectTitlePriorityId { get; set; }

	public string ProjectTitleDesc { get; set; }

	public int UserId { get; set; }

	public short Year1 { get; set; }

	public short Month1 { get; set; }

	public DateTime RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	public Guid? GUId { get; set; }

	public string AppType { get; set; }

	public int? LanguageID { get; set; }

	public int? FirstRegisterUserId { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public DateTime? FirstRegisterDate { get; set; }

	public string FirstRegisterUser { get; set; }

	public string EditUser { get; set; }

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
