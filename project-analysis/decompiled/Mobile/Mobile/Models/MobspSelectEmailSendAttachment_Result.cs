using System;

namespace Mobile.Models;

public class MobspSelectEmailSendAttachment_Result
{
	public int EmailSendAttachmentId { get; set; }

	public int EmailSendHeaderId { get; set; }

	public string FileName { get; set; }

	public string FilePath { get; set; }

	public DateTime RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	public Guid GUId { get; set; }

	public string AppType { get; set; }

	public int? LanguageID { get; set; }

	public int? FirstRegisterUserId { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public DateTime? FirstRegisterDate { get; set; }
}
