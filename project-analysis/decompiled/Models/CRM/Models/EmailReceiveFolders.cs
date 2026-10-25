using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(EmailReceiveFoldersMetadata))]
public class EmailReceiveFolders
{
	public int EmailReceiveFolderId { get; set; }

	public string FolderName { get; set; }

	public int EmailUsersInfoId { get; set; }

	public int FirstRegisterUserId { get; set; }

	public DateTime FirstRegisterDate { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public int UserId { get; set; }

	public short Year1 { get; set; }

	public short Month1 { get; set; }

	public DateTime RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	public Guid GUId { get; set; }

	public string AppType { get; set; }

	public int LanguageID { get; set; }

	public long? LastEmailUID { get; set; }

	public string LastEmailUIDStr { get; set; }

	public int? ParentFolderId { get; set; }

	public virtual ICollection<EmailReceive> EmailReceive { get; set; }

	public virtual Languages Languages { get; set; }

	public virtual EmailUsersInfo EmailUsersInfo { get; set; }

	public virtual Users Users { get; set; }

	public virtual Users Users1 { get; set; }

	public EmailReceiveFolders()
	{
		EmailReceive = (ICollection<EmailReceive>)new HashSet<EmailReceive>();
	}
}
