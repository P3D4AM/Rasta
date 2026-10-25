using System;
using System.ComponentModel.DataAnnotations;
using CRM.Resources;

namespace CRM.Models;

public class CrmConversationLanguageViewModel
{
	[Key]
	[Display(ResourceType = typeof(Labels), Name = "cnvsConversationID")]
	public int ConversationID { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsProjectId")]
	public int? cnvsProjectId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsCompanyId")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	public int cnvsCompanyId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsDate")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	[MaxLength(8, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(8, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string cnvsDate { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsDay")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	[MaxLength(20, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(20, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string cnvsDay { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsTime")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	[MaxLength(15, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(15, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string cnvsTime { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsTopicId")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	public int? cnvsTopicId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsSubject")]
	[MaxLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string cnvsSubject { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsDesc")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	[MaxLength(10000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(10000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string cnvsDesc { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsPersonId")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	public int? cnvsPersonId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsUserId")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	public int? cnvsUserId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsReferUserId")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	public int? cnvsReferUserId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsReferDesc")]
	[MaxLength(500, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(500, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string cnvsReferDesc { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsStatusId")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	public int? cnvsStatusId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsPriorityId")]
	public int? cnvsPriorityId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsRemindDate")]
	[MaxLength(8, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(8, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string cnvsRemindDate { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsRemindTime")]
	[MaxLength(15, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(15, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string cnvsRemindTime { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsRemindOk")]
	public bool? cnvsRemindOk { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsIsBookMark")]
	public bool? cnvsIsBookMark { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsFirstRegisterUserId")]
	public int? cnvsFirstRegisterUserId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsFirstRegisterDate")]
	[MaxLength(8, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(8, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string cnvsFirstRegisterDate { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsRemindDateForAllarm")]
	[MaxLength(8, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(8, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string cnvsRemindDateForAllarm { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsFirstRegisterDate")]
	public DateTime? FirstRegisterDate { get; set; }

	public int UserId { get; set; }

	public short Year1 { get; set; }

	public short Month1 { get; set; }

	public DateTime RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	public Guid? GUId { get; set; }

	public string AppType { get; set; }

	public DateTime? cnvsDateTime { get; set; }

	public DateTime? cnvsRemindDateTime { get; set; }

	public DateTime? cnvsFirstRegisterDateTime { get; set; }

	public DateTime? cnvsRemindDateTimeForAllarm { get; set; }

	public int? LanguageID { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsFOCmpCanSee")]
	public bool? cnvsFOCmpCanSee { get; set; }

	public bool? cnvsIsTicket { get; set; }

	public string AppTypeHelp { get; set; }

	public bool? prjFOCmpCanSee { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsDoingTime")]
	public TimeSpan? cnvsDoingTime { get; set; }

	public int? cnvsDoingHour { get; set; }

	public int? cnvsDoingMin { get; set; }

	public long? cnvsDoingTimeSec { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsIsCopy")]
	public bool? cnvsIsCopy { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsCallHistoryIds")]
	public string CallHistoryIds { get; set; }

	public string CallHistoryStr { get; set; }

	public string CallHistoryIdsFromDailyTel { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsQuickRegisterDefSettingId")]
	public int? CompanyQuickRegisterDefSettingId { get; set; }

	public string cnvsSubject_Lang { get; set; }

	public string cnvsDesc_Lang { get; set; }

	public string cnvsReferDesc_Lang { get; set; }

	public string cnvsCompanyName { get; set; }

	public string cnvsProjectTitle { get; set; }

	public int? cnvsStatusGroupId { get; set; }

	public string cnvsLastStatus { get; set; }

	public string cnvsLastUser { get; set; }

	public string cnvsLastReferUser { get; set; }

	public string FirstRegisterUser { get; set; }

	public string FirstRegisterInfoDate { get; set; }

	public string RegisterUser { get; set; }

	public string RegisterInfoDate { get; set; }

	public string AppTypeInfo { get; set; }

	public bool IsCloseTicket { get; set; }

	public int? cnvsStatusProcessKindId { get; set; }

	public int? FromPosition { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsPrjTicketStop")]
	public bool? prjTicketStop { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsHappyVote")]
	public int? cnvsHappyVote { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsStatusResultId")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	public int? cnvsStatusResultId { get; set; }

	public DateTime? cnvsStatusResultDoingTimeEndDate { get; set; }

	public string ProjectProductHistoryJson { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsDoingTimeFrom")]
	public TimeSpan? cnvsDoingTimeFrom { get; set; }

	public int? cnvsDoingTimeFromHour { get; set; }

	public int? cnvsDoingTimeFromMin { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsDoingTimeTo")]
	public TimeSpan? cnvsDoingTimeTo { get; set; }

	public int? cnvsDoingTimeToHour { get; set; }

	public int? cnvsDoingTimeToMin { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsKnowledgeTankIds")]
	public string cnvsKnowledgeTankIds { get; set; }

	public string cnvsKnowledgeTankJson { get; set; }

	public int? PrjFirstCnvsUserId { get; set; }

	public int? LastCnvsPersonId { get; set; }

	public int? CmpReferUserId { get; set; }

	public int? CmpSuppUserId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsIsCopyRemindDate")]
	public bool? cnvsIsCopyRemindDate { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsIsCopyRemindDateForAllarm")]
	public bool? cnvsIsCopyRemindDateForAllarm { get; set; }

	public int? cnvsCId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsDyFormId")]
	public int? SysPartDyFormId { get; set; }

	public string SysPartDyFormVal { get; set; }
}
