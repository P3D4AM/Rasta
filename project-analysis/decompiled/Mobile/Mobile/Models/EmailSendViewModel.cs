namespace Mobile.Models;

public class EmailSendViewModel
{
	public string EmailSubject { get; set; }

	public string EmailBody { get; set; }

	public int PriorityId { get; set; }

	public int EmailUsersInfoId { get; set; }

	public int EmailSettingId { get; set; }

	public string EmailAddress { get; set; }

	public int? EmailCmpId { get; set; }

	public int? EmailCmpPrsId { get; set; }

	public int? EmailCmpPrjId { get; set; }

	public string EmailCmpPrsName { get; set; }

	public string EmailCmpName { get; set; }

	public string EmailPrsJob { get; set; }

	public int StatusId { get; set; }

	public bool IsLogEmailAdmin { get; set; }

	public string CmpPassword { get; set; }

	public bool? EmailSendingIsActive { get; set; }

	public int? CId { get; set; }
}
