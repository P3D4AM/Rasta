using System.ComponentModel.DataAnnotations;
using CRM.Resources;

namespace CRM.Models;

public class PrdSaleByGroupAndDateAndcmpTypeViewModel
{
	[Display(ResourceType = typeof(Labels), Name = "PrdSaleByGroupAndDateAndcmpTypeFromDate")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	[RegularExpression("(?:1[234]\\d{2})\\/(?:0?[1-9]|1[0-2])\\/(?:0?[1-9]|[12][0-9]|3[01])$", ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorNotCorrent")]
	public string FromDate { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "PrdSaleByGroupAndDateAndcmpTypeToDate")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	[RegularExpression("(?:1[234]\\d{2})\\/(?:0?[1-9]|1[0-2])\\/(?:0?[1-9]|[12][0-9]|3[01])$", ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorNotCorrent")]
	public string ToDate { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "PrdSaleByGroupAndDateAndcmpTypeFgName")]
	public int FGId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "PrdSaleByGroupAndDateAndcmpTypeSgName")]
	public int SGId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "PrdSaleByGroupAndDateAndcmpTypePrdName")]
	public int PrdId { get; set; }

	public int? Mode { get; set; }
}
