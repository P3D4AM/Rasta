using System;
using System.ComponentModel.DataAnnotations;
using CRM.Resources;

namespace CRM.Models;

public class WSProductUnitsLanguageViewModel
{
	[Key]
	public int ProductUnitID { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ProductUnitsTitle")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	[MaxLength(100, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(100, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string Unit { get; set; }

	public int? QuantityInUnit { get; set; }

	public string Description { get; set; }

	public int UserId { get; set; }

	public short Month1 { get; set; }

	public DateTime RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ProductUnitsEnTitle")]
	[MaxLength(100, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(100, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string UnitEn { get; set; }

	public Guid? GUId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ProductUnitsFCR")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	public double? FCR { get; set; }

	public string AppType { get; set; }

	public int? LanguageID { get; set; }

	public int? FirstRegisterUserId { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public DateTime? FirstRegisterDate { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ProductUnitsFCRI")]
	public double? FCRI { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ProductUnitsSHPTitle")]
	[MaxLength(100, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(100, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string SHPUnit { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ProductUnitsTspUnitCode")]
	[MaxLength(100, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(100, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string TspUnitCode { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ProductUnitIFormula")]
	public string UnitIFormula { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ProductUnitIIFormula")]
	public string UnitIIFormula { get; set; }

	public string Unit_Lang { get; set; }

	public string SHPUnit_Lang { get; set; }
}
