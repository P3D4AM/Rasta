using System;
using System.ComponentModel.DataAnnotations;
using CRM.Resources;

namespace CRM.Models;

public class WSProductPriceMetadata
{
	[Key]
	public int PrdPriceID { get; set; }

	public int PrdId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "prdPriceDocDate")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	[MaxLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string DocDate { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "prdPriceDocNumber")]
	[MaxLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string DocNumber { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "prdPrice")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	public decimal Price { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "prdCurrencyPrice")]
	public decimal? CurrencyPrice { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "prdPriceCurrencyUnitId")]
	public int? CurrencyUnitId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "prdCooperationPrice")]
	public decimal? CooperationPrice { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "prdPricePercent")]
	public decimal? PricePercent { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "prdDiscountPrecent")]
	public decimal? DiscountPrecent { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "prdDiscount")]
	public decimal? Discount { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "prdOtherPrice")]
	public decimal? OtherPrice { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "prdPriceDescription")]
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

	public int? ProductPriceGroupId { get; set; }

	public string AppType { get; set; }

	public int? LanguageID { get; set; }

	public int? FirstRegisterUserId { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public DateTime? FirstRegisterDate { get; set; }

	public DateTime? DocDateTime { get; set; }
}
