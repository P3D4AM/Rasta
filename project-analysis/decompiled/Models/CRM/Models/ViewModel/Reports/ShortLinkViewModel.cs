using System;

namespace CRM.Models.ViewModel.Reports;

public class ShortLinkViewModel
{
	public int ShortLinkId { get; set; }

	public string UniqueKey { get; set; }

	public string OriginalUrl { get; set; }

	public long? MaxViewCount { get; set; }

	public bool? InActive { get; set; }

	public DateTime? ExpireDate { get; set; }

	public bool? IsExternal { get; set; }

	public int? ObjectId { get; set; }

	public long ViewCount { get; set; }

	public int UserId { get; set; }

	public int? SystemPartId { get; set; }

	public string LastViewDatePersian { get; set; }
}
