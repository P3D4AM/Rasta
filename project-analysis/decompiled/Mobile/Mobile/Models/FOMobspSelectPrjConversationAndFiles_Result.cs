using System;

namespace Mobile.Models;

public class FOMobspSelectPrjConversationAndFiles_Result
{
	public int ConversationID { get; set; }

	public int OprType { get; set; }

	public int? cnvsProjectId { get; set; }

	public string cnvsProject { get; set; }

	public int? cnvsCompanyId { get; set; }

	public string cnvsCompany { get; set; }

	public string cnvsDay { get; set; }

	public string cnvsTime { get; set; }

	public DateTime? cnvsDate { get; set; }

	public string cnvsDatePerWithSlash { get; set; }

	public int? cnvsTopicId { get; set; }

	public string cnvsTopic { get; set; }

	public string cnvsSubject { get; set; }

	public string cnvsDesc { get; set; }

	public int? cnvsPersonId { get; set; }

	public string cnvsPerson { get; set; }

	public int? cnvsUserId { get; set; }

	public string cnvsUser { get; set; }

	public int? cnvsReferUserId { get; set; }

	public string cnvsReferUser { get; set; }

	public string cnvsReferDesc { get; set; }

	public int? cnvsStatusId { get; set; }

	public string cnvsStatus { get; set; }

	public int? cnvsProgressPercent { get; set; }

	public int? cnvsPriorityId { get; set; }

	public string cnvsPriority { get; set; }

	public string cnvsPriorityColor { get; set; }

	public string cnvsRemindTime { get; set; }

	public DateTime? cnvsRemindDate { get; set; }

	public string cnvsRemindDatePerWithSlash { get; set; }

	public bool? cnvsRemindOk { get; set; }

	public bool? cnvsIsBookMark { get; set; }

	public DateTime? cnvsRemindDateForAllarm { get; set; }

	public string cnvsRemindDatePerWithSlashForAllarm { get; set; }

	public int UserId { get; set; }

	public string RegisterUser { get; set; }

	public DateTime RegisterDate { get; set; }

	public string RegisterDatePerWithSlash { get; set; }

	public int? FirstRegisterUserId { get; set; }

	public string FirstRegisterUser { get; set; }

	public DateTime? FirstRegisterDate { get; set; }

	public string FirstRegisterDatePerWithSlash { get; set; }

	public string ApiId { get; set; }

	public bool? cnvsFOCmpCanSee { get; set; }

	public bool? cnvsIsTicket { get; set; }

	public string cnvsCoordinateLatitude { get; set; }

	public string cnvsCoordinateLongitude { get; set; }

	public DateTime? cnvsCoordinateLastDate { get; set; }

	public string cnvsCoordinateLastDatePersian { get; set; }

	public bool? cnvsTicketIsRead { get; set; }

	public string cnvsUserNickname { get; set; }

	public string cnvsReferUserNickname { get; set; }

	public string FileTitle { get; set; }

	public string FolderName { get; set; }

	public string FileName { get; set; }

	public string FilePath { get; set; }

	public string CopyFromPath { get; set; }

	public string cnvsKnowledgeTankIds { get; set; }

	public long? RowNumber { get; set; }

	public int? AllPage { get; set; }
}
