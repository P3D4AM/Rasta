using System;
using System.ComponentModel.DataAnnotations;
using CRM.Resources;

namespace CRM.Models;

public class CRMspReturnDailyCIRecordVoiceInformationViewModel
{
	public int? CompanyID { get; set; }

	public int? CompanyPersonID { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "CDailyTelPhoneName")]
	public string PhoneName { get; set; }

	public int? CallTypeId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "CDailyTelCallType")]
	public string CallType { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "CDailyTelCallTime")]
	public string CallTime { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "CDailyTelCallDate")]
	public string CallDate { get; set; }

	public string CallDay { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "CDailyTelLineNumber")]
	public int? LineNumber { get; set; }

	public int? CallHistoryid { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "CDailyTelCallDate")]
	public DateTime? RegisterDate { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "CDailyTelCallDate")]
	public string RegisterDateStr { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "CDailyTelPhoneNumber")]
	public string PhoneNumber { get; set; }

	public int? PersonId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "CDailyTelNoteWithRegEdt")]
	public string NoteWithRegEdt { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "CDailyTelNumberEditedUserId")]
	public string EditedUser { get; set; }

	public int? NoteRegisterUserId { get; set; }

	public int? NoteEditedUserId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "CDailyTelNumberEditedUserId")]
	public int? NumberEditedUserId { get; set; }

	public string Tamas { get; set; }

	public string Lenght { get; set; }

	public string FilePath { get; set; }

	public string rptDate { get; set; }

	public string rptDay { get; set; }

	public string UserName { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "CDailyTelDuration")]
	public string Duration { get; set; }

	public int? ID { get; set; }

	public string Name { get; set; }

	public string PName { get; set; }

	public string Dial { get; set; }

	public bool? HaveFile { get; set; }

	public string File { get; set; }

	public string CID { get; set; }

	public string Comment { get; set; }

	public int? PartNumber { get; set; }

	public bool? Archive { get; set; }

	public bool? Completed { get; set; }

	public string InternalDial { get; set; }

	public string CityName { get; set; }

	public string CityOstan { get; set; }

	public string Price { get; set; }

	public string InternalName { get; set; }

	public int? UserID { get; set; }

	public short? Year1 { get; set; }

	public short? Month1 { get; set; }

	public string RegisterDatePersian { get; set; }

	public string CallerIDDetectData { get; set; }

	public Guid? GUId { get; set; }

	public string StartTime { get; set; }

	public string EndTime { get; set; }

	public string Note { get; set; }

	public int? Channel { get; set; }

	public int? DevType { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "CDailyTelConversation")]
	public int? ConversationID { get; set; }

	public int? cnvsProjectId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "CDailyTelCnvsFirstRegisterUser")]
	public string cnvsFirstRegisterUser { get; set; }

	public string RegisterDateStrI { get; set; }

	public string TrunkSource { get; set; }

	public string TrunkDestination { get; set; }

	public DateTime? CallDateTime { get; set; }

	public string ExtensionUserName { get; set; }

	public long? RowNumber { get; set; }

	public string IVRAuthResult { get; set; }

	public bool? IsFinished { get; set; }

	public int? cmpNumber { get; set; }

	public string cmpUserName { get; set; }

	public int? FirstRegisterUserId { get; set; }

	public string FirstRegisterUser { get; set; }

	public int? TodayCallCnt { get; set; }

	public int? TodayCallDuration { get; set; }

	public string cnvsDesc { get; set; }

	public string cmpReferUser { get; set; }

	public string cmpSuppUser { get; set; }

	public string Extension { get; set; }

	public string InternalDialTrunkDestination { get; set; }

	public string InternalDialTrunkSource { get; set; }
}
