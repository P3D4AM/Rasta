using System;

namespace CRM.Models;

public class CRMspResultsCallHistoryCartableWeb_Result
{
	public long? RowNumber { get; set; }

	public string IVRAuthResult { get; set; }

	public bool? IsFinished { get; set; }

	public int? cmpNumber { get; set; }

	public int? CompanyID { get; set; }

	public int? CompanyPersonID { get; set; }

	public string PhoneName { get; set; }

	public int CallTypeId { get; set; }

	public string CallType { get; set; }

	public string CallTime { get; set; }

	public DateTime? CallDateTime { get; set; }

	public string ExtensionUserName { get; set; }

	public string TrunkSource { get; set; }

	public string TrunkDestination { get; set; }

	public string CallDate { get; set; }

	public string CallDay { get; set; }

	public int? LineNumber { get; set; }

	public int CallHistoryid { get; set; }

	public DateTime RegisterDate { get; set; }

	public string PhoneNumber { get; set; }

	public int PersonId { get; set; }

	public string NoteWithRegEdt { get; set; }

	public string EditedUser { get; set; }

	public int? NoteRegisterUserId { get; set; }

	public int? NoteEditedUserId { get; set; }

	public int? NumberEditedUserId { get; set; }

	public string Tamas { get; set; }

	public string lenght { get; set; }

	public string FilePath { get; set; }

	public string FilePathWeb { get; set; }

	public string rptDate { get; set; }

	public string rptDay { get; set; }

	public string UserName { get; set; }

	public string internalDial { get; set; }

	public string internalName { get; set; }

	public int? DevType { get; set; }

	public int? ConversationID { get; set; }

	public int? cnvsProjectId { get; set; }

	public string cnvsFirstRegisterUser { get; set; }

	public string cmpUserName { get; set; }

	public int? FirstRegisterUserId { get; set; }

	public string FirstRegisterUser { get; set; }

	public int? TodayCallCnt { get; set; }

	public int? TodayCallDuration { get; set; }

	public string cnvsDesc { get; set; }

	public string cmpReferUser { get; set; }

	public string cmpSuppUser { get; set; }

	public string Extension { get; set; }

	public string InternalDialTrunkSource { get; set; }

	public string InternalDialTrunkDestination { get; set; }
}
