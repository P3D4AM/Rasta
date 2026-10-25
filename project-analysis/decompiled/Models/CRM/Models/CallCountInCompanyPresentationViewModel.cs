using System.ComponentModel.DataAnnotations;
using CRM.Resources;

namespace CRM.Models;

public class CallCountInCompanyPresentationViewModel
{
	[Display(ResourceType = typeof(Labels), Name = "CallCountInCompanyPresentationUser")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	public int UserId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "CallCountInCompanyPresentationFromDate")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	[RegularExpression("(\\d{4})[-\\/](\\d{2})[-\\/](\\d{2})$", ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorNotCorrent")]
	public string FromDate { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "CallCountInCompanyPresentationToDate")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	[RegularExpression("(\\d{4})[-\\/](\\d{2})[-\\/](\\d{2})$", ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorNotCorrent")]
	public string ToDate { get; set; }
}
