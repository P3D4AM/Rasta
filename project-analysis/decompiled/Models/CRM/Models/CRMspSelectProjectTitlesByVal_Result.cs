namespace CRM.Models;

public class CRMspSelectProjectTitlesByVal_Result
{
	public int ProjectTitleID { get; set; }

	public string ProjectTitle { get; set; }

	public int? ProjectTitleGroupId { get; set; }

	public int? ProjectTitleStatusGroupId { get; set; }

	public int? ProjectTitleGradeId { get; set; }

	public int? ProjectTitlePriorityId { get; set; }

	public string ProjectTitleDesc { get; set; }

	public string ProjectTitles_Lang { get; set; }

	public int? LanguageID { get; set; }
}
