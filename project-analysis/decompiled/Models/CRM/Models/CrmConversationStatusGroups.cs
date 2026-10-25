using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(CrmConversationStatusGroupsMetadata))]
public class CrmConversationStatusGroups
{
	public int ConversationStatusGroupID { get; set; }

	public string ConversationStatusGroup { get; set; }

	public string ConversationStatusGroupDesc { get; set; }

	public int UserId { get; set; }

	public short Year1 { get; set; }

	public short Month1 { get; set; }

	public DateTime RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	public Guid? GUId { get; set; }

	public string AppType { get; set; }

	public int? LanguageID { get; set; }

	public int? FirstRegisterUserId { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public DateTime? FirstRegisterDate { get; set; }

	public int? FOCnvsReferUserId { get; set; }

	public string FOCnvsReferMultiUser { get; set; }

	public bool? NoRegCnvsOlderStatus { get; set; }

	public bool? DeActive { get; set; }

	public string ConversationStatusGroupColor { get; set; }

	public virtual ICollection<CrmConversation> CrmConversation { get; set; }

	public virtual ICollection<CrmConversationStatusGroups_Lang> CrmConversationStatusGroups_Lang { get; set; }

	public virtual Languages Languages { get; set; }

	public virtual ICollection<CrmConversationStatusResultEventPolicy> CrmConversationStatusResultEventPolicy { get; set; }

	public virtual ICollection<CrmProjectCategory> CrmProjectCategory { get; set; }

	public virtual ICollection<CrmProjectTitles> CrmProjectTitles { get; set; }

	public virtual ICollection<CrmConversationStatusSalesFunnelSteps> CrmConversationStatusSalesFunnelSteps { get; set; }

	public virtual ICollection<CrmFoSetting> CrmFoSetting { get; set; }

	public virtual ICollection<CrmFoSetting> CrmFoSetting1 { get; set; }

	public virtual ICollection<CrmMobSetting> CrmMobSetting { get; set; }

	public virtual ICollection<CrmMobSetting> CrmMobSetting1 { get; set; }

	public virtual ICollection<CrmMobSetting> CrmMobSetting2 { get; set; }

	public virtual ICollection<CrmMobSetting> CrmMobSetting3 { get; set; }

	public virtual ICollection<CrmMobSetting> CrmMobSetting4 { get; set; }

	public virtual ICollection<CrmMobSetting> CrmMobSetting5 { get; set; }

	public virtual ICollection<CrmMobSetting> CrmMobSetting6 { get; set; }

	public virtual ICollection<CrmMobSetting> CrmMobSetting7 { get; set; }

	public virtual ICollection<CrmFoSettingRegister> CrmFoSettingRegister { get; set; }

	public virtual ICollection<CrmConversationStatusResult> CrmConversationStatusResult { get; set; }

	public virtual ICollection<WSProducts> WSProducts { get; set; }

	public virtual ICollection<WSProducts> WSProducts1 { get; set; }

	public virtual ICollection<CrmConversationStatus> CrmConversationStatus { get; set; }

	public virtual ICollection<CrmProjects> CrmProjects { get; set; }

	public virtual ICollection<CrmCompanyQuickRegisterDefSetting> CrmCompanyQuickRegisterDefSetting { get; set; }

	public virtual Users Users { get; set; }

	public virtual Users Users1 { get; set; }

	public virtual Users Users2 { get; set; }

	public virtual Users Users3 { get; set; }

	public CrmConversationStatusGroups()
	{
		CrmConversation = (ICollection<CrmConversation>)new HashSet<CrmConversation>();
		CrmConversationStatusGroups_Lang = (ICollection<CrmConversationStatusGroups_Lang>)new HashSet<CrmConversationStatusGroups_Lang>();
		CrmConversationStatusResultEventPolicy = (ICollection<CrmConversationStatusResultEventPolicy>)new HashSet<CrmConversationStatusResultEventPolicy>();
		CrmProjectCategory = (ICollection<CrmProjectCategory>)new HashSet<CrmProjectCategory>();
		CrmProjectTitles = (ICollection<CrmProjectTitles>)new HashSet<CrmProjectTitles>();
		CrmConversationStatusSalesFunnelSteps = (ICollection<CrmConversationStatusSalesFunnelSteps>)new HashSet<CrmConversationStatusSalesFunnelSteps>();
		CrmFoSetting = (ICollection<CrmFoSetting>)new HashSet<CrmFoSetting>();
		CrmFoSetting1 = (ICollection<CrmFoSetting>)new HashSet<CrmFoSetting>();
		CrmMobSetting = (ICollection<CrmMobSetting>)new HashSet<CrmMobSetting>();
		CrmMobSetting1 = (ICollection<CrmMobSetting>)new HashSet<CrmMobSetting>();
		CrmMobSetting2 = (ICollection<CrmMobSetting>)new HashSet<CrmMobSetting>();
		CrmMobSetting3 = (ICollection<CrmMobSetting>)new HashSet<CrmMobSetting>();
		CrmMobSetting4 = (ICollection<CrmMobSetting>)new HashSet<CrmMobSetting>();
		CrmMobSetting5 = (ICollection<CrmMobSetting>)new HashSet<CrmMobSetting>();
		CrmMobSetting6 = (ICollection<CrmMobSetting>)new HashSet<CrmMobSetting>();
		CrmMobSetting7 = (ICollection<CrmMobSetting>)new HashSet<CrmMobSetting>();
		CrmFoSettingRegister = (ICollection<CrmFoSettingRegister>)new HashSet<CrmFoSettingRegister>();
		CrmConversationStatusResult = (ICollection<CrmConversationStatusResult>)new HashSet<CrmConversationStatusResult>();
		WSProducts = (ICollection<WSProducts>)new HashSet<WSProducts>();
		WSProducts1 = (ICollection<WSProducts>)new HashSet<WSProducts>();
		CrmConversationStatus = (ICollection<CrmConversationStatus>)new HashSet<CrmConversationStatus>();
		CrmProjects = (ICollection<CrmProjects>)new HashSet<CrmProjects>();
		CrmCompanyQuickRegisterDefSetting = (ICollection<CrmCompanyQuickRegisterDefSetting>)new HashSet<CrmCompanyQuickRegisterDefSetting>();
	}
}
