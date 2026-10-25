using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(CrmProjectGroupsMetadata))]
public class CrmProjectGroups
{
	public int ProjectGroupID { get; set; }

	public string ProjectGroup { get; set; }

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

	public virtual ICollection<CrmProjectGroups_Lang> CrmProjectGroups_Lang { get; set; }

	public virtual Languages Languages { get; set; }

	public virtual ICollection<CrmProjectTitles> CrmProjectTitles { get; set; }

	public virtual ICollection<CrmFoSetting> CrmFoSetting { get; set; }

	public virtual ICollection<CrmFoSettingRegister> CrmFoSettingRegister { get; set; }

	public virtual ICollection<CrmProjects> CrmProjects { get; set; }

	public virtual ICollection<CrmCompanyQuickRegisterDefSetting> CrmCompanyQuickRegisterDefSetting { get; set; }

	public virtual Users Users { get; set; }

	public virtual Users Users1 { get; set; }

	public virtual Users Users2 { get; set; }

	public CrmProjectGroups()
	{
		CrmProjectGroups_Lang = (ICollection<CrmProjectGroups_Lang>)new HashSet<CrmProjectGroups_Lang>();
		CrmProjectTitles = (ICollection<CrmProjectTitles>)new HashSet<CrmProjectTitles>();
		CrmFoSetting = (ICollection<CrmFoSetting>)new HashSet<CrmFoSetting>();
		CrmFoSettingRegister = (ICollection<CrmFoSettingRegister>)new HashSet<CrmFoSettingRegister>();
		CrmProjects = (ICollection<CrmProjects>)new HashSet<CrmProjects>();
		CrmCompanyQuickRegisterDefSetting = (ICollection<CrmCompanyQuickRegisterDefSetting>)new HashSet<CrmCompanyQuickRegisterDefSetting>();
	}
}
