namespace CRM.Models;

public class EmailspSelectEmailReceiveFoldersTree_Result
{
	public int? RootId { get; set; }

	public string KeyId { get; set; }

	public string KeyName { get; set; }

	public int EmailUsersInfoId { get; set; }

	public int? CountUnReadEmail { get; set; }

	public int? CountAllEmails { get; set; }

	public int? ParentFolderId { get; set; }
}
