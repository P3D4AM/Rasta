using System;

namespace CRM.Models;

public class AIspSelectCompanyConversationsByProject_Result
{
	public int ConversationID { get; set; }

	public int? cnvsProjectId { get; set; }

	public int cnvsCompanyId { get; set; }

	public string cnvsDate { get; set; }

	public DateTime? cnvsDateTime { get; set; }

	public string cnvsDay { get; set; }

	public string cnvsTime { get; set; }

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

	public string cnvsRemindDate { get; set; }

	public DateTime? cnvsRemindDateTime { get; set; }

	public string cnvsRemindTime { get; set; }

	public bool? cnvsRemindOk { get; set; }

	public bool? cnvsIsBookMark { get; set; }

	public string cnvsRemindDateForAllarm { get; set; }

	public DateTime? cnvsRemindDateTimeForAllarm { get; set; }

	public int? cnvsFirstRegisterUserId { get; set; }

	public string cnvsFirstRegisterUser { get; set; }

	public string cnvsFirstRegisterDate { get; set; }

	public DateTime? cnvsFirstRegisterDateTime { get; set; }

	public int UserId { get; set; }

	public string User { get; set; }

	public DateTime RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	public DateTime? FirstRegisterDate { get; set; }

	public string prsMobile { get; set; }

	public string prsPreTel { get; set; }

	public string prsTel { get; set; }

	public string prsTelUpTo { get; set; }

	public string prsTelDesc { get; set; }

	public string prsJob { get; set; }

	public long RowNumber { get; set; }

	public int TotalCount { get; set; }

	public string cnvsDateTimeStr { get; set; }
}
