using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

public class WSProductShpExceptionLanguageViewModel
{
	[Key]
	public int ProductShpExceptionID { get; set; }

	public int? PrdShpExCId { get; set; }

	public int? PrdShpExPrdId { get; set; }

	public string PrdShpExPrd { get; set; }

	public string PrdShpExPrd_Lang { get; set; }

	public bool? PrdShpExIsActive { get; set; }

	public string PrdShpExTitle { get; set; }

	public string PrdShpExTitle_Lang { get; set; }

	public string PrdShpExCode { get; set; }

	public string PrdShpExModel { get; set; }

	public string PrdShpExModel_Lang { get; set; }

	public string PrdShpExDescription { get; set; }

	public string PrdShpExDescription_Lang { get; set; }

	public string PrdShpExDescriptionII { get; set; }

	public string PrdShpExDescriptionII_Lang { get; set; }

	public int? PrdShpExStockManageTypeId { get; set; }

	public double? PrdShpExStockManualyCount { get; set; }

	public bool? PrdShpExHiddenPriceInNoStock { get; set; }

	public bool? PrdShpExSelfSupplier { get; set; }

	public int? PrdShpExOtherSupplierId { get; set; }

	public string PrdShpExOtherSupplier { get; set; }

	public int? LanguageID { get; set; }

	public bool? PrdShpExQtyFromTracing { get; set; }

	public bool? PrdShpExShowLinkedPrd { get; set; }

	public bool? PrdShpExSeoIsActive { get; set; }

	public string PrdShpExSeoTitle { get; set; }

	public string PrdShpExSeoDescription { get; set; }

	public string PrdShpExSeoHttpEquiv { get; set; }

	public string PrdShpExSeoExpires { get; set; }

	public bool? PrdShpExSeoGoogleNotranslate { get; set; }

	public string PrdShpExSeoDistribution { get; set; }

	public string PrdShpExSeoRobots { get; set; }

	public string PrdShpExSeoRating { get; set; }

	public string PrdShpExSeoAuthor { get; set; }

	public bool? PrdShpExSeoIsUseSocialNetwork { get; set; }

	public int? PrdShpExSeoMobileOptimized { get; set; }

	public string PrdShpExSeoCopyright { get; set; }

	public bool? PrdShpExSeoUseDefault { get; set; }

	public string PrdShpExSeoKeywords { get; set; }

	public string PrdShpExSeoFAQ { get; set; }

	public string PrdShpExSeoTitle_Lang { get; set; }

	public string PrdShpExSeoDescription_Lang { get; set; }

	public string PrdShpExSeoAuthor_Lang { get; set; }

	public string PrdShpExSeoCopyright_Lang { get; set; }

	public string PrdShpExSeoKeywords_Lang { get; set; }

	public string PrdShpExSeoFAQ_Lang { get; set; }
}
