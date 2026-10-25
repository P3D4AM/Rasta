using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using CRM.Resources;

namespace CRM.Models;

public class CrmCmsFooterLanguageViewModel
{
	[Key]
	public int FooterId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "CmsFooterBody")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	[UIHint("RichText")]
	[AllowHtml]
	public string FooterBody { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "CmsFooterStyle")]
	[AllowHtml]
	public string FooterStyle { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "CmsFooterScript")]
	[AllowHtml]
	public string FooterScript { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "CmsFooterIsActive")]
	public bool? IsActive { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "CrmCmsFooterSystemPartIds")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	public string FooterSystemPartIds { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "CmsFooterTitle")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	[MaxLength(200, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(200, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string FooterTitle { get; set; }

	[AllowHtml]
	public string FooterBody_Lang { get; set; }

	public string FooterTitle_Lang { get; set; }
}
