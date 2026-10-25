using System;

namespace Mobile.Models;

public class MobspSelectCompanyConversationsByProject_Result
{
	public long? Rownum { get; set; }

	public int ConversationID { get; set; }

	public int? cnvsProjectId { get; set; }

	public int cnvsCompanyId { get; set; }

	public string cnvsDate { get; set; }

	public string cnvsDay { get; set; }

	public string cnvsTime { get; set; }

	public DateTime? cnvsDateTime { get; set; }

	public int? cnvsTopicId { get; set; }

	public string cnvsSubject { get; set; }

	public string cnvsDesc { get; set; }

	public int? cnvsPersonId { get; set; }

	public int? cnvsUserId { get; set; }

	public int? cnvsReferUserId { get; set; }

	public int? cnvsStatusId { get; set; }

	public int? cnvsPriorityId { get; set; }

	public bool? cnvsIsBookMark { get; set; }

	public DateTime RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	public DateTime? FirstRegisterDate { get; set; }

	public int? FirstRegisterUserId { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public bool? cnvsFOCmpCanSee { get; set; }

	public string cnvsCompany { get; set; }

	public string cnvsProject { get; set; }

	public string cnvsTopic { get; set; }

	public string cnvsPerson { get; set; }

	public string cnvsUser { get; set; }

	public string cnvsReferUser { get; set; }

	public string cnvsStatus { get; set; }

	public string cnvsPriority { get; set; }

	public string RegisterUser { get; set; }

	public string FirstRegisterUser { get; set; }

	public int? AllPage { get; set; }
}
