using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using CRM.Resources;

namespace CRM.Models;

public class CrmCmsPagesLanguageViewModel
{
	[Key]
	public int PageId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "CmsPageName")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	[MaxLength(1000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(1000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string PageName { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "CmsPageTitle")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	[MaxLength(1000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(1000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string PageTitle { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "CmsPageHeader")]
	[UIHint("RichText")]
	[AllowHtml]
	public string PageHeader { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "CmsPageBody")]
	[UIHint("RichText")]
	[AllowHtml]
	public string PageBody { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "CmsPageFooter")]
	[UIHint("RichText")]
	[AllowHtml]
	public string PageFooter { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "CmsPageIsActive")]
	public bool? IsActive { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "CmsPageOrderView")]
	public int? OrderView { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "CmsPageStyle")]
	[AllowHtml]
	public string PageStyle { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "CmsPageHeaderScript")]
	[AllowHtml]
	public string PageHeaderScript { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "CmsPageEndScript")]
	[AllowHtml]
	public string PageEndScript { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "CmsPageDyFormId")]
	public int? CrmDyFormId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "CmsPageTargetMode")]
	public int? TargetMode { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "CmsPageOnlyForLoginUser")]
	public bool? OnlyForLoginUser { get; set; }

	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	[Display(ResourceType = typeof(Labels), Name = "CmsPageLocation")]
	public int? PageLocation { get; set; }

	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	[Display(ResourceType = typeof(Labels), Name = "CmsPageLayoutType")]
	public int? LayoutType { get; set; }

	public int FirstRegisterUserId { get; set; }

	public DateTime FirstRegisterDate { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public int UserId { get; set; }

	public short Year1 { get; set; }

	public short Month1 { get; set; }

	public DateTime RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	public Guid GUId { get; set; }

	public string AppType { get; set; }

	public int LanguageID { get; set; }

	public string EditUser { get; set; }

	public string FirstRegisterUser { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "CmsPageShowSeoTitle")]
	[MaxLength(70, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	public string PageSeoTitle { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "CmsPageShowSeoDesc")]
	[MaxLength(150, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	public string PageSeoDescription { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "CmsPageShowSeoKeywords")]
	public string PageSeoKeywords { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "CmsPageShowSeoFaq")]
	public string PageSeoFaq { get; set; }

	public string PageName_Lang { get; set; }

	public string PageTitle_Lang { get; set; }

	[AllowHtml]
	public string PageHeader_Lang { get; set; }

	[AllowHtml]
	public string PageBody_Lang { get; set; }

	[AllowHtml]
	public string PageFooter_Lang { get; set; }

	public string PageSeoTitle_Lang { get; set; }

	public string PageSeoDescription_Lang { get; set; }

	public string PageSeoKeywords_Lang { get; set; }

	public string PageSeoFaq_Lang { get; set; }

	public bool? PageSeoIsActive { get; set; }

	public string PageSeoHttpEquiv { get; set; }

	public string PageSeoExpires { get; set; }

	public bool? PageSeoGoogleNotranslate { get; set; }

	public string PageSeoDistribution { get; set; }

	public string PageSeoRobots { get; set; }

	public string PageSeoRating { get; set; }

	public string PageSeoAuthor { get; set; }

	public bool? PageSeoIsUseSocialNetwork { get; set; }

	public int? PageSeoMobileOptimized { get; set; }

	public string PageSeoCopyright { get; set; }

	public bool? PageSeoUseDefault { get; set; }

	public string PageSeoAuthor_Lang { get; set; }

	public string PageSeoCopyright_Lang { get; set; }
}
