namespace CRM.Models;

public class CurrentNewsViewModel
{
	public CRMspCmsSelectNews_Result News { get; set; }

	public int NewsCurrentId { get; set; }

	public int NewsNextId { get; set; }

	public int NewsPreviousId { get; set; }

	public string FromDate { get; set; }

	public string ToDate { get; set; }

	public bool IsFind { get; set; }

	public string Message { get; set; }

	public int NewsFirstId { get; set; }

	public int NewsLastId { get; set; }

	public long LikeCount { get; set; }

	public long DislikeCount { get; set; }

	public long CommentsCount { get; set; }

	public string LayoutTypeName { get; set; }

	public string ExpireDate { get; set; }

	public string NewsPicture { get; set; }

	public string PublishDate { get; set; }
}
