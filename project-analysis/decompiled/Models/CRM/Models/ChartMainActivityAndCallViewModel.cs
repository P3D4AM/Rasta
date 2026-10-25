using System.ComponentModel.DataAnnotations;
using CRM.Resources;

namespace CRM.Models;

public class ChartMainActivityAndCallViewModel
{
	[Display(ResourceType = typeof(Labels), Name = "ChartMainActivityAndCallUser")]
	public int? UserId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ChartMainActivityAndCallFromDate")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	[RegularExpression("(\\d{4})[-\\/](\\d{2})[-\\/](\\d{2})$", ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorNotCorrent")]
	public string FromDate { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ChartMainActivityAndCallToDate")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	[RegularExpression("(\\d{4})[-\\/](\\d{2})[-\\/](\\d{2})$", ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorNotCorrent")]
	public string ToDate { get; set; }
}
