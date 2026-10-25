using System;

namespace CRM.Models;

public class CRMspCmsSelectWidgetGroups_Result
{
	public int WidgetGroupId { get; set; }

	public int WidgetGroupSystemPartId { get; set; }

	public string WidgetGroupSystemPartTitle { get; set; }

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

	public string FirstRegisterUser { get; set; }

	public string EditUser { get; set; }
}
