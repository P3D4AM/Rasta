using System.ComponentModel.DataAnnotations;
using CRM.Resources;

namespace CRM.Models;

public class CrmFoSettingSalesOrderLblLanguageViewModel
{
	[Key]
	public int FoSettingId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "FoSettingFoSalesOrderLbl")]
	[MaxLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string FoSalesOrderLbl { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "FoSettingFoSalesReturnOrderLbl")]
	[MaxLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string FoSalesReturnOrderLbl { get; set; }

	public int? FoOrdListShowType { get; set; }

	public string FoSalesOrderLbl_Lang { get; set; }

	public string FoSalesReturnOrderLbl_Lang { get; set; }
}
