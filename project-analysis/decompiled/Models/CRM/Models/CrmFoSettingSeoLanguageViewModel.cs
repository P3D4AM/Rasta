namespace CRM.Models;

public class CrmFoSettingSeoLanguageViewModel
{
	public int Mode { get; set; }

	public int ID { get; set; }

	public bool? SeoIsActive { get; set; }

	public string SeoTitle { get; set; }

	public string SeoTitle_Lang { get; set; }

	public string SeoDescription { get; set; }

	public string SeoDescription_Lang { get; set; }

	public string SeoHttpEquiv { get; set; }

	public string SeoExpires { get; set; }

	public bool? SeoGoogleNotranslate { get; set; }

	public string SeoDistribution { get; set; }

	public string SeoRobots { get; set; }

	public string SeoRating { get; set; }

	public string SeoAuthor { get; set; }

	public string SeoAuthor_Lang { get; set; }

	public bool? SeoIsUseSocialNetwork { get; set; }

	public int? SeoMobileOptimized { get; set; }

	public string SeoCopyright { get; set; }

	public string SeoCopyright_Lang { get; set; }

	public bool? SeoUseDefault { get; set; }

	public string SeoKeywords { get; set; }

	public string SeoKeywords_Lang { get; set; }

	public string SeoFAQ { get; set; }

	public string SeoFAQ_Lang { get; set; }

	public bool? InModeSeoIsActive { get; set; }

	public string SeoGoogleAnalytics { get; set; }
}
