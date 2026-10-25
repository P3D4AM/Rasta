using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using CRM.Resources;

namespace CRM.Models;

public class CrmCmsNewsLanguageViewModel
{
	[Key]
	public int NewsId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "CmsNewsGroupId")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	public int NewsGroupId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "CmsNewsHeadLine")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	[MaxLength(1000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(1000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string HeadLine { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "CmsNewsTitleI")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	[MaxLength(1000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(1000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string Title { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "CmsNewsSummery")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	public string NewsSummery { get; set; }

	public DateTime PublishDateTime { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "CmsNewsPublishDate")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	public string PublishDate { get; set; }

	public string PublishTime { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "CmsNewsBody")]
	[UIHint("RichText")]
	[AllowHtml]
	public string NewsBody { get; set; }

	public bool? IsVerified { get; set; }

	public int? VerifiedUserId { get; set; }

	public DateTime? VerifiedDateTime { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "CmsNewsCommentActive")]
	public bool? CommentActive { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "CmsNewsLikeActive")]
	public bool? LikeActive { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "CmsNewsOrderView")]
	public int? OrderView { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "CmsNewsIsTopNews")]
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

	public string HeadLine_Lang { get; set; }

	public string Title_Lang { get; set; }

	public string NewsSummery_Lang { get; set; }

	[AllowHtml]
	public string NewsBody_Lang { get; set; }

	public string PicPath { get; set; }

	public string PicTitle { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "CmsNewsExpireDate")]
	public string ExpireDate { get; set; }

	public string ExpireTime { get; set; }

	public DateTime? ExpireDateTime { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "CmsNewsSystemPartIds")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	public string NewsSystemPartIds { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "CmsNewsLayoutType")]
	public int? LayoutType { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "CmsNewsShowSeoTitle")]
	[MaxLength(70, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	public string NewsSeoTitle { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "CmsNewsShowSeoDesc")]
	[MaxLength(150, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	public string NewsSeoDescription { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "CmsNewsShowSeoKeywords")]
	public string NewsSeoKeywords { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "CmsNewsShowSeoFaq")]
	public string NewsSeoFaq { get; set; }

	public string NewsSeoTitle_Lang { get; set; }

	public string NewsSeoDescription_Lang { get; set; }

	public string NewsSeoKeywords_Lang { get; set; }

	public string NewsSeoFaq_Lang { get; set; }

	public bool? NewsSeoIsActive { get; set; }

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

	public string NewsSeoAuthor_Lang { get; set; }

	public string NewsSeoCopyright_Lang { get; set; }
}
