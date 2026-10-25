using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(CrmCompanyGroupsIVMetadata))]
public class CrmCompanyGroupsIV
{
	public int CompanyGroupIVID { get; set; }

	public string GroupIVName { get; set; }

	public string GroupIVDesc { get; set; }

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

	public virtual ICollection<CrmCompanyForbiddenGroupIV> CrmCompanyForbiddenGroupIV { get; set; }

	public virtual ICollection<CrmCompanyGroupsIV_Lang> CrmCompanyGroupsIV_Lang { get; set; }

	public virtual Languages Languages { get; set; }

	public virtual ICollection<CrmCompanyJustAccessGroupIV> CrmCompanyJustAccessGroupIV { get; set; }

	public virtual ICollection<CrmCompany> CrmCompany { get; set; }

	public virtual ICollection<CrmFoSetting> CrmFoSetting { get; set; }

	public virtual ICollection<CrmFoSettingRegister> CrmFoSettingRegister { get; set; }

	public virtual ICollection<CrmCompanyQuickRegisterDefSetting> CrmCompanyQuickRegisterDefSetting { get; set; }

	public virtual Users Users { get; set; }

	public virtual Users Users1 { get; set; }

	public virtual Users Users2 { get; set; }

	public CrmCompanyGroupsIV()
	{
		CrmCompanyForbiddenGroupIV = (ICollection<CrmCompanyForbiddenGroupIV>)new HashSet<CrmCompanyForbiddenGroupIV>();
		CrmCompanyGroupsIV_Lang = (ICollection<CrmCompanyGroupsIV_Lang>)new HashSet<CrmCompanyGroupsIV_Lang>();
		CrmCompanyJustAccessGroupIV = (ICollection<CrmCompanyJustAccessGroupIV>)new HashSet<CrmCompanyJustAccessGroupIV>();
		CrmCompany = (ICollection<CrmCompany>)new HashSet<CrmCompany>();
		CrmFoSetting = (ICollection<CrmFoSetting>)new HashSet<CrmFoSetting>();
		CrmFoSettingRegister = (ICollection<CrmFoSettingRegister>)new HashSet<CrmFoSettingRegister>();
		CrmCompanyQuickRegisterDefSetting = (ICollection<CrmCompanyQuickRegisterDefSetting>)new HashSet<CrmCompanyQuickRegisterDefSetting>();
	}
}
