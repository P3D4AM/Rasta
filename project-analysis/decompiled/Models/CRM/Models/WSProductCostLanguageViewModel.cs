using System;
using System.ComponentModel.DataAnnotations;
using CRM.Resources;

namespace CRM.Models;

public class WSProductCostLanguageViewModel
{
	[Key]
	public int ProductCostID { get; set; }

	public int PrdId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "prdCostDocDate")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	[MaxLength(10, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(10, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string DocDate { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "prdCostDocNumber")]
	[MaxLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string DocNumber { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "prdCost")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	public decimal Cost { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "prdCurrencyCost")]
	public decimal? CurrencyCost { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "prdCostCurrencyUnitId")]
	public int? CurrencyUnitId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "prdTransportCost")]
	public decimal? TransportCost { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "prdReleasingCost")]
	public decimal? ReleasingCost { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "prdSlagCost")]
	public decimal? SlagCost { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "prdOtherCost")]
	public decimal? OtherCost { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "prdCostDescription")]
	[MaxLength(500, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(500, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string Description { get; set; }

	public int UserId { get; set; }

	public short Month1 { get; set; }

	public int FPId { get; set; }

	public DateTime RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	public int? WHId { get; set; }

	public Guid? GUId { get; set; }

	public int? ProductCostGroupId { get; set; }

	public string AppType { get; set; }

	public int? LanguageID { get; set; }

	public int? FirstRegisterUserId { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public DateTime? FirstRegisterDate { get; set; }

	public DateTime? DocDateTime { get; set; }

	public string Description_Lang { get; set; }
}
