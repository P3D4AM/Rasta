using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using CRM.Resources;

namespace CRM.Models;

public class CrmConversationStatusResultLanguageViewModel
{
	[Key]
	public int ConversationStatusResultId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsStatusResultStatusGroupId")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	public int ConversationStatusGroupId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsStatusResultStatusId")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	public int ConversationStatusId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsStatusResultTitle")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	[MaxLength(100, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(100, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string ResultTitle { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsStatusResultDesc")]
	[MaxLength(2000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(2000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string ResultDesc { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsStatusResultEventPolicyActive")]
	public bool? EventPolicyActive { get; set; }

	[UIHint("RichText")]
	[AllowHtml]
	public string EventPolicyJson { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsStatusResultOTPSendActive")]
	public bool? OTPSendActive { get; set; }

	[UIHint("RichText")]
	[AllowHtml]
	public string OTPJson { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsStatusResultIssuePordActive")]
	public bool? IssuePordActive { get; set; }

	[UIHint("RichText")]
	[AllowHtml]
	public string IssuePordJson { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsStatusResultIssueOrdActive")]
	public bool? IssueOrdActive { get; set; }

	[UIHint("RichText")]
	[AllowHtml]
	public string IssueOrdJson { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsStatusResultIssueDyFormActive")]
	public bool? IssueDyFormActive { get; set; }

	[UIHint("RichText")]
	[AllowHtml]
	public string IssueDyFormJson { get; set; }

	[UIHint("RichText")]
	[AllowHtml]
	public string FOJson { get; set; }

	[UIHint("RichText")]
	[AllowHtml]
	public string ShpJson { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsStatusResultAddPrjActive")]
	public bool? AddPrjActive { get; set; }

	[UIHint("RichText")]
	[AllowHtml]
	public string AddPrjJson { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsStatusResultNoNeedRemindDateAlert")]
	public bool? CnvsNoNeedRemindDateAlert { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsStatusResultNeedDyFormChecked")]
	public bool? NeedDyFormChecked { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsStatusResultNeedDyFormChecked")]
	public int? NeedDyFormCheckedFormId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsStatusResultPrjFinished")]
	public bool? PrjFinished { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsStatusResultNoCnvsDup")]
	public bool? NoCnvsDup { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsStatusResultStatusResultUsedUserNames")]
	public string StatusResultUsedUserIds { get; set; }

	public string StatusResultUsedUsersjson { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsStatusResultDoingTimeEndDeadlineMin")]
	public int? DoingTimeEndDeadlineMin { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsStatusResultDoingTimeEndCnvsStatus")]
	public int? DoingTimeEndCnvsStatusId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsStatusResultDoingTimeEndCnvsStatusResult")]
	public int? DoingTimeEndCnvsStatusResultId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsStatusResultCnvsCountLimit")]
	public int? CnvsCountLimit { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsStatusResultCnvsDoingTimeLimit")]
	public int? CnvsDoingTimeLimit { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsStatusResultCnvsDoingTimeNotNull")]
	public bool? CnvsDoingTimeNotNull { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsStatusResultCnvsRemindDateNotNull")]
	public bool? CnvsRemindDateNotNull { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsStatusResultCnvsRemindDateForAllarmNotNull")]
	public bool? CnvsRemindDateForAllarmNotNull { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsStatusResultCnvsTopic")]
	public int? CnvsTopicId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsStatusResultCnvsReferUser")]
	public int? CnvsReferUserId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsStatusResultCnvsReferUserNoChange")]
	public bool? CnvsReferUserNoChange { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsStatusResultCnvsRemindDay")]
	public int? CnvsRemindDay { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsStatusResultCnvsDesc")]
	[MaxLength(4000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(4000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string CnvsDesc { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsStatusResultCnvsReferDesc")]
	[MaxLength(500, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(500, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string CnvsReferDesc { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsStatusResultIsDefault")]
	public bool? IsDefault { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsStatusResultDeActive")]
	public bool? DeActive { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsStatusResultOrderView")]
	public int? OrderView { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsStatusResultUpdateCmpGroupActive")]
	public bool? UpdateCmpGroupActive { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsStatusResultCmpGroup")]
	public int? CmpGroupId { get; set; }

	public bool? IsUpdateCmpGroup { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsStatusResultCmpSubGroup")]
	public int? CmpSubGroupId { get; set; }

	public bool? IsUpdateCmpSubGroup { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsStatusResultCmpGroupII")]
	public int? CmpGroupIIId { get; set; }

	public bool? IsUpdateCmpGroupII { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsStatusResultCmpGroupIII")]
	public int? CmpGroupIIIId { get; set; }

	public bool? IsUpdateCmpGroupIII { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsStatusResultCmpGroupIV")]
	public int? CmpGroupIVId { get; set; }

	public bool? IsUpdateCmpGroupIV { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsStatusResultCmpType")]
	public int? CmpTypeId { get; set; }

	public bool? IsUpdateCmpType { get; set; }

	public string UpdateCmpGroupActiveJson { get; set; }

	public string FirstRegisterUser { get; set; }

	public string EditUser { get; set; }

	public int FirstRegisterUserId { get; set; }

	public DateTime FirstRegisterDate { get; set; }

	public int UserId { get; set; }

	public DateTime RegisterDate { get; set; }

	public string AppType { get; set; }

	public string ResultTitle_Lang { get; set; }

	public string ResultDesc_Lang { get; set; }

	public string CnvsDesc_Lang { get; set; }

	public string CnvsReferDesc_Lang { get; set; }
}
