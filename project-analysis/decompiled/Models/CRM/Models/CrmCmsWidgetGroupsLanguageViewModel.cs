using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using CRM.Resources;

namespace CRM.Models;

public class CrmCmsWidgetGroupsLanguageViewModel
{
	[Key]
	public int WidgetGroupId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "WidgetGroupSystemPartId")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	public int WidgetGroupSystemPartId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "WidgetGroupTitle")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	[MaxLength(200, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(200, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string WidgetGroupTitle { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "WidgetGroupStyle")]
	[AllowHtml]
	public string WidgetGroupStyle { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "WidgetGroupScript")]
	[AllowHtml]
	public string WidgetGroupScript { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "WidgetGroupIsActive")]
	public bool? IsActive { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "WidgetGroupOrderView")]
	public int? OrderView { get; set; }

	public string WidgetGroupTitle_Lang { get; set; }
}
