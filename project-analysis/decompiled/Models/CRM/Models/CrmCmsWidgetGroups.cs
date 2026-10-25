using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(CrmCmsWidgetGroupsMetadata))]
public class CrmCmsWidgetGroups
{
	public int WidgetGroupId { get; set; }

	public int WidgetGroupSystemPartId { get; set; }

	public string WidgetGroupTitle { get; set; }

	public string WidgetGroupStyle { get; set; }

	public string WidgetGroupScript { get; set; }

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

	public virtual CrmSystemParts CrmSystemParts { get; set; }

	public virtual ICollection<CrmCmsWidgetGroups_Lang> CrmCmsWidgetGroups_Lang { get; set; }

	public virtual Languages Languages { get; set; }

	public virtual ICollection<CrmCmsWidgets> CrmCmsWidgets { get; set; }

	public virtual Users Users { get; set; }

	public virtual Users Users1 { get; set; }

	public CrmCmsWidgetGroups()
	{
		CrmCmsWidgetGroups_Lang = (ICollection<CrmCmsWidgetGroups_Lang>)new HashSet<CrmCmsWidgetGroups_Lang>();
		CrmCmsWidgets = (ICollection<CrmCmsWidgets>)new HashSet<CrmCmsWidgets>();
	}
}
