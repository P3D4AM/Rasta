using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(CrmCmsPagesMetadata))]
public class CrmCmsPages
{
	public int PageId { get; set; }

	public string PageName { get; set; }

	public string PageTitle { get; set; }

	public string PageHeader { get; set; }

	public string PageBody { get; set; }

	public string PageFooter { get; set; }

	public bool? IsActive { get; set; }

	public int? OrderView { get; set; }

	public string PageStyle { get; set; }

	public string PageHeaderScript { get; set; }

	public string PageEndScript { get; set; }

	public int? CrmDyFormId { get; set; }

	public int? TargetMode { get; set; }

	public bool? OnlyForLoginUser { get; set; }

	public int? PageLocation { get; set; }

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

	public string PageSeoTitle { get; set; }

	public string PageSeoDescription { get; set; }

	public string PageSeoKeywords { get; set; }

	public string PageSeoFaq { get; set; }

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

	public bool? PageSeoIsActive { get; set; }

	public virtual ICollection<CrmCmsMenus> CrmCmsMenus { get; set; }

	public virtual CrmDyForms CrmDyForms { get; set; }

	public virtual ICollection<CrmCmsPages_Lang> CrmCmsPages_Lang { get; set; }

	public virtual Languages Languages { get; set; }

	public virtual Users Users { get; set; }

	public virtual Users Users1 { get; set; }

	public CrmCmsPages()
	{
		CrmCmsMenus = (ICollection<CrmCmsMenus>)new HashSet<CrmCmsMenus>();
		CrmCmsPages_Lang = (ICollection<CrmCmsPages_Lang>)new HashSet<CrmCmsPages_Lang>();
	}
}
