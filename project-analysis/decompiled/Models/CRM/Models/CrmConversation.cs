using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(CrmConversationMetadata))]
public class CrmConversation
{
	public int ConversationID { get; set; }

	public int? cnvsProjectId { get; set; }

	public int cnvsCompanyId { get; set; }

	public string cnvsDate { get; set; }

	public string cnvsDay { get; set; }

	public string cnvsTime { get; set; }

	public int? cnvsTopicId { get; set; }

	public string cnvsSubject { get; set; }

	public string cnvsDesc { get; set; }

	public int? cnvsPersonId { get; set; }

	public int? cnvsUserId { get; set; }

	public int? cnvsReferUserId { get; set; }

	public string cnvsReferDesc { get; set; }

	public int? cnvsStatusId { get; set; }

	public int? cnvsPriorityId { get; set; }

	public string cnvsRemindDate { get; set; }

	public string cnvsRemindTime { get; set; }

	public bool? cnvsRemindOk { get; set; }

	public bool? cnvsIsBookMark { get; set; }

	public int? cnvsFirstRegisterUserId { get; set; }

	public string cnvsFirstRegisterDate { get; set; }

	public int UserId { get; set; }

	public short Year1 { get; set; }

	public short Month1 { get; set; }

	public DateTime RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	public DateTime? FirstRegisterDate { get; set; }

	public Guid? GUId { get; set; }

	public string cnvsRemindDateForAllarm { get; set; }

	public string AppType { get; set; }

	public DateTime? cnvsDateTime { get; set; }

	public DateTime? cnvsRemindDateTime { get; set; }

	public DateTime? cnvsFirstRegisterDateTime { get; set; }

	public DateTime? cnvsRemindDateTimeForAllarm { get; set; }

	public int? LanguageID { get; set; }

	public int? FirstRegisterUserId { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public string ApiId { get; set; }

	public bool? cnvsFOCmpCanSee { get; set; }

	public bool? cnvsIsTicket { get; set; }

	public string cnvsCoordinateLatitude { get; set; }

	public string cnvsCoordinateLongitude { get; set; }

	public DateTime? cnvsCoordinateLastDate { get; set; }

	public string cnvsCoordinateLastDatePersian { get; set; }

	public bool? cnvsTicketIsRead { get; set; }

	public TimeSpan? cnvsDoingTime { get; set; }

	public bool? cnvsIsCopy { get; set; }

	public bool? cnvsIsTicketNew { get; set; }

	public long? cnvsDoingTimeSec { get; set; }

	public int? cnvsStatusProcessKindId { get; set; }

	public int? cnvsStatusGroupId { get; set; }

	public int? cnvsHappyVote { get; set; }

	public int? cnvsStatusResultId { get; set; }

	public DateTime? cnvsStatusResultDoingTimeEndDate { get; set; }

	public TimeSpan? cnvsDoingTimeFrom { get; set; }

	public TimeSpan? cnvsDoingTimeTo { get; set; }

	public string cnvsKnowledgeTankIds { get; set; }

	public int? cnvsCId { get; set; }

	public string cnvsJs { get; set; }

	public virtual ICollection<CrmCallHistory> CrmCallHistory { get; set; }

	public virtual CrmCompanyPersons CrmCompanyPersons { get; set; }

	public virtual CrmConversationPriority CrmConversationPriority { get; set; }

	public virtual CrmConversationTopics CrmConversationTopics { get; set; }

	public virtual ICollection<CrmConversation_Lang> CrmConversation_Lang { get; set; }

	public virtual Languages Languages { get; set; }

	public virtual ICollection<CrmConversationReferUsers> CrmConversationReferUsers { get; set; }

	public virtual ICollection<CrmDyFormFieldMasterValues> CrmDyFormFieldMasterValues { get; set; }

	public virtual ICollection<CrmDyFormFieldValues> CrmDyFormFieldValues { get; set; }

	public virtual CrmConversationStatusGroups CrmConversationStatusGroups { get; set; }

	public virtual CrmCompany CrmCompany { get; set; }

	public virtual Centers Centers { get; set; }

	public virtual CrmConversationStatusResult CrmConversationStatusResult { get; set; }

	public virtual CrmConversationStatus CrmConversationStatus { get; set; }

	public virtual CrmProjects CrmProjects { get; set; }

	public virtual Users Users { get; set; }

	public virtual Users Users1 { get; set; }

	public virtual Users Users2 { get; set; }

	public virtual Users Users3 { get; set; }

	public virtual Users Users4 { get; set; }

	public CrmConversation()
	{
		CrmCallHistory = (ICollection<CrmCallHistory>)new HashSet<CrmCallHistory>();
		CrmConversation_Lang = (ICollection<CrmConversation_Lang>)new HashSet<CrmConversation_Lang>();
		CrmConversationReferUsers = (ICollection<CrmConversationReferUsers>)new HashSet<CrmConversationReferUsers>();
		CrmDyFormFieldMasterValues = (ICollection<CrmDyFormFieldMasterValues>)new HashSet<CrmDyFormFieldMasterValues>();
		CrmDyFormFieldValues = (ICollection<CrmDyFormFieldValues>)new HashSet<CrmDyFormFieldValues>();
	}
}
