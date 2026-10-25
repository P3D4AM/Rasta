namespace CRM.Models;

public class EmailspSelectEmailInfo_Result
{
	public int EmailUsersInfoId { get; set; }

	public int euUserId { get; set; }

	public string euNikeName { get; set; }

	public string euNikeEmail { get; set; }

	public string euPOP3Server { get; set; }

	public string euSMTPServer { get; set; }

	public string euUserName { get; set; }

	public string euPassword { get; set; }

	public bool euIsActive { get; set; }

	public bool? euAutoDeleteReceivedEmail { get; set; }

	public bool? euPOP3UseSsl { get; set; }

	public int? euPOP3Port { get; set; }
}
