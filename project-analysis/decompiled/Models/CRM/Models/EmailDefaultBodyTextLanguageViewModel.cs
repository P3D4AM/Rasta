using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using CRM.Resources;

namespace CRM.Models;

public class EmailDefaultBodyTextLanguageViewModel
{
	[Key]
	public int EmailDefaultBodyTextId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "EmailDefBodyTextTitle")]
	[MaxLength(150, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(150, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string Title { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "EmailDefBodyText")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	[UIHint("RichText")]
	[AllowHtml]
	public string Body { get; set; }

	public string Title_Lang { get; set; }

	[AllowHtml]
	public string Body_Lang { get; set; }
}
