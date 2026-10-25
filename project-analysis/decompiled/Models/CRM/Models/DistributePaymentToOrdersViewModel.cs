using System.ComponentModel.DataAnnotations;
using CRM.Resources;

namespace CRM.Models;

public class DistributePaymentToOrdersViewModel
{
	[Display(ResourceType = typeof(Labels), Name = "DistributePaymentToOrdersImportDate")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	public string ImportDate { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "DistributePaymentToOrdersTypeId")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	public int PayTypeId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "DistributePaymentToOrdersDocNumber")]
	[MaxLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string DocNumber { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "DistributePaymentToOrdersDocDate")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	public string DocDate { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "DistributePaymentToOrdersDescription")]
	[MaxLength(2000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(2000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string Description { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "DistributePaymentToOrdersDocAmount")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	public decimal? DocAmount { get; set; }

	public string Description_Lang { get; set; }
}
