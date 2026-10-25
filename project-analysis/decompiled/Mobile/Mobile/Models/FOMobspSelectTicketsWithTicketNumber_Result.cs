using System;

namespace Mobile.Models;

public class FOMobspSelectTicketsWithTicketNumber_Result
{
	public int ConversationID { get; set; }

	public int? cnvsProjectId { get; set; }

	public string cnvsProject { get; set; }

	public int cnvsCompanyId { get; set; }

	public string cnvsCompany { get; set; }

	public DateTime? cnvsDate { get; set; }

	public string cnvsDatePerWithSlash { get; set; }

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

	public int? FirstRegisterUserId { get; set; }

	public string FirstRegisterUser { get; set; }

	public int? cnvsStatusId { get; set; }

	public string cnvsStatus { get; set; }

	public int? cnvsPriorityId { get; set; }

	public string cnvsPriority { get; set; }

	public int? prjUserDepartmentId { get; set; }

	public string prjUserDepartment { get; set; }

	public string DefaultReferUser { get; set; }

	public int? DefaultReferUserId { get; set; }

	public long? RowNumber { get; set; }

	public int AllPage { get; set; }

	public string TicketFooterText { get; set; }

	public int? cnvsHappyVote { get; set; }

	public string PrjPostFix { get; set; }
}
