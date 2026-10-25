using System;

namespace CRMIdealApi.ApiModels;

public class UpdateConversationViewModel
{
	public string UserName { get; set; }

	public string Password { get; set; }

	public int UserId { get; set; }

	public int? ApiCompanyId { get; set; }

	public int? ApiPersonId { get; set; }

	public int? ApiProjectId { get; set; }

	public int ApiConversationId { get; set; }

	public string ApiCnvsDate { get; set; }

	public DateTime? ApiCnvsDateTime { get; set; }

	public int? ApiCnvsTopicId { get; set; }

	public string ApiCnvsSubject { get; set; }

	public string ApiCnvsDesc { get; set; }

	public int? ApiCnvsUserId { get; set; }

	public int? ApiCnvsReferUserId { get; set; }

	public string ApiCnvsReferDesc { get; set; }

	public int? ApiCnvsStatusId { get; set; }

	public int? ApiCnvsPriorityId { get; set; }

	public string ApiCnvsRemindDate { get; set; }

	public DateTime? ApiCnvsRemindDateTime { get; set; }

	public string ApiCnvsRemindTime { get; set; }

	public bool? ApiCnvsRemindOk { get; set; }

	public bool? ApiCnvsIsBookMark { get; set; }

	public string ApiCnvsRemindDateForAllarm { get; set; }

	public DateTime? ApiCnvsRemindDateTimeForAllarm { get; set; }

	public string ApiCnvsApiId { get; set; }

	public bool? ApiCnvsFOCmpCanSee { get; set; }

	public bool? ApiCnvsIsTicket { get; set; }

	public string ApiCnvsCoordinateLatitude { get; set; }

	public string ApiCnvsCoordinateLongitude { get; set; }

	public string ApiCnvsCoordinateLastDatePersian { get; set; }

	public DateTime? ApiCnvsCoordinateLastDate { get; set; }

	public bool? ApiCnvsTicketIsRead { get; set; }

	public string ApiCnvsDoingTimeStr { get; set; }

	public TimeSpan? ApiCnvsDoingTime { get; set; }

	public bool? ApiCnvsIsCopy { get; set; }

	public int? ApiCnvsStatusResultId { get; set; }

	public int? LanguageId { get; set; }
}
