using System.ComponentModel.DataAnnotations;
using CRM.Resources;

namespace CRM.Models;

public class ParadoxReportsViewModel
{
	[Display(ResourceType = typeof(Labels), Name = "ParadoxReportsOrdReportId")]
	public int OrdReportId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ParadoxReportsOrdFromDate")]
	[RegularExpression("(\\d{4})[-\\/](\\d{2})[-\\/](\\d{2})$", ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorNotCorrent")]
	public string OrdFromDate { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ParadoxReportsOrdToDate")]
	[RegularExpression("(\\d{4})[-\\/](\\d{2})[-\\/](\\d{2})$", ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorNotCorrent")]
	public string OrdToDate { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ParadoxReportsOrdSerial")]
	[MaxLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string OrdSerial { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ParadoxReportsDocReportId")]
	public int DocReportId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ParadoxReportsDocFromDate")]
	[RegularExpression("(\\d{4})[-\\/](\\d{2})[-\\/](\\d{2})$", ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorNotCorrent")]
	public string DocFromDate { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ParadoxReportsDocToDate")]
	[RegularExpression("(\\d{4})[-\\/](\\d{2})[-\\/](\\d{2})$", ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorNotCorrent")]
	public string DocToDate { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ParadoxReportsDocSerial")]
	[MaxLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string DocSerial { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ParadoxReportsPordReportId")]
	public int PordReportId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ParadoxReportsPordFromDate")]
	[RegularExpression("(\\d{4})[-\\/](\\d{2})[-\\/](\\d{2})$", ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorNotCorrent")]
	public string PordFromDate { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ParadoxReportsPordToDate")]
	[RegularExpression("(\\d{4})[-\\/](\\d{2})[-\\/](\\d{2})$", ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorNotCorrent")]
	public string PordToDate { get; set; }
}
