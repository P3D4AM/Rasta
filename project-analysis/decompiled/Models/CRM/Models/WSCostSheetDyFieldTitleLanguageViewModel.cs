using System;
using System.ComponentModel.DataAnnotations;
using CRM.Resources;

namespace CRM.Models;

public class WSCostSheetDyFieldTitleLanguageViewModel
{
	[Key]
	public int CostSheetDyFieldTitleId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ctshDyFieldTitleGroup")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	public int CostSheetDyFieldGroupId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ctshDyFieldTitle")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	[MaxLength(200, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(200, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string ctshDyFieldTitle { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ctshDyFieldTitleForFormula")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	[MaxLength(200, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(200, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string ctshDyFieldTitleForFormula { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ctshDyFieldType")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	public int ctshDyFieldType { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ctshDyFieldFormula")]
	public string ctshDyFieldFormula { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ctshDyFieldDefaultValue")]
	public decimal? ctshDyFieldDefaultValue { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ctshDyFieldOrderView")]
	public int? OrderView { get; set; }

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

	[Display(ResourceType = typeof(Labels), Name = "ctshDyFieldIsMarkup")]
	public bool? ctshDyFieldIsMarkup { get; set; }

	public string FirstRegisterUser { get; set; }

	public string EditUser { get; set; }

	public string ctshDyFieldTitle_Lang { get; set; }
}
