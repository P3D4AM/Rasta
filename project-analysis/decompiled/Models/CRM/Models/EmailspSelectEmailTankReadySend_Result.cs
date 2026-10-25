namespace CRM.Models;

public class EmailspSelectEmailTankReadySend_Result
{
	public int UserId { get; set; }

	public int Header_Id { get; set; }

	public string Header_Subject { get; set; }

	public string Header_Body { get; set; }

	public int Header_PriorityId { get; set; }

	public int Setting_Id { get; set; }

	public int UsersInfo_Id { get; set; }

	public int UsersInfo_euUserId { get; set; }

	public string UsersInfo_euNikeName { get; set; }

	public string UsersInfo_euNikeEmail { get; set; }

	public string UsersInfo_euPOP3Server { get; set; }

	public string UsersInfo_euSMTPServer { get; set; }

	public string UsersInfo_euUserName { get; set; }

	public string UsersInfo_euPassword { get; set; }

	public bool UsersInfo_euIsActive { get; set; }

	public int Detail_Id { get; set; }

	public string Detail_EmailAddress { get; set; }

	public int? Detail_EmailCmpId { get; set; }

	public int? Detail_EmailCmpPrsId { get; set; }

	public int? Detail_EmailCmpPrjId { get; set; }

	public string Detail_EmailCmpName { get; set; }

	public string Detail_EmailCmpPrsName { get; set; }

	public string Detail_EmailPrsJob { get; set; }

	public int Detail_StatusId { get; set; }

	public string Detail_AppType { get; set; }

	public int? Detail_TryCount { get; set; }

	public bool? UsersInfo_euSMTPUseDefCredentials { get; set; }

	public bool? UsersInfo_euSMTPUseSsl { get; set; }

	public int? UsersInfo_euSMTPPort { get; set; }
}
