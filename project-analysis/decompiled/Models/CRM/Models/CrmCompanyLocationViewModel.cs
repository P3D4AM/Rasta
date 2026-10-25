using System.ComponentModel.DataAnnotations;
using CRM.Resources;

namespace CRM.Models;

public class CrmCompanyLocationViewModel
{
	[Key]
	public int CompanyID { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cmpCoordinateLatitude")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	[MaxLength(100, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(100, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string cmpCoordinateLatitude { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cmpCoordinateLongitude")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	[MaxLength(100, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(100, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string cmpCoordinateLongitude { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cmpCoordinateLastDate")]
	public string cmpCoordinateLastDatePersian { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "CompanyLocationCmpAddress")]
	public string cmpAddress { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cmpCoordinateZoomLevel")]
	public int? cmpCoordinateZoomLevel { get; set; }
}
