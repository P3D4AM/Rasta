using System;
using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

public class CrmCmsWidgetsMetadata
{
	[Key]
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
}
