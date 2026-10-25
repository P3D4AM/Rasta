using System;

namespace CRM.Models;

public class CRMspSelectConversationByCmpOrCnvsId_Result
{
	public int ConversationID { get; set; }

	public int? cnvsProjectId { get; set; }

	public string cnvsProject { get; set; }

	public int cnvsCompanyId { get; set; }

	public string cnvsCompany { get; set; }

	public string cnvsDate { get; set; }

	public string cnvsDay { get; set; }

	public string cnvsTime { get; set; }

	public DateTime? cnvsDateTime { get; set; }

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

	public int? cnvsPriorityId { get; set; }

	public string cnvsPriority { get; set; }

	public string cnvsPriorityColor { get; set; }

	public string cnvsRemindDate { get; set; }

	public string cnvsRemindTime { get; set; }

	public DateTime? cnvsRemindDateTime { get; set; }

	public bool? cnvsRemindOk { get; set; }

	public bool? cnvsIsBookMark { get; set; }

	public int? cnvsFirstRegisterUserId { get; set; }

	public string cnvsFirstRegisterUser { get; set; }

	public string cnvsFirstRegisterDate { get; set; }

	public DateTime? cnvsFirstRegisterDateTime { get; set; }

	public int UserId { get; set; }

	public string RegisterUser { get; set; }

	public short Year1 { get; set; }

	public short Month1 { get; set; }

	public DateTime RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	public DateTime? FirstRegisterDate { get; set; }

	public Guid? GUId { get; set; }

	public string cnvsRemindDateForAllarm { get; set; }

	public DateTime? cnvsRemindDateTimeForAllarm { get; set; }

	public string AppType { get; set; }

	public int? LanguageID { get; set; }

	public int? FirstRegisterUserId { get; set; }

	public string FirstRegisterUser { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public string ApiId { get; set; }

	public bool? cnvsFOCmpCanSee { get; set; }

	public bool? cnvsIsTicket { get; set; }

	public string cnvsCoordinateLatitude { get; set; }

	public string cnvsCoordinateLongitude { get; set; }

	public DateTime? cnvsCoordinateLastDate { get; set; }

	public string cnvsCoordinateLastDatePersian { get; set; }

	public bool? cnvsTicketIsRead { get; set; }

	public TimeSpan? cnvsDoingTime { get; set; }

	public bool? cnvsIsCopy { get; set; }

	public int? cnvsStatusResultId { get; set; }
}
