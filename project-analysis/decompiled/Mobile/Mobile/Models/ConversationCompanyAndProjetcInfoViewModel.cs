namespace Mobile.Models;

public class ConversationCompanyAndProjetcInfoViewModel
{
	public int? CompanyId { get; set; }

	public string CompanyName { get; set; }

	public int? ProjectId { get; set; }

	public string ProjectTitle { get; set; }

	public int? StatusGroupId { get; set; }

	public string LastStatus { get; set; }

	public string LastCnvsUser { get; set; }

	public string LastCnvsReferUser { get; set; }

	public int? LastCnvsReferUserId { get; set; }

	public bool ActCanEditcnvsDate { get; set; }

	public bool ActCanEditcnvsTime { get; set; }

	public bool ActReferToMultilUser { get; set; }

	public bool ActCanSetRemindOkInInsertMode { get; set; }

	public bool ActPost { get; set; }

	public bool MustFullcnvsRemindDate { get; set; }

	public bool ActAddDefaultText { get; set; }

	public bool ActInsertWithMapLocationIsForced { get; set; }
}
