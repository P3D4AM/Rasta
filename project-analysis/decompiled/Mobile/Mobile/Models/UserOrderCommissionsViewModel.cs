using System;

namespace Mobile.Models;

public class UserOrderCommissionsViewModel
{
	public int CrmUserId { get; set; }

	public string fromDate { get; set; }

	public string toDate { get; set; }

	public int Mode { get; set; }

	public int? PageNumber { get; set; }

	public int? PageSize { get; set; }

	public int? LanguageId { get; set; }

	public string CrmUserIds { get; set; }

	public bool IsShowSameOrder { get; set; }

	public int? CommissionKindId { get; set; }

	public int? CompanyId { get; set; }

	public bool? IsVerified { get; set; }

	public bool? IsNotVerified { get; set; }

	public bool? IsPaied { get; set; }

	public bool? IsNotPaied { get; set; }

	public DateTime? EffectiveFromDate { get; set; }

	public DateTime? EffectiveToDate { get; set; }

	public DateTime? OrdFromDate { get; set; }

	public DateTime? OrdToDate { get; set; }

	public float? PercentFrom { get; set; }

	public float? PercentTo { get; set; }

	public int? CenterId { get; set; }

	public bool? IsPreVerified { get; set; }

	public bool? IsNotPreVerified { get; set; }
}
