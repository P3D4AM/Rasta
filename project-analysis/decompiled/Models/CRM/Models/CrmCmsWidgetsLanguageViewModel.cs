using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using CRM.Resources;

namespace CRM.Models;

public class CrmCmsWidgetsLanguageViewModel
{
	[Key]
	public int WidgetId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "WidgetGroup")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	public int WidgetGroupId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "WidgetTitle")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	[MaxLength(200, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(200, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string WidgetTitle { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "WidgetRowStart")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	public int? WidgetRowStart { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "WidgetRowCnt")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	public int? WidgetRowCnt { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "WidgetColStart")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	public int? WidgetColStart { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "WidgetColCnt")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	public int? WidgetColCnt { get; set; }

	[UIHint("RichText")]
	[AllowHtml]
	[Display(ResourceType = typeof(Labels), Name = "WidgetBody")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	public string WidgetBody { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "WidgetIsActive")]
	public bool? IsActive { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "WidgetOrderView")]
	public int? OrderView { get; set; }

	public int FirstRegisterUserId { get; set; }

	public DateTime FirstRegisterDate { get; set; }

	public string FirstRegisterUser { get; set; }

	public int UserId { get; set; }

	public DateTime RegisterDate { get; set; }

	public string EditUser { get; set; }

	public string AppType { get; set; }

	public string WidgetTitle_Lang { get; set; }

	[UIHint("RichText")]
	[AllowHtml]
	public string WidgetBody_Lang { get; set; }
}
