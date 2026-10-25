namespace Mobile.Models;

public class FoSendTicket
{
	public int DepartmentId { get; set; }

	public string Subject { get; set; }

	public string Description { get; set; }

	public int CompanyPersonId { get; set; }

	public int? PriorityId { get; set; }

	public int ProjectId { get; set; }

	public int ReferUserId { get; set; }

	public int? ProjectTitleGroupId { get; set; }

	public int? prjValidityPrdId { get; set; }

	public int? prjValidityOrdItemId { get; set; }

	public int? LanguageId { get; set; }

	public int? CenterId { get; set; }

	public int? FoSettingId { get; set; }
}
