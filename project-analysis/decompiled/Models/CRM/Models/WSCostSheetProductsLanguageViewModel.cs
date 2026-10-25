using System;
using System.ComponentModel.DataAnnotations;
using CRM.Resources;

namespace CRM.Models;

public class WSCostSheetProductsLanguageViewModel
{
	[Key]
	public int CostSheetProductId { get; set; }

	public int ctshPrdCmpProjectId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ctshPrdName")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	[MaxLength(1000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(1000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string ctshPrdName { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ctshPrdQuantity")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	public double ctshQuantity { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ctshPrdOrderView")]
	public int? OrderView { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ctshPrdGroupId")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	public int? ctshPrdGroupId { get; set; }

	public int FirstRegisterUserId { get; set; }

	public DateTime FirstRegisterDate { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public int UserId { get; set; }

	public int FPId { get; set; }

	public short Month1 { get; set; }

	public DateTime RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	public Guid GUId { get; set; }

	public string AppType { get; set; }

	public int LanguageID { get; set; }

	public string FirstRegisterUser { get; set; }

	public string EditUser { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ctshPrdId")]
	public int? ctshPrdProductId { get; set; }

	public bool? IsSelectPrd { get; set; }

	public string ctshPrdName_I { get; set; }

	public string ctshPrdName_Lang { get; set; }
}
