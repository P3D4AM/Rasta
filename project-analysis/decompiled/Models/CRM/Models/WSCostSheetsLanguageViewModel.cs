using System;
using System.ComponentModel.DataAnnotations;
using CRM.Resources;

namespace CRM.Models;

public class WSCostSheetsLanguageViewModel
{
	[Key]
	public int CostSheetId { get; set; }

	public int ctshCmpProjectId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ctshNumber")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	public long ctshNumber { get; set; }

	public DateTime ctshDate { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ctshDate")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	[RegularExpression("(\\d{4})[-\\/](\\d{2})[-\\/](\\d{2})$", ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorNotCorrent")]
	public string ctshDatePersian { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ctshTitle")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	[MaxLength(200, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(200, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string ctshTitle { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ctshSrcCurrencyUnitId")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	public int ctshSrcCurrencyUnitId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ctshDestCurrencyUnitId")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	public int ctshDestCurrencyUnitId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ctshCurrencyRate")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	public double? ctshCurrencyRate { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ctshRoundRate")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	public double? ctshRoundRate { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ctshTaxIndex")]
	public decimal? ctshTaxIndex { get; set; }

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

	public int Mode { get; set; }

	public bool IsAddItems { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ctshDyFieldGroup")]
	public decimal? CostSheetDyFieldGroupId { get; set; }

	public string costSheetProductIds { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ctshNumRef")]
	[MaxLength(150, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(150, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string ctshNumRef { get; set; }

	public string ctshTitle_Lang { get; set; }
}
