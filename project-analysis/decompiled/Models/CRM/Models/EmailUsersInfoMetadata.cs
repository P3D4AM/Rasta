using System;

namespace CRM.Models;

public class EmailUsersInfoMetadata
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

	public DateTime? FirstRegisterDate { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public int? LanguageID { get; set; }
}
