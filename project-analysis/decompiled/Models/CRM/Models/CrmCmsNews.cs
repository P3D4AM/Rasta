using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(CrmCmsNewsMetadata))]
public class CrmCmsNews
{
	public int NewsId { get; set; }

	public int NewsGroupId { get; set; }

	public string HeadLine { get; set; }

	public string Title { get; set; }

	public string NewsSummery { get; set; }

	public DateTime PublishDateTime { get; set; }

	public string NewsBody { get; set; }

	public bool? IsVerified { get; set; }

	public int? VerifiedUserId { get; set; }

	public DateTime? VerifiedDateTime { get; set; }

	public bool? CommentActive { get; set; }

	public bool? LikeActive { get; set; }

	public int? OrderView { get; set; }

	public bool? IsTopNews { get; set; }

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

	public string NewsSystemPartIds { get; set; }

	public int? LayoutType { get; set; }

	public DateTime? ExpireDateTime { get; set; }

	public string NewsSeoTitle { get; set; }

	public string NewsSeoDescription { get; set; }

	public string NewsSeoKeywords { get; set; }

	public string NewsSeoFaq { get; set; }

	public string NewsSeoHttpEquiv { get; set; }

	public string NewsSeoExpires { get; set; }

	public bool? NewsSeoGoogleNotranslate { get; set; }

	public string NewsSeoDistribution { get; set; }

	public string NewsSeoRobots { get; set; }

	public string NewsSeoRating { get; set; }

	public string NewsSeoAuthor { get; set; }

	public bool? NewsSeoIsUseSocialNetwork { get; set; }

	public int? NewsSeoMobileOptimized { get; set; }

	public string NewsSeoCopyright { get; set; }

	public bool? NewsSeoUseDefault { get; set; }

	public bool? NewsSeoIsActive { get; set; }

	public virtual ICollection<CrmCmsMenus> CrmCmsMenus { get; set; }

	public virtual CrmCmsNewsGroups CrmCmsNewsGroups { get; set; }

	public virtual ICollection<CrmCmsNews_Lang> CrmCmsNews_Lang { get; set; }

	public virtual Languages Languages { get; set; }

	public virtual Users Users { get; set; }

	public virtual Users Users1 { get; set; }

	public virtual Users Users2 { get; set; }

	public CrmCmsNews()
	{
		CrmCmsMenus = (ICollection<CrmCmsMenus>)new HashSet<CrmCmsMenus>();
		CrmCmsNews_Lang = (ICollection<CrmCmsNews_Lang>)new HashSet<CrmCmsNews_Lang>();
	}
}
