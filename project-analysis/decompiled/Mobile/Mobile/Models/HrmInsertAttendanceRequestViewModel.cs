namespace Mobile.Models;

public class HrmInsertAttendanceRequestViewModel
{
	public string FirstRegisterDatePersian { get; set; }

	public string MsgSendDate { get; set; }

	public string MsgSendTime { get; set; }

	public int? MsgMasterId { get; set; }

	public string MsgSubject { get; set; }

	public string MsgBody { get; set; }

	public int MsgFromUserId { get; set; }

	public int? MsgAttachRecId { get; set; }

	public int MsgTypeId { get; set; }

	public bool? MsgActiveInCycle { get; set; }

	public int? MsgLastGroupId { get; set; }

	public int? MsgIsFinalised { get; set; }

	public int? ReplyPriorityId { get; set; }

	public string LoadMessage { get; set; }

	public int MessageAttachRecId { get; set; }

	public string SendMode { get; set; }

	public bool IsForwardMessage { get; set; }

	public int AttachRecId { get; set; }

	public int CompanyId { get; set; }

	public int ProjectId { get; set; }

	public bool EnableChkActiveInCycle { get; set; }

	public int FirstRegisterUserId { get; set; }

	public bool ActSelectReceiver { get; set; }

	public string MsgToUsersId { get; set; }

	public string MsgToUsersTitle { get; set; }

	public string ApiId { get; set; }

	public int? LanguageId { get; set; }

	public int? msgdAttachRecIdI { get; set; }

	public string msgdAttachRecDescI { get; set; }

	public string MsgdExtraData { get; set; }
}
