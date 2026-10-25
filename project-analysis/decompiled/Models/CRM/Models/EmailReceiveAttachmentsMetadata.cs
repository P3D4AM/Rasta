using System;
using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

public class EmailReceiveAttachmentsMetadata
{
	[Key]
	public int EmailReceiveAttachmentId { get; set; }

	public string ContentId { get; set; }

	public string FileName { get; set; }

	public string SaveFilePath { get; set; }

	public string FileType { get; set; }

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
}
