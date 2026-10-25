using System;

namespace CRM.Models;

public class CRMspCmsSelectActivePages_Result
{
	public int PageId { get; set; }

	public string PageName { get; set; }

	public string PageTitle { get; set; }

	public string PageHeader { get; set; }

	public string PageBody { get; set; }

	public string PageFooter { get; set; }

	public bool? IsActive { get; set; }

	public int? OrderView { get; set; }

	public string PageStyle { get; set; }

	public string PageHeaderScript { get; set; }

	public string PageEndScript { get; set; }

	public int? CrmDyFormId { get; set; }

	public string CrmDyFormName { get; set; }

	public string CrmDyFormTitle { get; set; }

	public int? TargetMode { get; set; }

	public bool? OnlyForLoginUser { get; set; }

	public int? PageLocation { get; set; }

	public int? LayoutType { get; set; }

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

	public string EditUser { get; set; }

	public string FirstRegisterUser { get; set; }
}
