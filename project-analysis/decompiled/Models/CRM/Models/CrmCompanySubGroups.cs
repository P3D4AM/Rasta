using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(CrmCompanySubGroupsMetadata))]
public class CrmCompanySubGroups
{
	public int CompanySubGroupID { get; set; }

	public int GroupId { get; set; }

	public string SubGroupName { get; set; }

	public string SubGroupDesc { get; set; }

	public int UserId { get; set; }

	public short Year1 { get; set; }

	public short Month1 { get; set; }

	public DateTime RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	public Guid? GUId { get; set; }

	public string AppType { get; set; }

	public int? OrderView { get; set; }

	public int? LanguageID { get; set; }

	public DateTime? FirstRegisterDate { get; set; }

	public int? FirstRegisterUserId { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public double? ScoreRate { get; set; }

	public string LinkAccSubGroupIdStr { get; set; }

	public DateTime? LinkAccFirstTransferDate { get; set; }

	public DateTime? LinkAccLastTransferDate { get; set; }

	public string LinkAccData { get; set; }

	public virtual ICollection<CrmCompanyForbiddenSubGroup> CrmCompanyForbiddenSubGroup { get; set; }

	public virtual CrmCompanyGroups CrmCompanyGroups { get; set; }

	public virtual ICollection<CrmCompanyJustAccessSubGroup> CrmCompanyJustAccessSubGroup { get; set; }

	public virtual ICollection<CrmCompanySubGroups_Lang> CrmCompanySubGroups_Lang { get; set; }

	public virtual Languages Languages { get; set; }

	public virtual ICollection<CrmCompany> CrmCompany { get; set; }

	public virtual ICollection<CrmFoSetting> CrmFoSetting { get; set; }

	public virtual ICollection<CrmFoSettingRegister> CrmFoSettingRegister { get; set; }

	public virtual ICollection<CrmCompanyQuickRegisterDefSetting> CrmCompanyQuickRegisterDefSetting { get; set; }

	public virtual Users Users { get; set; }

	public virtual Users Users1 { get; set; }

	public virtual Users Users2 { get; set; }

	public CrmCompanySubGroups()
	{
		CrmCompanyForbiddenSubGroup = (ICollection<CrmCompanyForbiddenSubGroup>)new HashSet<CrmCompanyForbiddenSubGroup>();
		CrmCompanyJustAccessSubGroup = (ICollection<CrmCompanyJustAccessSubGroup>)new HashSet<CrmCompanyJustAccessSubGroup>();
		CrmCompanySubGroups_Lang = (ICollection<CrmCompanySubGroups_Lang>)new HashSet<CrmCompanySubGroups_Lang>();
		CrmCompany = (ICollection<CrmCompany>)new HashSet<CrmCompany>();
		CrmFoSetting = (ICollection<CrmFoSetting>)new HashSet<CrmFoSetting>();
		CrmFoSettingRegister = (ICollection<CrmFoSettingRegister>)new HashSet<CrmFoSettingRegister>();
		CrmCompanyQuickRegisterDefSetting = (ICollection<CrmCompanyQuickRegisterDefSetting>)new HashSet<CrmCompanyQuickRegisterDefSetting>();
	}
}
