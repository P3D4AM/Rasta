using System;

namespace Mobile.Models;

public class HrmSelectLeaveParamsViewModel
{
	public int? CrmUserId { get; set; }

	public int? LeaveId { get; set; }

	public int? LeaveTypeId { get; set; }

	public int? UserId { get; set; }

	public DateTime? FDateTime { get; set; }

	public DateTime? TDateTime { get; set; }

	public int? LanguageID { get; set; }

	public int? PageNumber { get; set; }

	public int? PageSize { get; set; }

	public int? CenterId { get; set; }
}
