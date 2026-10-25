using System;

namespace CRM.Models;

public class CRMspSelectShortLinksWithPaging_Result
{
	public int ShortLinkId { get; set; }

	public string UniqueKey { get; set; }

	public string OriginalUrl { get; set; }

	public string LastViewDate { get; set; }

	public DateTime? LastViewDateTime { get; set; }

	public long ViewCount { get; set; }

	public bool? InActive { get; set; }

	public string ExpireDate { get; set; }

	public DateTime? ExpireDateTime { get; set; }

	public long? MaxViewCount { get; set; }

	public string FirstRegisterDate { get; set; }

	public DateTime FirstRegisterDateTime { get; set; }

	public string PartTitle { get; set; }

	public string ShortUrl { get; set; }

	public string User { get; set; }

	public int IsVisibleToUser { get; set; }

	public long? RowNumber { get; set; }

	public int? AllPage { get; set; }
}
