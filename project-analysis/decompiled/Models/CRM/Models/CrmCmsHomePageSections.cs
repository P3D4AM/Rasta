using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(CrmCmsHomePageSectionsMetadata))]
public class CrmCmsHomePageSections
{
	public int HomePageSectionId { get; set; }

	public string SectionTitle { get; set; }

	public string SectionHeader { get; set; }

	public string SectionHeaderStyle { get; set; }

	public string SectionHeaderScript { get; set; }

	public string SectionHeaderPosition { get; set; }

	public string SectionBgColor { get; set; }

	public bool? SectionIsActive { get; set; }

	public int? SectionOrderView { get; set; }

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

	public int? SectionCId { get; set; }

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

	public bool? SectionSeoIsActive { get; set; }

	public virtual ICollection<CrmCmsHomePageSections_Lang> CrmCmsHomePageSections_Lang { get; set; }

	public virtual Languages Languages { get; set; }

	public virtual ICollection<CrmCmsHomePageSectionItems> CrmCmsHomePageSectionItems { get; set; }

	public virtual Centers Centers { get; set; }

	public virtual Users Users { get; set; }

	public virtual Users Users1 { get; set; }

	public CrmCmsHomePageSections()
	{
		CrmCmsHomePageSections_Lang = (ICollection<CrmCmsHomePageSections_Lang>)new HashSet<CrmCmsHomePageSections_Lang>();
		CrmCmsHomePageSectionItems = (ICollection<CrmCmsHomePageSectionItems>)new HashSet<CrmCmsHomePageSectionItems>();
	}
}
