using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace CRM.Models;

public class CrmLeaveTermsEditLanguageViewModel
{
	public int LeaveTypeID { get; set; }

	[UIHint("RichText")]
	[AllowHtml]
	public string TermText { get; set; }

	[AllowHtml]
	public string TermText_Lang { get; set; }

	public string MsgLangValue { get; set; }
}
