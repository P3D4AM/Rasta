using System;

namespace CRM.Models;

public class CRMspSelectProjectProductHistoryNotDone_Result
{
	public int ProjectProductHistoryId { get; set; }

	public int PrjPrdHCompanyId { get; set; }

	public int PrjPrdHProjectId { get; set; }

	public int PrjPrdHProductId { get; set; }

	public string PrjPrdHProduct { get; set; }

	public string PrjPrdHProductCode { get; set; }

	public int? PrjPrdHOrderId { get; set; }

	public long? OrderNumber { get; set; }

	public string OrderDate { get; set; }

	public DateTime? OrderDateTime { get; set; }

	public string OrderOpr { get; set; }

	public int? PrjPrdHOrderItemId { get; set; }

	public DateTime? PrjPrdHSetDate { get; set; }

	public string PrjPrdHSetDatePersian { get; set; }

	public int? PrjPrdHDoneStatus { get; set; }

	public int? PrjPrdHDoneStatusUserId { get; set; }

	public string PrjPrdHDoneStatusUser { get; set; }

	public DateTime? PrjPrdHDoneStatusDate { get; set; }

	public string PrjPrdHDoneStatusDatePersian { get; set; }

	public string PrjPrdHDesc { get; set; }

	public double? PrjPrdHScore { get; set; }

	public int? PrjPrdHCount { get; set; }

	public int? PrjPrdHDurationMin { get; set; }

	public bool? PrjPrdHNoCalc { get; set; }
}
