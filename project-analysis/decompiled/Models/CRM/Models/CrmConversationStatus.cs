using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(CrmConversationStatusMetadata))]
public class CrmConversationStatus
{
	public int ConversationStatusID { get; set; }

	public short? StatusOrder { get; set; }

	public string Status { get; set; }

	public string StatusDesc { get; set; }

	public int UserId { get; set; }

	public short Year1 { get; set; }

	public short Month1 { get; set; }

	public DateTime RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	public int? ProgressPercent { get; set; }

	public Guid? GUId { get; set; }

	public int? GroupId { get; set; }

	public string AppType { get; set; }

	public int? LanguageID { get; set; }

	public int? FirstRegisterUserId { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public DateTime? FirstRegisterDate { get; set; }

	public bool? EventPolicyIsActive { get; set; }

	public string SMSBodyPatternFormula { get; set; }

	public bool? SendSMSWeb { get; set; }

	public bool? SendSMSGSM { get; set; }

	public string EmailSubjectPatternFormula { get; set; }

	public string EmailBodyPatternFormula { get; set; }

	public bool? SendEmail { get; set; }

	public bool? SendImmediately { get; set; }

	public int? SendDelayDays { get; set; }

	public bool? SendForAllCmpPersons { get; set; }

	public bool? UserCanCheckBeforeSend { get; set; }

	public bool? ForcedStatus { get; set; }

	public bool? FODefault { get; set; }

	public int? ProcessKindId { get; set; }

	public bool? SendInCnvsAllarmDate { get; set; }

	public int? EmailUserInfoId { get; set; }

	public string SendSMSUserName { get; set; }

	public string SendSMSPassword { get; set; }

	public string SendSMSNumber { get; set; }

	public int? SendSMSProviderId { get; set; }

	public string StatusUsedUserIds { get; set; }

	public string DoingTimeEndCallerCnvsStatusIds { get; set; }

	public bool? NoRegCnvsOlderStatus { get; set; }

	public int? CnvsCountLimit { get; set; }

	public int? CnvsDoingTimeLimit { get; set; }

	public bool? DeActive { get; set; }

	public string StatusColor { get; set; }

	public string IVRLinkRule { get; set; }

	public bool? DeadlineIsActive { get; set; }

	public long? DeadlineMinutes { get; set; }

	public int? DeadlineStartResultId { get; set; }

	public int? DeadlineFinishStatusId { get; set; }

	public int? DeadlineFinishResultId { get; set; }

	public DateTime? DeadlineStartDate { get; set; }

	public string DeadlineStartDatePersian { get; set; }

	public DateTime? DeadlineFinishDate { get; set; }

	public string DeadlineFinishDatePersian { get; set; }

	public virtual ICollection<CrmConversation> CrmConversation { get; set; }

	public virtual ICollection<CrmConversationDefaultContext> CrmConversationDefaultContext { get; set; }

	public virtual ICollection<CrmConversationDefaultContext> CrmConversationDefaultContext1 { get; set; }

	public virtual ICollection<CrmConversationDefaultContext> CrmConversationDefaultContext2 { get; set; }

	public virtual ICollection<CrmConversationDefaultContext> CrmConversationDefaultContext3 { get; set; }

	public virtual ICollection<CrmConversationDefaultContext> CrmConversationDefaultContext4 { get; set; }

	public virtual ICollection<CrmConversationDefaultContext> CrmConversationDefaultContext5 { get; set; }

	public virtual ICollection<CrmConversationDefaultContext> CrmConversationDefaultContext6 { get; set; }

	public virtual ICollection<CrmConversationDefaultContext> CrmConversationDefaultContext7 { get; set; }

	public virtual ICollection<CrmConversationDefaultContext> CrmConversationDefaultContext8 { get; set; }

	public virtual ICollection<CrmConversationDefaultContext> CrmConversationDefaultContext9 { get; set; }

	public virtual ICollection<CrmConversationDefaultContext> CrmConversationDefaultContext10 { get; set; }

	public virtual ICollection<CrmConversationDefaultContext> CrmConversationDefaultContext11 { get; set; }

	public virtual ICollection<CrmConversationDefaultContext> CrmConversationDefaultContext12 { get; set; }

	public virtual ICollection<CrmConversationDefaultContext> CrmConversationDefaultContext13 { get; set; }

	public virtual ICollection<CrmConversationDefaultContext> CrmConversationDefaultContext14 { get; set; }

	public virtual ICollection<CrmConversationDefaultContext> CrmConversationDefaultContext15 { get; set; }

	public virtual ICollection<CrmConversationDefaultContext> CrmConversationDefaultContext16 { get; set; }

	public virtual ICollection<CrmConversationDefaultContext> CrmConversationDefaultContext17 { get; set; }

	public virtual ICollection<CrmConversationDefaultContext> CrmConversationDefaultContext18 { get; set; }

	public virtual ICollection<CrmConversationDefaultContext> CrmConversationDefaultContext19 { get; set; }

	public virtual ICollection<CrmConversationDefaultContext> CrmConversationDefaultContext20 { get; set; }

	public virtual ICollection<CrmConversationDefaultContext> CrmConversationDefaultContext21 { get; set; }

	public virtual ICollection<CrmConversationDefaultContext> CrmConversationDefaultContext22 { get; set; }

	public virtual ICollection<CrmConversationDefaultContext> CrmConversationDefaultContext23 { get; set; }

	public virtual ICollection<CrmConversationDefaultContext> CrmConversationDefaultContext24 { get; set; }

	public virtual ICollection<CrmConversationDefaultContext> CrmConversationDefaultContext25 { get; set; }

	public virtual ICollection<CrmConversationDefaultContext> CrmConversationDefaultContext26 { get; set; }

	public virtual ICollection<CrmConversationDefaultContext> CrmConversationDefaultContext27 { get; set; }

	public virtual ICollection<CrmConversationDefaultContext> CrmConversationDefaultContext28 { get; set; }

	public virtual ICollection<CrmConversationDefaultContext> CrmConversationDefaultContext29 { get; set; }

	public virtual ICollection<CrmConversationDefaultContext> CrmConversationDefaultContext30 { get; set; }

	public virtual ICollection<CrmConversationDefaultContext> CrmConversationDefaultContext31 { get; set; }

	public virtual ICollection<CrmConversationDefaultContext> CrmConversationDefaultContext32 { get; set; }

	public virtual ICollection<CrmConversationDefaultContext> CrmConversationDefaultContext33 { get; set; }

	public virtual ICollection<CrmConversationDefaultContext> CrmConversationDefaultContext34 { get; set; }

	public virtual ICollection<CrmConversationDefaultContext> CrmConversationDefaultContext35 { get; set; }

	public virtual ICollection<CrmConversationDefaultContext> CrmConversationDefaultContext36 { get; set; }

	public virtual ICollection<CrmConversationDefaultContext> CrmConversationDefaultContext37 { get; set; }

	public virtual ICollection<CrmConversationDefaultContext> CrmConversationDefaultContext38 { get; set; }

	public virtual ICollection<CrmConversationDefaultContext> CrmConversationDefaultContext39 { get; set; }

	public virtual ICollection<CrmConversationDefaultContext> CrmConversationDefaultContext40 { get; set; }

	public virtual ICollection<CrmConversationDefaultContext> CrmConversationDefaultContext41 { get; set; }

	public virtual ICollection<CrmConversationDefaultContext> CrmConversationDefaultContext42 { get; set; }

	public virtual ICollection<CrmConversationDefaultContext> CrmConversationDefaultContext43 { get; set; }

	public virtual ICollection<CrmConversationDefaultContext> CrmConversationDefaultContext44 { get; set; }

	public virtual ICollection<CrmConversationDefaultContext> CrmConversationDefaultContext45 { get; set; }

	public virtual ICollection<CrmConversationDefaultContext> CrmConversationDefaultContext46 { get; set; }

	public virtual ICollection<CrmConversationDefaultContext> CrmConversationDefaultContext47 { get; set; }

	public virtual ICollection<CrmConversationDefaultContext> CrmConversationDefaultContext48 { get; set; }

	public virtual ICollection<CrmConversationDefaultContext> CrmConversationDefaultContext49 { get; set; }

	public virtual ICollection<CrmConversationDefaultContext> CrmConversationDefaultContext50 { get; set; }

	public virtual ICollection<CrmConversationDefaultContext> CrmConversationDefaultContext51 { get; set; }

	public virtual ICollection<CrmConversationDefaultContext> CrmConversationDefaultContext52 { get; set; }

	public virtual ICollection<CrmConversationDefaultContext> CrmConversationDefaultContext53 { get; set; }

	public virtual ICollection<CrmConversationDefaultContext> CrmConversationDefaultContext54 { get; set; }

	public virtual ICollection<CrmConversationDefaultContext> CrmConversationDefaultContext55 { get; set; }

	public virtual CrmConversationStatusGroups CrmConversationStatusGroups { get; set; }

	public virtual CrmConversationStatusResult CrmConversationStatusResult { get; set; }

	public virtual ICollection<CrmConversationStatus> CrmConversationStatus1 { get; set; }

	public virtual CrmConversationStatus CrmConversationStatus2 { get; set; }

	public virtual CrmConversationStatusResult CrmConversationStatusResult1 { get; set; }

	public virtual EmailUsersInfo EmailUsersInfo { get; set; }

	public virtual ICollection<CrmConversationStatus_Lang> CrmConversationStatus_Lang { get; set; }

	public virtual Languages Languages { get; set; }

	public virtual SmsProviders SmsProviders { get; set; }

	public virtual ICollection<CrmConversationStatusResult> CrmConversationStatusResult2 { get; set; }

	public virtual ICollection<CrmConversationStatusResult> CrmConversationStatusResult3 { get; set; }

	public virtual ICollection<CrmConversationStatusResultEventPolicy> CrmConversationStatusResultEventPolicy { get; set; }

	public virtual ICollection<CrmFoSetting> CrmFoSetting { get; set; }

	public virtual ICollection<CrmFoSetting> CrmFoSetting1 { get; set; }

	public virtual ICollection<CrmFoSetting> CrmFoSetting2 { get; set; }

	public virtual ICollection<CrmFoSettingRegister> CrmFoSettingRegister { get; set; }

	public virtual ICollection<CrmMobSetting> CrmMobSetting { get; set; }

	public virtual ICollection<CrmMobSetting> CrmMobSetting1 { get; set; }

	public virtual ICollection<CrmMobSetting> CrmMobSetting2 { get; set; }

	public virtual ICollection<CrmMobSetting> CrmMobSetting3 { get; set; }

	public virtual ICollection<CrmMobSetting> CrmMobSetting4 { get; set; }

	public virtual ICollection<CrmMobSetting> CrmMobSetting5 { get; set; }

	public virtual ICollection<CrmMobSetting> CrmMobSetting6 { get; set; }

	public virtual ICollection<CrmMobSetting> CrmMobSetting7 { get; set; }

	public virtual ICollection<WSOrder> WSOrder { get; set; }

	public virtual ICollection<WSPreOrder> WSPreOrder { get; set; }

	public virtual ICollection<WSProducts> WSProducts { get; set; }

	public virtual ICollection<CrmProjects> CrmProjects { get; set; }

	public virtual ICollection<CrmCompanyQuickRegisterDefSetting> CrmCompanyQuickRegisterDefSetting { get; set; }

	public virtual Users Users { get; set; }

	public virtual Users Users1 { get; set; }

	public virtual Users Users2 { get; set; }

	public CrmConversationStatus()
	{
		CrmConversation = (ICollection<CrmConversation>)new HashSet<CrmConversation>();
		CrmConversationDefaultContext = (ICollection<CrmConversationDefaultContext>)new HashSet<CrmConversationDefaultContext>();
		CrmConversationDefaultContext1 = (ICollection<CrmConversationDefaultContext>)new HashSet<CrmConversationDefaultContext>();
		CrmConversationDefaultContext2 = (ICollection<CrmConversationDefaultContext>)new HashSet<CrmConversationDefaultContext>();
		CrmConversationDefaultContext3 = (ICollection<CrmConversationDefaultContext>)new HashSet<CrmConversationDefaultContext>();
		CrmConversationDefaultContext4 = (ICollection<CrmConversationDefaultContext>)new HashSet<CrmConversationDefaultContext>();
		CrmConversationDefaultContext5 = (ICollection<CrmConversationDefaultContext>)new HashSet<CrmConversationDefaultContext>();
		CrmConversationDefaultContext6 = (ICollection<CrmConversationDefaultContext>)new HashSet<CrmConversationDefaultContext>();
		CrmConversationDefaultContext7 = (ICollection<CrmConversationDefaultContext>)new HashSet<CrmConversationDefaultContext>();
		CrmConversationDefaultContext8 = (ICollection<CrmConversationDefaultContext>)new HashSet<CrmConversationDefaultContext>();
		CrmConversationDefaultContext9 = (ICollection<CrmConversationDefaultContext>)new HashSet<CrmConversationDefaultContext>();
		CrmConversationDefaultContext10 = (ICollection<CrmConversationDefaultContext>)new HashSet<CrmConversationDefaultContext>();
		CrmConversationDefaultContext11 = (ICollection<CrmConversationDefaultContext>)new HashSet<CrmConversationDefaultContext>();
		CrmConversationDefaultContext12 = (ICollection<CrmConversationDefaultContext>)new HashSet<CrmConversationDefaultContext>();
		CrmConversationDefaultContext13 = (ICollection<CrmConversationDefaultContext>)new HashSet<CrmConversationDefaultContext>();
		CrmConversationDefaultContext14 = (ICollection<CrmConversationDefaultContext>)new HashSet<CrmConversationDefaultContext>();
		CrmConversationDefaultContext15 = (ICollection<CrmConversationDefaultContext>)new HashSet<CrmConversationDefaultContext>();
		CrmConversationDefaultContext16 = (ICollection<CrmConversationDefaultContext>)new HashSet<CrmConversationDefaultContext>();
		CrmConversationDefaultContext17 = (ICollection<CrmConversationDefaultContext>)new HashSet<CrmConversationDefaultContext>();
		CrmConversationDefaultContext18 = (ICollection<CrmConversationDefaultContext>)new HashSet<CrmConversationDefaultContext>();
		CrmConversationDefaultContext19 = (ICollection<CrmConversationDefaultContext>)new HashSet<CrmConversationDefaultContext>();
		CrmConversationDefaultContext20 = (ICollection<CrmConversationDefaultContext>)new HashSet<CrmConversationDefaultContext>();
		CrmConversationDefaultContext21 = (ICollection<CrmConversationDefaultContext>)new HashSet<CrmConversationDefaultContext>();
		CrmConversationDefaultContext22 = (ICollection<CrmConversationDefaultContext>)new HashSet<CrmConversationDefaultContext>();
		CrmConversationDefaultContext23 = (ICollection<CrmConversationDefaultContext>)new HashSet<CrmConversationDefaultContext>();
		CrmConversationDefaultContext24 = (ICollection<CrmConversationDefaultContext>)new HashSet<CrmConversationDefaultContext>();
		CrmConversationDefaultContext25 = (ICollection<CrmConversationDefaultContext>)new HashSet<CrmConversationDefaultContext>();
		CrmConversationDefaultContext26 = (ICollection<CrmConversationDefaultContext>)new HashSet<CrmConversationDefaultContext>();
		CrmConversationDefaultContext27 = (ICollection<CrmConversationDefaultContext>)new HashSet<CrmConversationDefaultContext>();
		CrmConversationDefaultContext28 = (ICollection<CrmConversationDefaultContext>)new HashSet<CrmConversationDefaultContext>();
		CrmConversationDefaultContext29 = (ICollection<CrmConversationDefaultContext>)new HashSet<CrmConversationDefaultContext>();
		CrmConversationDefaultContext30 = (ICollection<CrmConversationDefaultContext>)new HashSet<CrmConversationDefaultContext>();
		CrmConversationDefaultContext31 = (ICollection<CrmConversationDefaultContext>)new HashSet<CrmConversationDefaultContext>();
		CrmConversationDefaultContext32 = (ICollection<CrmConversationDefaultContext>)new HashSet<CrmConversationDefaultContext>();
		CrmConversationDefaultContext33 = (ICollection<CrmConversationDefaultContext>)new HashSet<CrmConversationDefaultContext>();
		CrmConversationDefaultContext34 = (ICollection<CrmConversationDefaultContext>)new HashSet<CrmConversationDefaultContext>();
		CrmConversationDefaultContext35 = (ICollection<CrmConversationDefaultContext>)new HashSet<CrmConversationDefaultContext>();
		CrmConversationDefaultContext36 = (ICollection<CrmConversationDefaultContext>)new HashSet<CrmConversationDefaultContext>();
		CrmConversationDefaultContext37 = (ICollection<CrmConversationDefaultContext>)new HashSet<CrmConversationDefaultContext>();
		CrmConversationDefaultContext38 = (ICollection<CrmConversationDefaultContext>)new HashSet<CrmConversationDefaultContext>();
		CrmConversationDefaultContext39 = (ICollection<CrmConversationDefaultContext>)new HashSet<CrmConversationDefaultContext>();
		CrmConversationDefaultContext40 = (ICollection<CrmConversationDefaultContext>)new HashSet<CrmConversationDefaultContext>();
		CrmConversationDefaultContext41 = (ICollection<CrmConversationDefaultContext>)new HashSet<CrmConversationDefaultContext>();
		CrmConversationDefaultContext42 = (ICollection<CrmConversationDefaultContext>)new HashSet<CrmConversationDefaultContext>();
		CrmConversationDefaultContext43 = (ICollection<CrmConversationDefaultContext>)new HashSet<CrmConversationDefaultContext>();
		CrmConversationDefaultContext44 = (ICollection<CrmConversationDefaultContext>)new HashSet<CrmConversationDefaultContext>();
		CrmConversationDefaultContext45 = (ICollection<CrmConversationDefaultContext>)new HashSet<CrmConversationDefaultContext>();
		CrmConversationDefaultContext46 = (ICollection<CrmConversationDefaultContext>)new HashSet<CrmConversationDefaultContext>();
		CrmConversationDefaultContext47 = (ICollection<CrmConversationDefaultContext>)new HashSet<CrmConversationDefaultContext>();
		CrmConversationDefaultContext48 = (ICollection<CrmConversationDefaultContext>)new HashSet<CrmConversationDefaultContext>();
		CrmConversationDefaultContext49 = (ICollection<CrmConversationDefaultContext>)new HashSet<CrmConversationDefaultContext>();
		CrmConversationDefaultContext50 = (ICollection<CrmConversationDefaultContext>)new HashSet<CrmConversationDefaultContext>();
		CrmConversationDefaultContext51 = (ICollection<CrmConversationDefaultContext>)new HashSet<CrmConversationDefaultContext>();
		CrmConversationDefaultContext52 = (ICollection<CrmConversationDefaultContext>)new HashSet<CrmConversationDefaultContext>();
		CrmConversationDefaultContext53 = (ICollection<CrmConversationDefaultContext>)new HashSet<CrmConversationDefaultContext>();
		CrmConversationDefaultContext54 = (ICollection<CrmConversationDefaultContext>)new HashSet<CrmConversationDefaultContext>();
		CrmConversationDefaultContext55 = (ICollection<CrmConversationDefaultContext>)new HashSet<CrmConversationDefaultContext>();
		CrmConversationStatus1 = (ICollection<CrmConversationStatus>)new HashSet<CrmConversationStatus>();
		CrmConversationStatus_Lang = (ICollection<CrmConversationStatus_Lang>)new HashSet<CrmConversationStatus_Lang>();
		CrmConversationStatusResult2 = (ICollection<CrmConversationStatusResult>)new HashSet<CrmConversationStatusResult>();
		CrmConversationStatusResult3 = (ICollection<CrmConversationStatusResult>)new HashSet<CrmConversationStatusResult>();
		CrmConversationStatusResultEventPolicy = (ICollection<CrmConversationStatusResultEventPolicy>)new HashSet<CrmConversationStatusResultEventPolicy>();
		CrmFoSetting = (ICollection<CrmFoSetting>)new HashSet<CrmFoSetting>();
		CrmFoSetting1 = (ICollection<CrmFoSetting>)new HashSet<CrmFoSetting>();
		CrmFoSetting2 = (ICollection<CrmFoSetting>)new HashSet<CrmFoSetting>();
		CrmFoSettingRegister = (ICollection<CrmFoSettingRegister>)new HashSet<CrmFoSettingRegister>();
		CrmMobSetting = (ICollection<CrmMobSetting>)new HashSet<CrmMobSetting>();
		CrmMobSetting1 = (ICollection<CrmMobSetting>)new HashSet<CrmMobSetting>();
		CrmMobSetting2 = (ICollection<CrmMobSetting>)new HashSet<CrmMobSetting>();
		CrmMobSetting3 = (ICollection<CrmMobSetting>)new HashSet<CrmMobSetting>();
		CrmMobSetting4 = (ICollection<CrmMobSetting>)new HashSet<CrmMobSetting>();
		CrmMobSetting5 = (ICollection<CrmMobSetting>)new HashSet<CrmMobSetting>();
		CrmMobSetting6 = (ICollection<CrmMobSetting>)new HashSet<CrmMobSetting>();
		CrmMobSetting7 = (ICollection<CrmMobSetting>)new HashSet<CrmMobSetting>();
		WSOrder = (ICollection<WSOrder>)new HashSet<WSOrder>();
		WSPreOrder = (ICollection<WSPreOrder>)new HashSet<WSPreOrder>();
		WSProducts = (ICollection<WSProducts>)new HashSet<WSProducts>();
		CrmProjects = (ICollection<CrmProjects>)new HashSet<CrmProjects>();
		CrmCompanyQuickRegisterDefSetting = (ICollection<CrmCompanyQuickRegisterDefSetting>)new HashSet<CrmCompanyQuickRegisterDefSetting>();
	}
}
