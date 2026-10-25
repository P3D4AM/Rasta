using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using CRM.Resources;

namespace CRM.Models;

public class CrmCmsHomePageSectionsLanguageViewModel
{
	[Key]
	public int HomePageSectionId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "CmsHomePageSectionTitle")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	[MaxLength(200, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(200, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string SectionTitle { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "CmsHomePageSectionHeader")]
	[UIHint("RichText")]
	[AllowHtml]
	public string SectionHeader { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "CmsHomePageSectionHeaderStyle")]
	[AllowHtml]
	public string SectionHeaderStyle { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "CmsHomePageSectionHeaderScript")]
	[AllowHtml]
	public string SectionHeaderScript { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "CmsHomePageSectionHeaderPosition")]
	public string SectionHeaderPosition { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "CmsHomePageSectionBgColor")]
	public string SectionBgColor { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "CmsHomePageSectionIsActive")]
	public bool? SectionIsActive { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "CmsHomePageSectionOrderView")]
	public int? SectionOrderView { get; set; }

	public string SectionTitle_Lang { get; set; }

	[AllowHtml]
	public string SectionHeader_Lang { get; set; }

	public bool? SectionSeoIsActive { get; set; }

	public string SectionSeoTitle { get; set; }

	public string SectionSeoDescription { get; set; }

	public string SectionSeoHttpEquiv { get; set; }

	public string SectionSeoExpires { get; set; }

	public bool? SectionSeoGoogleNotranslate { get; set; }

	public string SectionSeoDistribution { get; set; }

	public string SectionSeoRobots { get; set; }

	public string SectionSeoRating { get; set; }

	public string SectionSeoAuthor { get; set; }

	public bool? SectionSeoIsUseSocialNetwork { get; set; }

	public int? SectionSeoMobileOptimized { get; set; }

	public string SectionSeoCopyright { get; set; }

	public bool? SectionSeoUseDefault { get; set; }

	public string SectionSeoKeywords { get; set; }

	public string SectionSeoFAQ { get; set; }

	public string SectionSeoTitle_Lang { get; set; }

	public string SectionSeoDescription_Lang { get; set; }

	public string SectionSeoAuthor_Lang { get; set; }

	public string SectionSeoCopyright_Lang { get; set; }

	public string SectionSeoKeywords_Lang { get; set; }

	public string SectionSeoFAQ_Lang { get; set; }
}
