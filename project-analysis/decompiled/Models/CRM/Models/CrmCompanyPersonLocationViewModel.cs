using System.ComponentModel.DataAnnotations;
using CRM.Resources;

namespace CRM.Models;

public class CrmCompanyPersonLocationViewModel
{
	[Key]
	public int CompanyPersonID { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "prsCoordinateLatitude")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	[MaxLength(100, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(100, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string prsCoordinateLatitude { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "prsCoordinateLongitude")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	[MaxLength(100, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(100, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string prsCoordinateLongitude { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "prsCoordinateLastDate")]
	public string prsCoordinateLastDatePersian { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "PersonLocationPrsAddress")]
	public string prsAddress { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "prsCoordinateZoomLevel")]
	public int? prsCoordinateZoomLevel { get; set; }

	public string PersonName { get; set; }

	public string AppType { get; set; }
}
