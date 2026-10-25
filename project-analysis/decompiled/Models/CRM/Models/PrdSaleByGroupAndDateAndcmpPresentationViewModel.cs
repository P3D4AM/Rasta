using System.ComponentModel.DataAnnotations;
using CRM.Resources;

namespace CRM.Models;

public class PrdSaleByGroupAndDateAndcmpPresentationViewModel
{
	[Display(ResourceType = typeof(Labels), Name = "PrdSaleByGroupAndDateAndcmpPresentationFromDate")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	[RegularExpression("(?:1[234]\\d{2})\\/(?:0?[1-9]|1[0-2])\\/(?:0?[1-9]|[12][0-9]|3[01])$", ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorNotCorrent")]
	public string FromDate { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "PrdSaleByGroupAndDateAndcmpPresentationToDate")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	[RegularExpression("(?:1[234]\\d{2})\\/(?:0?[1-9]|1[0-2])\\/(?:0?[1-9]|[12][0-9]|3[01])$", ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorNotCorrent")]
	public string ToDate { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "PrdSaleByGroupAndDateAndcmpPresentationFgName")]
	public int FGId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "PrdSaleByGroupAndDateAndcmpPresentationSgName")]
	public int SGId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "PrdSaleByGroupAndDateAndcmpPresentationPrdName")]
	public int PrdId { get; set; }

	public int? Mode { get; set; }
}
