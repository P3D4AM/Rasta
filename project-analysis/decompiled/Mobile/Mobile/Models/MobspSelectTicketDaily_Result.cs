using System;

namespace Mobile.Models;

public class MobspSelectTicketDaily_Result
{
	public long? RowNumberPaging { get; set; }

	public int ProjectID { get; set; }

	public long? TotalCount { get; set; }

	public int prjCompanyId { get; set; }

	public string prjCompanyName { get; set; }

	public string prjTitle { get; set; }

	public string prjTitleGroup { get; set; }

	public DateTime? prjStartDate { get; set; }

	public string prjStartDatePersian { get; set; }

	public bool? prjIsFinished { get; set; }

	public bool? prjIsTicketNew { get; set; }

	public string prjFinishedUser { get; set; }

	public DateTime? prjFinishedDate { get; set; }

	public string prjFinishedDatePersian { get; set; }

	public string ProjectTitle { get; set; }

	public bool? prjFOCmpCanSee { get; set; }

	public bool? prjIsTicket { get; set; }

	public DateTime? LastCnvsDate { get; set; }

	public string LastCnvsDatePersian { get; set; }

	public int? LastCnvsUserId { get; set; }

	public string prjPostFix { get; set; }

	public int? LastCnvsPriorityId { get; set; }

	public string LastCnvsPriority { get; set; }

	public string LastCnvsPriorityColor { get; set; }

	public string prjTitleGroupColor { get; set; }

	public string cnvsDesc { get; set; }

	public string LastCnvsUser { get; set; }

	public int? LastCnvsReferUserId { get; set; }

	public string LastCnvsReferUser { get; set; }

	public int? LastCnvsPersonId { get; set; }

	public string LastCnvsPerson { get; set; }

	public int? IsCurrTimeAfterToDoTime { get; set; }

	public DateTime? prjToDoTime { get; set; }

	public string prjToDoTimePersian { get; set; }

	public DateTime? prjToDoTimeRegister { get; set; }

	public string prjToDoTimeRegisterPersian { get; set; }

	public DateTime? prjToDoTimeDone { get; set; }

	public string prjToDoTimeDonePersian { get; set; }

	public int? prjToDoRemainYear { get; set; }

	public int? prjToDoRemainMonth { get; set; }

	public int? prjToDoRemainDay { get; set; }

	public int? prjToDoRemainHour { get; set; }

	public int? prjToDoRemainMinute { get; set; }

	public int IsDoneTimeAfterToDoTime { get; set; }

	public int? prjToDoDoneRemainYear { get; set; }

	public int? prjToDoDoneRemainMonth { get; set; }

	public int? prjToDoDoneRemainDay { get; set; }

	public int? prjToDoDoneRemainHour { get; set; }

	public int? prjToDoDoneRemainMinute { get; set; }

	public string LastCnvsUserNickname { get; set; }

	public int ConversationID { get; set; }

	public int? CnvsFirstRegisterUserId { get; set; }

	public int CnvsNotRepliedCount { get; set; }
}
