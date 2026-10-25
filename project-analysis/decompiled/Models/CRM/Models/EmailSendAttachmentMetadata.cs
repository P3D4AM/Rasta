using System;

namespace CRM.Models;

internal class EmailSendAttachmentMetadata
{
	public int EmailSendAttachmentId { get; set; }

	public int EmailSendHeaderId { get; set; }

	public string FileName { get; set; }

	public string FilePath { get; set; }

	public DateTime RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	public Guid GUId { get; set; }

	public virtual EmailSendHeader EmailSendHeader { get; set; }

	public string AppType { get; set; }
}
