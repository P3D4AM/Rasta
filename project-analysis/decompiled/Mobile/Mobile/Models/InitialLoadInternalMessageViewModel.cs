namespace Mobile.Models;

public class InitialLoadInternalMessageViewModel
{
	public string SendMode { get; set; }

	public int MsgTypeId { get; set; }

	public int ReplyUserId { get; set; }

	public int LoadUserId { get; set; }

	public string LoadSubject { get; set; }

	public string LoadMessage { get; set; }

	public int ReplyPriorityId { get; set; }

	public int? ReplyGroupId { get; set; }

	public int? FlagShowReceivers { get; set; }

	public int? ReplyMasterMessageId { get; set; }

	public bool? ReplyActiveInCycle { get; set; }

	public int? MsgAttachRecId { get; set; }

	public int CompanyId { get; set; }

	public int ProjectId { get; set; }

	public string MsgToUsersId { get; set; }

	public int? LanguageId { get; set; }
}
