using System;

namespace CRM.Models;

public class CRMspCmsSelectNews_Result
{
	public int NewsId { get; set; }

	public int NewsGroupId { get; set; }

	public string NewsGroup { get; set; }

	public string HeadLine { get; set; }

	public string Title { get; set; }

	public string NewsSummery { get; set; }

	public DateTime PublishDateTime { get; set; }

	public string NewsBody { get; set; }

	public bool? IsVerified { get; set; }

	public int? VerifiedUserId { get; set; }

	public string VerifiedUser { get; set; }

	public DateTime? VerifiedDateTime { get; set; }

	public bool? CommentActive { get; set; }

	public bool? LikeActive { get; set; }

	public int? OrderView { get; set; }

	public bool? IsTopNews { get; set; }

	public int FirstRegisterUserId { get; set; }

	public string FirstRegisterUser { get; set; }

	public DateTime FirstRegisterDate { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public int UserId { get; set; }

	public string EditUser { get; set; }

	public short Year1 { get; set; }

	public short Month1 { get; set; }

	public DateTime RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	public Guid GUId { get; set; }

	public string AppType { get; set; }

	public int LanguageID { get; set; }

	public string NewsSystemPartIds { get; set; }

	public string NewsSystemParts { get; set; }

	public int? LayoutType { get; set; }

	public DateTime? ExpireDateTime { get; set; }

	public string NewsSeoTitle { get; set; }

	public string NewsSeoDescription { get; set; }

	public string NewsSeoKeywords { get; set; }

	public string NewsSeoFaq { get; set; }
}
