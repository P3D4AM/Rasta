using System;
using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(CrmCallHistoryMetadata))]
public class CrmCallHistory
{
	public int CallHistoryID { get; set; }

	public int CallTypeId { get; set; }

	public string PhoneNumber { get; set; }

	public int? CompanyID { get; set; }

	public string CallTime { get; set; }

	public string CallDate { get; set; }

	public string CallDay { get; set; }

	public int UserID { get; set; }

	public short Year1 { get; set; }

	public short Month1 { get; set; }

	public DateTime RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	public int? LineNumber { get; set; }

	public string CallerIDDetectData { get; set; }

	public Guid? GUId { get; set; }

	public string StartTime { get; set; }

	public string EndTime { get; set; }

	public string Duration { get; set; }

	public int? CompanyPersonId { get; set; }

	public int? NumberEditedUserId { get; set; }

	public string Note { get; set; }

	public int? NoteRegisterUserId { get; set; }

	public int? NoteEditedUserId { get; set; }

	public string RecFileName { get; set; }

	public string AppType { get; set; }

	public string Data { get; set; }

	public int? LanguageID { get; set; }

	public int? FirstRegisterUserId { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public DateTime? FirstRegisterDate { get; set; }

	public DateTime? CallDateTime { get; set; }

	public string TrunkCallId { get; set; }

	public string TrunkName { get; set; }

	public string TrunkSource { get; set; }

	public string TrunkDestination { get; set; }

	public string TrunkFileLocation { get; set; }

	public string TrunkDestinationCycle { get; set; }

	public string PreRecFileName { get; set; }

	public int? DevType { get; set; }

	public int? ConversationID { get; set; }

	public string IVRAuthResult { get; set; }

	public string TrunkCallIds { get; set; }

	public bool? IsFinished { get; set; }

	public int? TodayCallCnt { get; set; }

	public int? TodayCallDuration { get; set; }

	public string AnsweredUserIds { get; set; }

	public virtual CrmCallType CrmCallType { get; set; }

	public virtual CrmCompanyPersons CrmCompanyPersons { get; set; }

	public virtual CrmConversation CrmConversation { get; set; }

	public virtual Languages Languages { get; set; }

	public virtual CrmCompany CrmCompany { get; set; }

	public virtual Users Users { get; set; }

	public virtual Users Users1 { get; set; }

	public virtual Users Users2 { get; set; }

	public virtual Users Users3 { get; set; }

	public virtual Users Users4 { get; set; }
}
