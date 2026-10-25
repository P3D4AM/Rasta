using System.ComponentModel.DataAnnotations;
using CRM.Resources;

namespace CRM.Models;

public class WareHousePrdCardexViewModel
{
	[Display(ResourceType = typeof(Labels), Name = "WareHousePrdCardexWhrName")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	public int WHId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "WareHousePrdCardexFromDate")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	[RegularExpression("(\\d{4})[-\\/](\\d{2})[-\\/](\\d{2})$", ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorNotCorrent")]
	public string FromDate { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "WareHousePrdCardexToDate")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	[RegularExpression("(\\d{4})[-\\/](\\d{2})[-\\/](\\d{2})$", ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorNotCorrent")]
	public string ToDate { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "WareHousePrdCardexPrdName")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	public int PrdId { get; set; }

	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	public int Mode { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "WareHousePrdCardexCompany")]
	public int? CompanyId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "WareHousePrdCardexFCR")]
	public double? FCR { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "WareHousePrdCardexFCRI")]
	public double? FCRI { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "WareHousePrdCardexTracing")]
	public string Tracing { get; set; }
}
