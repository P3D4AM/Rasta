using System;
using System.ComponentModel.DataAnnotations;
using CRM.Resources;

namespace CRM.Models;

public class WSProductsUserDiscountLanguageViewModel
{
	[Key]
	public int ProductsUserDiscountId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ProductsUserDiscountDate")]
	public string ProductsUserDiscountDate { get; set; }

	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	[Display(ResourceType = typeof(Labels), Name = "ProductsUserDiscountDate")]
	public DateTime ProductsUserDiscountDateTime { get; set; }

	public int ProductGroupId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ProductsUserDiscounUserId")]
	public int? DiscountUserId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ProductsUserDiscounAllUser")]
	public bool? DiscountAllUser { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ProductsUserDiscounProductId")]
	public int? DiscountProductId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ProductsUserDiscounAllPrdInGroup")]
	public bool? DiscountAllPrdInGroup { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ProductsUserDiscounPercent")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	public decimal DiscountPercent { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ProductsUserDiscounDescription")]
	[MaxLength(1000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(1000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string Description { get; set; }

	public DateTime FirstRegisterDate { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public int FirstRegisterUserId { get; set; }

	public int UserId { get; set; }

	public short Month1 { get; set; }

	public int FPId { get; set; }

	public DateTime RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	public Guid GUId { get; set; }

	public string AppType { get; set; }

	public string Description_Lang { get; set; }
}
