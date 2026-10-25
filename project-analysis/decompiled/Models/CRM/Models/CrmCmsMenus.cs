using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(CrmCmsMenusMetadata))]
public class CrmCmsMenus
{
	public int MenuId { get; set; }

	public string MenuTitle { get; set; }

	public string Type { get; set; }

	public string ModuleName { get; set; }

	public int? ParentId { get; set; }

	public int? DyFormId { get; set; }

	public int? PageId { get; set; }

	public int? NewsId { get; set; }

	public int? PrdFirstGroupId { get; set; }

	public int? PrdSecondGroupId { get; set; }

	public string Link { get; set; }

	public int TargetMode { get; set; }

	public bool? OnlyForLoginUser { get; set; }

	public bool? IsActive { get; set; }

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

	public virtual CrmCmsNews CrmCmsNews { get; set; }

	public virtual CrmCmsPages CrmCmsPages { get; set; }

	public virtual CrmDyForms CrmDyForms { get; set; }

	public virtual ICollection<CrmCmsMenus_Lang> CrmCmsMenus_Lang { get; set; }

	public virtual Languages Languages { get; set; }

	public virtual WSProductFirstGroup WSProductFirstGroup { get; set; }

	public virtual WSProductSecondGroup WSProductSecondGroup { get; set; }

	public virtual Users Users { get; set; }

	public virtual Users Users1 { get; set; }

	public CrmCmsMenus()
	{
		CrmCmsMenus_Lang = (ICollection<CrmCmsMenus_Lang>)new HashSet<CrmCmsMenus_Lang>();
	}
}
