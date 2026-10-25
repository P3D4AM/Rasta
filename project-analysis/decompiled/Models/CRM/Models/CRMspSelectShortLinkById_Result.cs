using System;

namespace CRM.Models;

public class CRMspSelectShortLinkById_Result
{
	public int ShortLinkId { get; set; }

	public long? MaxViewCount { get; set; }

	public bool? InActive { get; set; }

	public DateTime? ExpireDate { get; set; }

	public string Description { get; set; }

	public DateTime FirstRegisterDate { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public DateTime? LastViewDate { get; set; }

	public string UniqueKey { get; set; }

	public string OriginalUrl { get; set; }

	public bool? IsExternal { get; set; }

	public string LastViewDatePersian { get; set; }

	public int? ObjectId { get; set; }

	public long ViewCount { get; set; }

	public int UserId { get; set; }

	public int? SystemPartId { get; set; }
}
