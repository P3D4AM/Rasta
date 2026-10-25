using System.ComponentModel.DataAnnotations;
using CRM.Resources;

namespace CRM.Models;

public class CrmCompanyAddressesLocationViewModel
{
	[Key]
	public int CompanyAddressId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cmpaddCoordinateLatitude")]
	[MaxLength(100, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(100, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string cmpaddCoordinateLatitude { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cmpaddCoordinateLongitude")]
	[MaxLength(100, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(100, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string cmpaddCoordinateLongitude { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cmpaddCoordinateLastDate")]
	public string cmpaddCoordinateLastDatePersian { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cmpaddCoordinateZoomLevel")]
	public int? cmpaddCoordinateZoomLevel { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cmpaddCompanyAddress")]
	public string CompanyAddress { get; set; }

	public string CompanyName { get; set; }
}
