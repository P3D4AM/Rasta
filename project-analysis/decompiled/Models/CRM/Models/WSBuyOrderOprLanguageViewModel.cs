using System.ComponentModel.DataAnnotations;
using CRM.Resources;

namespace CRM.Models;

public class WSBuyOrderOprLanguageViewModel
{
	[Key]
	public int BuyOrderOprID { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "BuyOrderOprName")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	[MaxLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string Name { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "BuyOrderOprType")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	public int? OprType { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "BuyOrderOprDocOpr")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	public int? DocOprId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "BuyOrderOprOrderView")]
	public int? OrderView { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "BuyOrderOprUserAccessAll")]
	public bool? BuyOrderOprUserAccessAll { get; set; }

	public string Name_Lang { get; set; }
}
