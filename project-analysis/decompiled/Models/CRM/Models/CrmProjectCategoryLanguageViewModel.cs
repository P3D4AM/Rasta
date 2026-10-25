using System.ComponentModel.DataAnnotations;
using CRM.Resources;

namespace CRM.Models;

public class CrmProjectCategoryLanguageViewModel
{
	[Key]
	public int ProjectCategoryId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "PojectCategoryParent")]
	public int ParentId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "PojectCategoryName")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	[MaxLength(300, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(300, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string CategoryName { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "PojectCategoryCnvsStatusGroup")]
	public int? CnvsStatusGroupId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "PojectCategoryOrderView")]
	public int? OrderView { get; set; }

	public string CategoryName_Lang { get; set; }
}
