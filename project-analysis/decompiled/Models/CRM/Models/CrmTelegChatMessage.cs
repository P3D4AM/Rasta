using System;
using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(CrmTelegChatMessageMetadata))]
public class CrmTelegChatMessage
{
	public int TelegChatMessageId { get; set; }

	public long? MessageId { get; set; }

	public int? MessageTypeId { get; set; }

	public long? ChatId { get; set; }

	public string TextCaption { get; set; }

	public string DownloadFilePath { get; set; }

	public string FileId { get; set; }

	public string FilePath { get; set; }

	public string FileExensions { get; set; }

	public DateTime? Date { get; set; }

	public DateTime? EditDate { get; set; }

	public bool? InComing { get; set; }

	public int? CrmUserId { get; set; }

	public string Logitude { get; set; }

	public string Latitude { get; set; }

	public long? ReplyToMessageId { get; set; }

	public int? SendStatusId { get; set; }

	public DateTime? SendDateTime { get; set; }

	public DateTime? SentDateTime { get; set; }

	public string ErrorMessage { get; set; }

	public DateTime? ReadDateTime { get; set; }

	public string MessageLanguageCode { get; set; }

	public Guid? GUId { get; set; }

	public string AppType { get; set; }

	public int? LanguageID { get; set; }

	public int? SettingId { get; set; }

	public virtual CrmTelegMessageType CrmTelegMessageType { get; set; }

	public virtual Languages Languages { get; set; }

	public virtual CrmTelegSetting CrmTelegSetting { get; set; }

	public virtual Users Users { get; set; }
}
