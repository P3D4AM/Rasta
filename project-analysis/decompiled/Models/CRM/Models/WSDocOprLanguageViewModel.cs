using System.ComponentModel.DataAnnotations;
using CRM.Resources;

namespace CRM.Models;

public class WSDocOprLanguageViewModel
{
	[Key]
	public int DocOprID { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "DocOprName")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	[MaxLength(200, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(200, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string Name { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "DocOprType")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	public int? OprType { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "DocOprOrderView")]
	public int? OrderView { get; set; }

	public string Name_Lang { get; set; }
}
