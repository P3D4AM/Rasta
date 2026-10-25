using System;
using System.ComponentModel.DataAnnotations;
using CRM.Resources;

namespace CRM.Models;

public class ProductGroupViewModel
{
	[Key]
	public int PrdGroupID { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "FGCode")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	[MaxLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string FGCode { get; set; }

	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	[Display(ResourceType = typeof(Labels), Name = "FGName")]
	[MaxLength(100, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(100, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string FGName { get; set; }

	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	[Display(ResourceType = typeof(Labels), Name = "FGSubName")]
	[MaxLength(100, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(100, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string FGSubName { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "FGDescription")]
	[MaxLength(4000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(4000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string FGDescription { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "FGNameEn")]
	public string FGNameEn { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "FGInactiveInSale")]
	public bool FGInactiveInSale { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "FGInactiveInBuy")]
	public bool FGInactiveInBuy { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ProductGroupMustExistInPreOrder")]
	public bool PrdGroupMustExistInPreOrder { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "FGOrderView")]
	public int? FGOrderView { get; set; }

	public string FGName_Lang { get; set; }

	public string FGDescription_Lang { get; set; }

	public int UserId { get; set; }

	public DateTime RegisterDate { get; set; }

	public int? FirstRegisterUserId { get; set; }

	public DateTime? FirstRegisterDate { get; set; }

	public string AppType { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "FGSHPIsActive")]
	public bool FGSHPIsActive { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "FGTspFGIndentify")]
	[MaxLength(100, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(100, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string TspFGIndentify { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "FGTspFGName")]
	public string TspFGName { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "SGTspSGIndentify")]
	[MaxLength(100, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(100, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string TspSGIndentify { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "SGTspSGName")]
	public string TspSGName { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "SGCompanyGroupIIRateJson")]
	public string SGCompanyGroupIIRateJson { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "FGSHPName")]
	[MaxLength(300, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(300, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string FGSHPName { get; set; }

	public string FGSHPName_Lang { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "SGSHPName")]
	[MaxLength(300, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(300, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string SGSHPName { get; set; }

	public string SGSHPName_Lang { get; set; }

	public bool? SeoIsActive { get; set; }

	public string SeoTitle { get; set; }

	public string SeoDescription { get; set; }

	public string SeoHttpEquiv { get; set; }

	public string SeoExpires { get; set; }

	public bool? SeoGoogleNotranslate { get; set; }

	public string SeoDistribution { get; set; }

	public string SeoRobots { get; set; }

	public string SeoRating { get; set; }

	public string SeoAuthor { get; set; }

	public bool? SeoIsUseSocialNetwork { get; set; }

	public int? SeoMobileOptimized { get; set; }

	public string SeoCopyright { get; set; }

	public bool? SeoUseDefault { get; set; }

	public string SeoKeywords { get; set; }

	public string SeoFAQ { get; set; }

	public string SeoTitle_Lang { get; set; }

	public string SeoDescription_Lang { get; set; }

	public string SeoAuthor_Lang { get; set; }

	public string SeoCopyright_Lang { get; set; }

	public string SeoKeywords_Lang { get; set; }

	public string SeoFAQ_Lang { get; set; }
}
