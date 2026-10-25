using System;

namespace CRM.Models;

public class CRMspSelectTelegChatMessageWithFileId_Result
{
	public int TelegChatMessageId { get; set; }

	public long? MessageId { get; set; }

	public int? MessageTypeId { get; set; }

	public string MessageType { get; set; }

	public long? ChatId { get; set; }

	public string ChatName { get; set; }

	public int? CompanyId { get; set; }

	public string CompanyName { get; set; }

	public int? CompanyPersonId { get; set; }

	public string PersonName { get; set; }

	public string UserName { get; set; }

	public string PhoneNumber { get; set; }

	public string ChatType { get; set; }

	public string ChatTitle { get; set; }

	public string TextCaption { get; set; }

	public string DownloadFilePath { get; set; }

	public string FileId { get; set; }

	public string FilePath { get; set; }

	public string FileExensions { get; set; }

	public DateTime? Date { get; set; }

	public string Time { get; set; }

	public string DatePerWithSlash { get; set; }

	public DateTime? EditDate { get; set; }

	public string EditTime { get; set; }

	public string EditDatePerWithSlash { get; set; }

	public bool? InComing { get; set; }

	public int? CrmUserId { get; set; }

	public string CrmUser { get; set; }

	public string Logitude { get; set; }

	public string Latitude { get; set; }

	public long? ReplyToMessageId { get; set; }

	public string ReplyToMessage { get; set; }

	public int? SendStatusId { get; set; }

	public DateTime? SendDateTime { get; set; }

	public string SendTime { get; set; }

	public string SendDatePerWithSlash { get; set; }

	public DateTime? SentDateTime { get; set; }

	public string SentTime { get; set; }

	public string SentDatePerWithSlash { get; set; }

	public string ErrorMessage { get; set; }

	public DateTime? ReadDateTime { get; set; }

	public string ReadTime { get; set; }

	public string ReadDatePerWithSlash { get; set; }

	public string MessageLanguageCode { get; set; }

	public Guid? GUId { get; set; }

	public string AppType { get; set; }

	public int? LanguageID { get; set; }

	public int? SettingId { get; set; }

	public int TotalPage { get; set; }

	public long? RowNum { get; set; }
}
