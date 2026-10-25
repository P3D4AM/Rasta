using System;

namespace CRMIdealApi.ApiModels;

public class ApispSelectConversation_Result
{
	public int ApiConversationID { get; set; }

	public int? ApiCnvsProjectId { get; set; }

	public string ApiCnvsProject { get; set; }

	public int ApiCnvsCompanyId { get; set; }

	public string ApiCnvsCompany { get; set; }

	public string ApiCnvsDate { get; set; }

	public string ApiCnvsDay { get; set; }

	public string ApiCnvsTime { get; set; }

	public int? ApiCnvsTopicId { get; set; }

	public string ApiCnvsTopic { get; set; }

	public string ApiCnvsSubject { get; set; }

	public string ApiCnvsDesc { get; set; }

	public int? ApiCnvsPersonId { get; set; }

	public string ApiCnvsPerson { get; set; }

	public int? ApiCnvsUserId { get; set; }

	public string ApiCnvsUser { get; set; }

	public int? ApiCnvsReferUserId { get; set; }

	public string ApiCnvsReferUser { get; set; }

	public string ApiCnvsReferDesc { get; set; }

	public int? ApiCnvsStatusId { get; set; }

	public string ApiCnvsStatus { get; set; }

	public int? ApiCnvsPriorityId { get; set; }

	public string ApiCnvsPriority { get; set; }

	public string ApiCnvsRemindDate { get; set; }

	public string ApiCnvsRemindTime { get; set; }

	public bool? ApiCnvsRemindOk { get; set; }

	public bool? ApiCnvsIsBookMark { get; set; }

	public int ApiUserId { get; set; }

	public string ApiEditUser { get; set; }

	public DateTime ApiRegisterDate { get; set; }

	public string ApiCnvsRemindDateForAllarm { get; set; }

	public DateTime? ApiCnvsDateTime { get; set; }

	public DateTime? ApiCnvsRemindDateTime { get; set; }

	public int? ApiFirstRegisterUserId { get; set; }

	public string ApiFirstRegisterUser { get; set; }

	public DateTime? ApiFirstRegisterDate { get; set; }

	public DateTime? ApiCnvsRemindDateTimeForAllarm { get; set; }

	public bool? ApiCnvsFOCmpCanSee { get; set; }

	public bool? ApiCnvsIsTicket { get; set; }

	public string ApiCnvsCoordinateLatitude { get; set; }

	public string ApiCnvsCoordinateLongitude { get; set; }

	public DateTime? ApiCnvsCoordinateLastDate { get; set; }

	public string ApiCnvsCoordinateLastDatePersian { get; set; }

	public bool? ApiCnvsTicketIsRead { get; set; }

	public TimeSpan? ApiCnvsDoingTime { get; set; }

	public bool? ApiCnvsIsCopy { get; set; }

	public int? ApiCnvsCId { get; set; }

	public string ApiCnvsCenterName { get; set; }

	public long? ApiRowNumber { get; set; }

	public int? ApiTotalCount { get; set; }

	public int? ApiCnvsStatusResultId { get; set; }

	public string ApiCnvsStatusResult { get; set; }
}
