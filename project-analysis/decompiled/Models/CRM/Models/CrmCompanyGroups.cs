using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(CrmCompanyGroupsMetadata))]
public class CrmCompanyGroups
{
	public int CompanyGroupID { get; set; }

	public string GroupName { get; set; }

	public string GroupDesc { get; set; }

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

	public double? ScoreRate { get; set; }

	public string LinkAccGroupIdStr { get; set; }

	public DateTime? LinkAccFirstTransferDate { get; set; }

	public DateTime? LinkAccLastTransferDate { get; set; }

	public string LinkAccData { get; set; }

	public virtual ICollection<CrmCompanyForbiddenGroup> CrmCompanyForbiddenGroup { get; set; }

	public virtual ICollection<CrmCompanyGroups_Lang> CrmCompanyGroups_Lang { get; set; }

	public virtual Languages Languages { get; set; }

	public virtual ICollection<CrmCompanyJustAccessGroup> CrmCompanyJustAccessGroup { get; set; }

	public virtual ICollection<CrmCompanySubGroups> CrmCompanySubGroups { get; set; }

	public virtual ICollection<CrmCompany> CrmCompany { get; set; }

	public virtual ICollection<CrmFoSetting> CrmFoSetting { get; set; }

	public virtual ICollection<CrmFoSettingRegister> CrmFoSettingRegister { get; set; }

	public virtual ICollection<CrmCompanyQuickRegisterDefSetting> CrmCompanyQuickRegisterDefSetting { get; set; }

	public virtual Users Users { get; set; }

	public virtual Users Users1 { get; set; }

	public virtual Users Users2 { get; set; }

	public CrmCompanyGroups()
	{
		CrmCompanyForbiddenGroup = (ICollection<CrmCompanyForbiddenGroup>)new HashSet<CrmCompanyForbiddenGroup>();
		CrmCompanyGroups_Lang = (ICollection<CrmCompanyGroups_Lang>)new HashSet<CrmCompanyGroups_Lang>();
		CrmCompanyJustAccessGroup = (ICollection<CrmCompanyJustAccessGroup>)new HashSet<CrmCompanyJustAccessGroup>();
		CrmCompanySubGroups = (ICollection<CrmCompanySubGroups>)new HashSet<CrmCompanySubGroups>();
		CrmCompany = (ICollection<CrmCompany>)new HashSet<CrmCompany>();
		CrmFoSetting = (ICollection<CrmFoSetting>)new HashSet<CrmFoSetting>();
		CrmFoSettingRegister = (ICollection<CrmFoSettingRegister>)new HashSet<CrmFoSettingRegister>();
		CrmCompanyQuickRegisterDefSetting = (ICollection<CrmCompanyQuickRegisterDefSetting>)new HashSet<CrmCompanyQuickRegisterDefSetting>();
	}
}
