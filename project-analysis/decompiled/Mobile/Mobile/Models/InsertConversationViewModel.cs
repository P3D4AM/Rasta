namespace Mobile.Models;

public class InsertConversationViewModel
{
	public int CnvsProjectId { get; set; }

	public int CnvsCompanyId { get; set; }

	public string CnvsDate { get; set; }

	public string CnvsDay { get; set; }

	public string CnvsTime { get; set; }

	public int CnvsTopicId { get; set; }

	public string CnvsSubject { get; set; }

	public string CnvsDesc { get; set; }

	public int CnvsPersonId { get; set; }

	public int CnvsUserId { get; set; }

	public int CnvsReferUserId { get; set; }

	public string CnvsReferDesc { get; set; }

	public int CnvsStatusId { get; set; }

	public int? CnvsPriorityId { get; set; }

	public string CnvsRemindDate { get; set; }

	public string CnvsRemindTime { get; set; }

	public string CnvsRemindDateForAllarm { get; set; }

	public bool? CnvsRemindOk { get; set; }

	public bool? CnvsIsBookMark { get; set; }

	public int FirstRegisterUserId { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public string TmpUserMultiUserText { get; set; }

	public string ApiId { get; set; }

	public int? LanguageId { get; set; }

	public string CnvsCoordinateLatitude { get; set; }

	public string CnvsCoordinateLongitude { get; set; }

	public string CnvsCoordinateLastDate { get; set; }

	public bool EventPolicyNeedCheck { get; set; }
}
