using System;

namespace Mobile.Models;

public class FOMobspSelectTickets_Result
{
	public long? RowNum { get; set; }

	public int? AllPage { get; set; }

	public int ProjectID { get; set; }

	public long? cnvsDoingTimeSec { get; set; }

	public int? ProcessKindId { get; set; }

	public string ProcessKindTitle { get; set; }

	public int? CalcYear { get; set; }

	public int? CalcMonth { get; set; }

	public int? CalcDay { get; set; }

	public int? CalcHour { get; set; }

	public int? CalcMinute { get; set; }

	public int prjCompanyId { get; set; }

	public string prjTitle { get; set; }

	public DateTime? prjStartDateTime { get; set; }

	public bool? prjIsFinished { get; set; }

	public DateTime? prjFinishedDateTime { get; set; }

	public int? prjcnvsStatusGroupId { get; set; }

	public string prjcnvsStatusGroup { get; set; }

	public int? prjOrderView { get; set; }

	public string prjPostFix { get; set; }

	public string prjTitleGroup { get; set; }

	public string ProjectTitle { get; set; }

	public bool? prjFOCmpCanSee { get; set; }

	public bool? prjIsTicket { get; set; }

	public int? prjUserDepartmentId { get; set; }

	public string prjUserDepartment { get; set; }

	public string DefaultReferUserName { get; set; }

	public int? DefaultReferUserId { get; set; }

	public DateTime? LastCnvsDate { get; set; }

	public int? LastCnvsUserId { get; set; }

	public string LastCnvsUser { get; set; }

	public int? LastCnvsReferUserId { get; set; }

	public string LastCnvsReferUser { get; set; }

	public bool? CnvsTicketIsRead { get; set; }

	public int? LastCnvsPersonId { get; set; }

	public string LastCnvsPerson { get; set; }

	public DateTime? prjToDoTime { get; set; }

	public DateTime? prjToDoTimeRegister { get; set; }

	public DateTime? prjToDoTimeDone { get; set; }

	public bool? prjTicketStop { get; set; }

	public int IsCurrTimeAfterToDoTime { get; set; }

	public int IsToDoTimeDoneAfterToDoTime { get; set; }

	public int? prjToDoRemainYear { get; set; }

	public int? prjToDoRemainMonth { get; set; }

	public int? prjToDoRemainDay { get; set; }

	public int? prjToDoRemainHour { get; set; }

	public int? prjToDoRemainMinute { get; set; }

	public string prjToDoRemain { get; set; }

	public int? prjToDoDoneRemainYear { get; set; }

	public int? prjToDoDoneRemainMonth { get; set; }

	public int? prjToDoDoneRemainDay { get; set; }

	public int? prjToDoDoneRemainHour { get; set; }

	public int? prjToDoDoneRemainMinute { get; set; }

	public string prjToDoDoneRemain { get; set; }

	public int? prjToDoTotalYear { get; set; }

	public int? prjToDoTotalMonth { get; set; }

	public int? prjToDoTotalDay { get; set; }

	public int? prjToDoTotalHour { get; set; }

	public int? prjToDoTotalMinute { get; set; }

	public string prjToDoTotal { get; set; }

	public int? prjToDoTotalDoneYear { get; set; }

	public int? prjToDoTotalDoneMonth { get; set; }

	public int? prjToDoTotalDoneDay { get; set; }

	public int? prjToDoTotalDoneHour { get; set; }

	public int? prjToDoTotalDoneMinute { get; set; }

	public string prjToDoTotalDone { get; set; }

	public int? ConversationID { get; set; }

	public int? CnvsFirstRegisterUserId { get; set; }
}
