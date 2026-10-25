using System.ComponentModel.DataAnnotations;
using CRM.Resources;

namespace CRM.Models;

public class PrdSaleByGroupAndDateAndOrderOprViewModel
{
	[Display(ResourceType = typeof(Labels), Name = "PrdSaleByGroupAndDateAndOrderOprFromDate")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	[RegularExpression("(?:1[234]\\d{2})\\/(?:0?[1-9]|1[0-2])\\/(?:0?[1-9]|[12][0-9]|3[01])$", ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorNotCorrent")]
	public string FromDate { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "PrdSaleByGroupAndDateAndOrderOprToDate")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	[RegularExpression("(?:1[234]\\d{2})\\/(?:0?[1-9]|1[0-2])\\/(?:0?[1-9]|[12][0-9]|3[01])$", ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorNotCorrent")]
	public string ToDate { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "PrdSaleByGroupAndDateAndOrderOprFgName")]
	public int FGId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "PrdSaleByGroupAndDateAndOrderOprSgName")]
	public int SGId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "PrdSaleByGroupAndDateAndOrderOprPrdName")]
	public int PrdId { get; set; }

	public int? Mode { get; set; }
}
