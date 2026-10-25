using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(CrmCmsWidgetsMetadata))]
public class CrmCmsWidgets
{
	public int WidgetId { get; set; }

	public int WidgetGroupId { get; set; }

	public string WidgetTitle { get; set; }

	public int? WidgetRowStart { get; set; }

	public int? WidgetRowCnt { get; set; }

	public int? WidgetColStart { get; set; }

	public int? WidgetColCnt { get; set; }

	public string WidgetBody { get; set; }

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

	public virtual CrmCmsWidgetGroups CrmCmsWidgetGroups { get; set; }

	public virtual ICollection<CrmCmsWidgets_Lang> CrmCmsWidgets_Lang { get; set; }

	public virtual Languages Languages { get; set; }

	public virtual Users Users { get; set; }

	public virtual Users Users1 { get; set; }

	public CrmCmsWidgets()
	{
		CrmCmsWidgets_Lang = (ICollection<CrmCmsWidgets_Lang>)new HashSet<CrmCmsWidgets_Lang>();
	}
}
