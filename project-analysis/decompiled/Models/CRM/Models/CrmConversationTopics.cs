using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(CrmConversationTopicsMetadata))]
public class CrmConversationTopics
{
	public int ConversationTopicsID { get; set; }

	public short? TopicOrder { get; set; }

	public string Topic { get; set; }

	public string TopicDesc { get; set; }

	public int UserId { get; set; }

	public short Year1 { get; set; }

	public short Month1 { get; set; }

	public DateTime RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	public Guid? GUId { get; set; }

	public string AppType { get; set; }

	public int? OrderView { get; set; }

	public int? LanguageID { get; set; }

	public int? FirstRegisterUserId { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public DateTime? FirstRegisterDate { get; set; }

	public bool? FODefault { get; set; }

	public bool? CheckUserDistanceCmp { get; set; }

	public double? UserDistanceCmpVal { get; set; }

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

	public virtual ICollection<CrmConversationTopics_Lang> CrmConversationTopics_Lang { get; set; }

	public virtual Languages Languages { get; set; }

	public virtual ICollection<CrmsysSetting> CrmsysSetting { get; set; }

	public virtual ICollection<CrmsysSetting> CrmsysSetting1 { get; set; }

	public virtual ICollection<CrmFoSetting> CrmFoSetting { get; set; }

	public virtual ICollection<CrmFoSetting> CrmFoSetting1 { get; set; }

	public virtual ICollection<CrmFoSetting> CrmFoSetting2 { get; set; }

	public virtual ICollection<CrmFoSetting> CrmFoSetting3 { get; set; }

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

	public virtual ICollection<CrmCompanyQuickRegisterDefSetting> CrmCompanyQuickRegisterDefSetting { get; set; }

	public virtual Users Users { get; set; }

	public virtual Users Users1 { get; set; }

	public virtual Users Users2 { get; set; }

	public CrmConversationTopics()
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
		CrmConversationTopics_Lang = (ICollection<CrmConversationTopics_Lang>)new HashSet<CrmConversationTopics_Lang>();
		CrmsysSetting = (ICollection<CrmsysSetting>)new HashSet<CrmsysSetting>();
		CrmsysSetting1 = (ICollection<CrmsysSetting>)new HashSet<CrmsysSetting>();
		CrmFoSetting = (ICollection<CrmFoSetting>)new HashSet<CrmFoSetting>();
		CrmFoSetting1 = (ICollection<CrmFoSetting>)new HashSet<CrmFoSetting>();
		CrmFoSetting2 = (ICollection<CrmFoSetting>)new HashSet<CrmFoSetting>();
		CrmFoSetting3 = (ICollection<CrmFoSetting>)new HashSet<CrmFoSetting>();
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
		CrmCompanyQuickRegisterDefSetting = (ICollection<CrmCompanyQuickRegisterDefSetting>)new HashSet<CrmCompanyQuickRegisterDefSetting>();
	}
}
