using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(CrmProjectCategoryMetadata))]
public class CrmProjectCategory
{
	public int ProjectCategoryId { get; set; }

	public int ParentId { get; set; }

	public string ParentHistory { get; set; }

	public string CategoryName { get; set; }

	public int? Depth { get; set; }

	public bool? IsLeaf { get; set; }

	public int? CnvsStatusGroupId { get; set; }

	public int? OrderView { get; set; }

	public int FirstRegisterUserId { get; set; }

	public DateTime FirstRegisterDate { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public int UserId { get; set; }

	public int Year1 { get; set; }

	public short Month1 { get; set; }

	public DateTime RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	public Guid GUId { get; set; }

	public string AppType { get; set; }

	public int LanguageID { get; set; }

	public virtual ICollection<CrmProjectCategory_Lang> CrmProjectCategory_Lang { get; set; }

	public virtual Languages Languages { get; set; }

	public virtual CrmConversationStatusGroups CrmConversationStatusGroups { get; set; }

	public virtual ICollection<CrmProjects> CrmProjects { get; set; }

	public virtual ICollection<CrmCompanyQuickRegisterDefSetting> CrmCompanyQuickRegisterDefSetting { get; set; }

	public virtual Users Users { get; set; }

	public virtual Users Users1 { get; set; }

	public CrmProjectCategory()
	{
		CrmProjectCategory_Lang = (ICollection<CrmProjectCategory_Lang>)new HashSet<CrmProjectCategory_Lang>();
		CrmProjects = (ICollection<CrmProjects>)new HashSet<CrmProjects>();
		CrmCompanyQuickRegisterDefSetting = (ICollection<CrmCompanyQuickRegisterDefSetting>)new HashSet<CrmCompanyQuickRegisterDefSetting>();
	}
}
