using System;

namespace CRM.Models;

public class RecieveTelegChatMessageViewModel
{
	public long MessageId { get; set; }

	public int MessageTypeId { get; set; }

	public long ChatId { get; set; }

	public string TextCaption { get; set; }

	public string DownloadFilePath { get; set; }

	public string FileId { get; set; }

	public string FilePath { get; set; }

	public string FileExensions { get; set; }

	public DateTime? Date { get; set; }

	public DateTime? EditDate { get; set; }

	public bool InComing { get; set; }

	public string Logitude { get; set; }

	public string Latitude { get; set; }

	public long? ReplyToMessageId { get; set; }

	public string MessageLanguageCode { get; set; }

	public string AppType { get; set; }

	public int LanguageId { get; set; }

	public DateTime? ReadDateTime { get; set; }

	public int SettingId { get; set; }
}
