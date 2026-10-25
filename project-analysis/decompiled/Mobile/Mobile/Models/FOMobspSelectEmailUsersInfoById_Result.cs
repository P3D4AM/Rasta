using System;

namespace Mobile.Models;

public class FOMobspSelectEmailUsersInfoById_Result
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

	public int UserId { get; set; }

	public string RegisterDatePersian { get; set; }

	public DateTime RegisterDate { get; set; }

	public Guid GUId { get; set; }

	public string AppType { get; set; }

	public int FirstRegisterUserId { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public int? LanguageID { get; set; }

	public DateTime? FirstRegisterDate { get; set; }

	public int? euSMTPPort { get; set; }

	public bool? euSMTPUseSsl { get; set; }

	public bool? euSMTPUseDefCredentials { get; set; }
}
