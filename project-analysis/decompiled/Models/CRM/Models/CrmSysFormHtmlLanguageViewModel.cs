using System;
using System.Web.Mvc;

namespace CRM.Models;

public class CrmSysFormHtmlLanguageViewModel
{
	public int FormHtmlID { get; set; }

	public int FormId { get; set; }

	public string FormTitle { get; set; }

	[AllowHtml]
	public string FormHTML { get; set; }

	[AllowHtml]
	public string FormHTML_Lang { get; set; }

	[AllowHtml]
	public string FormCSS { get; set; }

	[AllowHtml]
	public string FormCSS_Lang { get; set; }

	[AllowHtml]
	public string FormRep { get; set; }

	[AllowHtml]
	public string FormRep_Lang { get; set; }

	[AllowHtml]
	public string FormJS { get; set; }

	[AllowHtml]
	public string FormJS_Lang { get; set; }

	[AllowHtml]
	public string FormJSTop { get; set; }

	[AllowHtml]
	public string FormJSTop_Lang { get; set; }

	public bool? FormDeActive { get; set; }

	public int FirstRegisterUserId { get; set; }

	public string FirstRegisterUser { get; set; }

	public DateTime FirstRegisterDate { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public int UserId { get; set; }

	public string EditUser { get; set; }

	public short Year1 { get; set; }

	public short Month1 { get; set; }

	public DateTime RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	public string AppType { get; set; }

	public int LanguageID { get; set; }
}
