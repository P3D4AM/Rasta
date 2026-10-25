using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(CrmCompanyQuickRegisterDefSettingMetadata))]
public class CrmCompanyQuickRegisterDefSetting
{
	public int CompanyQuickRegisterDefSettingId { get; set; }

	public string SettingTitle { get; set; }

	public int? cmpTitleId { get; set; }

	public string cmpActivityType { get; set; }

	public int? cmpGroupId { get; set; }

	public int? cmpSubGroupId { get; set; }

	public int? cmpGroupIdII { get; set; }

	public int? cmpGroupIdIII { get; set; }

	public int? cmpGroupIdIV { get; set; }

	public int? cmpTypeId { get; set; }

	public int? cmpPresentationId { get; set; }

	public int? cmpCityId { get; set; }

	public string cmpSpecialPoint { get; set; }

	public string cmpDescription { get; set; }

	public int? cmpEffectiveDateIncDay { get; set; }

	public int? cmpKind { get; set; }

	public int? prsTitleId { get; set; }

	public int? prsJobId { get; set; }

	public int? prsTypeId { get; set; }

	public int? prsGroupId { get; set; }

	public int? prsSexId { get; set; }

	public int? prsEducationId { get; set; }

	public int? prsCityId { get; set; }

	public string prsSpecialPoint { get; set; }

	public string prsDescription { get; set; }

	public int? prsDepartmentId { get; set; }

	public string prjTitle { get; set; }

	public string prjDesc { get; set; }

	public int? prjGradeId { get; set; }

	public int? prjPriorityId { get; set; }

	public int? prjGroupId { get; set; }

	public int? prjcnvsStatusGroupId { get; set; }

	public string prjPostFix { get; set; }

	public int? prjRemindDateIncDay { get; set; }

	public bool? prjFOCmpCanSee { get; set; }

	public string prjSubject { get; set; }

	public string prjTitleGroup { get; set; }

	public int? prjCategoryId { get; set; }

	public string prjDescI { get; set; }

	public int? cnvsTopicId { get; set; }

	public string cnvsDesc { get; set; }

	public string cnvsReferDesc { get; set; }

	public int? cnvsStatusId { get; set; }

	public int? cnvsPriorityId { get; set; }

	public int? cnvsRemindDateIncDay { get; set; }

	public string cnvsRemindTime { get; set; }

	public int? cnvsRemindDateForAllarmIncDay { get; set; }

	public bool? cnvsFOCmpCanSee { get; set; }

	public bool? IsDefault { get; set; }

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

	public bool? IsDefaultForCmpInfo { get; set; }

	public bool? IsDefIssueQuickOrder { get; set; }

	public int? prjpordDefaultSettingId { get; set; }

	public int? prjordDefaultSettingId { get; set; }

	public string cmpLocationLat { get; set; }

	public string cmpLocationLong { get; set; }

	public double? cmpLocationZoom { get; set; }

	public string prsLocationLat { get; set; }

	public string prsLocationLong { get; set; }

	public double? prsLocationZoom { get; set; }

	public bool? InActive { get; set; }

	public string AccessUserJson { get; set; }

	public bool? ActiveInQuickOrder { get; set; }

	public short? PublicMode { get; set; }

	public virtual City City { get; set; }

	public virtual City City1 { get; set; }

	public virtual ICollection<CrmCompany> CrmCompany { get; set; }

	public virtual CrmCompanyGroups CrmCompanyGroups { get; set; }

	public virtual CrmCompanyGroupsII CrmCompanyGroupsII { get; set; }

	public virtual CrmCompanyGroupsIII CrmCompanyGroupsIII { get; set; }

	public virtual CrmCompanyGroupsIV CrmCompanyGroupsIV { get; set; }

	public virtual CrmCompanyPresentation CrmCompanyPresentation { get; set; }

	public virtual CrmCompanySubGroups CrmCompanySubGroups { get; set; }

	public virtual CrmCompanyTitle CrmCompanyTitle { get; set; }

	public virtual CrmCompanyType CrmCompanyType { get; set; }

	public virtual CrmConversationPriority CrmConversationPriority { get; set; }

	public virtual CrmConversationStatus CrmConversationStatus { get; set; }

	public virtual CrmConversationStatusGroups CrmConversationStatusGroups { get; set; }

	public virtual CrmConversationTopics CrmConversationTopics { get; set; }

	public virtual CrmPersonDepartments CrmPersonDepartments { get; set; }

	public virtual CrmPersonGroups CrmPersonGroups { get; set; }

	public virtual CrmPersonJobs CrmPersonJobs { get; set; }

	public virtual CrmPersonTitle CrmPersonTitle { get; set; }

	public virtual CrmPersonType CrmPersonType { get; set; }

	public virtual CrmProjectCategory CrmProjectCategory { get; set; }

	public virtual CrmProjectGrade CrmProjectGrade { get; set; }

	public virtual CrmProjectGroups CrmProjectGroups { get; set; }

	public virtual CrmProjectPriority CrmProjectPriority { get; set; }

	public virtual Education Education { get; set; }

	public virtual ICollection<CrmCompanyQuickRegisterDefSetting_Lang> CrmCompanyQuickRegisterDefSetting_Lang { get; set; }

	public virtual Languages Languages { get; set; }

	public virtual Sex Sex { get; set; }

	public virtual WSOrderDefaultSetting WSOrderDefaultSetting { get; set; }

	public virtual WSPreOrderDefaultSetting WSPreOrderDefaultSetting { get; set; }

	public virtual ICollection<CrmProjects> CrmProjects { get; set; }

	public virtual ICollection<WSOrder> WSOrder { get; set; }

	public virtual ICollection<WSOrderDefaultSetting> WSOrderDefaultSetting1 { get; set; }

	public virtual ICollection<WSPreOrder> WSPreOrder { get; set; }

	public virtual ICollection<WSPreOrderDefaultSetting> WSPreOrderDefaultSetting1 { get; set; }

	public virtual Users Users { get; set; }

	public virtual Users Users1 { get; set; }

	public CrmCompanyQuickRegisterDefSetting()
	{
		CrmCompany = (ICollection<CrmCompany>)new HashSet<CrmCompany>();
		CrmCompanyQuickRegisterDefSetting_Lang = (ICollection<CrmCompanyQuickRegisterDefSetting_Lang>)new HashSet<CrmCompanyQuickRegisterDefSetting_Lang>();
		CrmProjects = (ICollection<CrmProjects>)new HashSet<CrmProjects>();
		WSOrder = (ICollection<WSOrder>)new HashSet<WSOrder>();
		WSOrderDefaultSetting1 = (ICollection<WSOrderDefaultSetting>)new HashSet<WSOrderDefaultSetting>();
		WSPreOrder = (ICollection<WSPreOrder>)new HashSet<WSPreOrder>();
		WSPreOrderDefaultSetting1 = (ICollection<WSPreOrderDefaultSetting>)new HashSet<WSPreOrderDefaultSetting>();
	}
}
