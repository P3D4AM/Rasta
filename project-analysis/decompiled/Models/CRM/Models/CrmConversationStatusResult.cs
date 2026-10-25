using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(CrmConversationStatusResultMetadata))]
public class CrmConversationStatusResult
{
	public int ConversationStatusResultId { get; set; }

	public int? ConversationStatusGroupId { get; set; }

	public int? ConversationStatusId { get; set; }

	public string ResultTitle { get; set; }

	public string ResultDesc { get; set; }

	public bool? EventPolicyActive { get; set; }

	public bool? OTPSendActive { get; set; }

	public bool? IssuePordActive { get; set; }

	public bool? IssueOrdActive { get; set; }

	public bool? IssueDyFormActive { get; set; }

	public bool? NeedDyFormChecked { get; set; }

	public int? NeedDyFormCheckedFormId { get; set; }

	public bool? PrjFinished { get; set; }

	public bool? NoCnvsDup { get; set; }

	public string StatusResultUsedUserIds { get; set; }

	public int? DoingTimeEndDeadlineMin { get; set; }

	public int? DoingTimeEndCnvsStatusId { get; set; }

	public int? DoingTimeEndCnvsStatusResultId { get; set; }

	public string DoingTimeEndCallerCnvsStatusResultIds { get; set; }

	public int? CnvsCountLimit { get; set; }

	public int? CnvsDoingTimeLimit { get; set; }

	public bool? CnvsDoingTimeNotNull { get; set; }

	public bool? CnvsRemindDateNotNull { get; set; }

	public bool? CnvsRemindDateForAllarmNotNull { get; set; }

	public int? CnvsTopicId { get; set; }

	public int? CnvsReferUserId { get; set; }

	public bool? CnvsReferUserNoChange { get; set; }

	public int? CnvsRemindDay { get; set; }

	public string CnvsDesc { get; set; }

	public string CnvsReferDesc { get; set; }

	public bool? UpdateCmpGroupActive { get; set; }

	public string UpdateCmpGroupActiveJson { get; set; }

	public bool? IsDefault { get; set; }

	public bool? DeActive { get; set; }

	public int? OrderView { get; set; }

	public int FirstRegisterUserId { get; set; }

	public DateTime FirstRegisterDate { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public int UserId { get; set; }

	public short Year1 { get; set; }

	public short Month1 { get; set; }

	public DateTime RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	public Guid GUId { get; set; }

	public string AppType { get; set; }

	public int LanguageID { get; set; }

	public bool? AddPrjActive { get; set; }

	public bool? CnvsNoNeedRemindDateAlert { get; set; }

	public virtual ICollection<CrmConversation> CrmConversation { get; set; }

	public virtual CrmConversationStatusGroups CrmConversationStatusGroups { get; set; }

	public virtual CrmConversationTopics CrmConversationTopics { get; set; }

	public virtual CrmDyForms CrmDyForms { get; set; }

	public virtual ICollection<CrmConversationStatusResult_Lang> CrmConversationStatusResult_Lang { get; set; }

	public virtual Languages Languages { get; set; }

	public virtual ICollection<CrmConversationStatusResultEventPolicy> CrmConversationStatusResultEventPolicy { get; set; }

	public virtual ICollection<WSProducts> WSProducts { get; set; }

	public virtual ICollection<CrmFoSetting> CrmFoSetting { get; set; }

	public virtual ICollection<CrmFoSetting> CrmFoSetting1 { get; set; }

	public virtual ICollection<CrmFoSettingRegister> CrmFoSettingRegister { get; set; }

	public virtual ICollection<CrmConversationStatus> CrmConversationStatus { get; set; }

	public virtual ICollection<CrmConversationStatus> CrmConversationStatus1 { get; set; }

	public virtual CrmConversationStatus CrmConversationStatus2 { get; set; }

	public virtual CrmConversationStatus CrmConversationStatus3 { get; set; }

	public virtual Users Users { get; set; }

	public virtual Users Users1 { get; set; }

	public virtual Users Users2 { get; set; }

	public CrmConversationStatusResult()
	{
		CrmConversation = (ICollection<CrmConversation>)new HashSet<CrmConversation>();
		CrmConversationStatusResult_Lang = (ICollection<CrmConversationStatusResult_Lang>)new HashSet<CrmConversationStatusResult_Lang>();
		CrmConversationStatusResultEventPolicy = (ICollection<CrmConversationStatusResultEventPolicy>)new HashSet<CrmConversationStatusResultEventPolicy>();
		WSProducts = (ICollection<WSProducts>)new HashSet<WSProducts>();
		CrmFoSetting = (ICollection<CrmFoSetting>)new HashSet<CrmFoSetting>();
		CrmFoSetting1 = (ICollection<CrmFoSetting>)new HashSet<CrmFoSetting>();
		CrmFoSettingRegister = (ICollection<CrmFoSettingRegister>)new HashSet<CrmFoSettingRegister>();
		CrmConversationStatus = (ICollection<CrmConversationStatus>)new HashSet<CrmConversationStatus>();
		CrmConversationStatus1 = (ICollection<CrmConversationStatus>)new HashSet<CrmConversationStatus>();
	}
}
