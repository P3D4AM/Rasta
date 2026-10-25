using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using CRM.Resources;

namespace CRM.Models;

public class WSProductsInShopLanguageViewModel
{
	[Key]
	public int ProductID { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "PrdName")]
	public string PrdName { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "PrdSHPIsActive")]
	public bool? PrdSHPIsActive { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "PrdSHPTitle")]
	[MaxLength(1000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(1000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string PrdSHPTitle { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "PrdSHPCode")]
	[MaxLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string PrdSHPCode { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "PrdSHPModel")]
	[MaxLength(200, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(200, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string PrdSHPModel { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "PrdSHPDescription")]
	[UIHint("RichText")]
	[AllowHtml]
	public string PrdSHPDescription { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "PrdSHPDescriptionII")]
	[UIHint("RichText")]
	[AllowHtml]
	public string PrdSHPDescriptionII { get; set; }

	public int? PrdSHPStockManageTypeId { get; set; }

	public double? PrdSHPStockManualyCount { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "PrdSHPHiddenPriceInNoStock")]
	public bool? PrdSHPHiddenPriceInNoStock { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "PrdSHPSelfSupplier")]
	public bool? PrdSHPSelfSupplier { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "PrdSHPOtherSupplierId")]
	public int? PrdSHPOtherSupplierId { get; set; }

	public string PrdSHPOtherSupplier { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "PrdSHPQtyFromTracing")]
	public bool? PrdSHPQtyFromTracing { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "PrdSHPShowLinkedPrd")]
	public bool? PrdSHPShowLinkedPrd { get; set; }

	public string PrdName_Lang { get; set; }

	public string PrdSHPTitle_Lang { get; set; }

	public string PrdSHPModel_Lang { get; set; }

	[AllowHtml]
	public string PrdSHPDescription_Lang { get; set; }

	[AllowHtml]
	public string PrdSHPDescriptionII_Lang { get; set; }

	public bool? PrdSeoIsActive { get; set; }

	public string PrdSeoTitle { get; set; }

	public string PrdSeoDescription { get; set; }

	public string PrdSeoHttpEquiv { get; set; }

	public string PrdSeoExpires { get; set; }

	public bool? PrdSeoGoogleNotranslate { get; set; }

	public string PrdSeoDistribution { get; set; }

	public string PrdSeoRobots { get; set; }

	public string PrdSeoRating { get; set; }

	public string PrdSeoAuthor { get; set; }

	public bool? PrdSeoIsUseSocialNetwork { get; set; }

	public int? PrdSeoMobileOptimized { get; set; }

	public string PrdSeoCopyright { get; set; }

	public bool? PrdSeoUseDefault { get; set; }

	public string PrdSeoKeywords { get; set; }

	public string PrdSeoFAQ { get; set; }

	public string PrdSeoTitle_Lang { get; set; }

	public string PrdSeoDescription_Lang { get; set; }

	public string PrdSeoAuthor_Lang { get; set; }

	public string PrdSeoCopyright_Lang { get; set; }

	public string PrdSeoKeywords_Lang { get; set; }

	public string PrdSeoFAQ_Lang { get; set; }
}
