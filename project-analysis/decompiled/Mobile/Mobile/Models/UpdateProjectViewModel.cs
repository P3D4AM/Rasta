namespace Mobile.Models;

public class UpdateProjectViewModel
{
	public string Project { get; set; }

	public int CompanyId { get; set; }

	public int ProjectId { get; set; }

	public int CmpReferUserId { get; set; }

	public int? LanguageId { get; set; }

	public int? CenterId { get; set; }
}
