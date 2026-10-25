using System;
using System.ComponentModel.DataAnnotations;
using CRM.Resources;

namespace CRM.Models;

public class CrmCompanyAddressesLanguageViewModel
{
	[Key]
	public int CompanyAddressId { get; set; }

	public int cmpaddCompanyId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cmpaddCityId")]
	public int? cmpaddCityId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cmpaddCompanyAddress")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	[MaxLength(1000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(1000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string CompanyAddress { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cmpaddDesc")]
	[MaxLength(500, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(500, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string cmpaddDesc { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cmpaddZipCode")]
	[MaxLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string cmpaddZipCode { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cmpaddPostBox")]
	[MaxLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string cmpaddPostBox { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cmpaddCoordinateLatitude")]
	[MaxLength(100, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(100, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string cmpaddCoordinateLatitude { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cmpaddCoordinateLongitude")]
	[MaxLength(100, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(100, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string cmpaddCoordinateLongitude { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cmpaddCoordinateLastDate")]
	public DateTime? cmpaddCoordinateLastDate { get; set; }

	public string cmpaddCoordinateLastDatePersian { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cmpaddCoordinateZoomLevel")]
	public int? cmpaddCoordinateZoomLevel { get; set; }

	public int? cmpaddCoordinateLastUserId { get; set; }

	public int FirstRegisterUserId { get; set; }

	public DateTime FirstRegisterDate { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public int UserId { get; set; }

	public short Year1 { get; set; }

	public short Month1 { get; set; }

	public DateTime RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	public Guid GUId { get; set; }

	public string AppType { get; set; }

	public int LanguageID { get; set; }

	public string FirstRegisterUser { get; set; }

	public string EditUser { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cmpaddTypeId")]
	public int? cmpaddTypeId { get; set; }

	public string CompanyAddress_Lang { get; set; }

	public string cmpaddDesc_Lang { get; set; }
}
