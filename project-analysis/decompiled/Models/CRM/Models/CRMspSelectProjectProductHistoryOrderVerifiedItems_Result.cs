using System;

namespace CRM.Models;

public class CRMspSelectProjectProductHistoryOrderVerifiedItems_Result
{
	public int OrderItemID { get; set; }

	public int OrderId { get; set; }

	public int ordIPrdId { get; set; }

	public double? ordIQuantity { get; set; }

	public double? ordIFCR { get; set; }

	public double? ordIFCRI { get; set; }

	public double? ordIQuantityTotal { get; set; }

	public double? ordIPrdUnitIRateResult { get; set; }

	public int? ordIOrderView { get; set; }

	public int? ordIPrdValidityCountingNum { get; set; }

	public int? ordIPrdValidityCountingMin { get; set; }

	public string PrdName { get; set; }

	public string PrdCode { get; set; }

	public bool? PrdValidityCountingNumIsActive { get; set; }

	public int? PrdValidityCountingNum { get; set; }

	public int? PrdValidityCountingNumDefaultVal { get; set; }

	public bool? PrdValidityCountingNumNeedOrder { get; set; }

	public bool? PrdValidityCountingNumNoCheckRemain { get; set; }

	public bool? PrdValidityCountingMinIsActive { get; set; }

	public int? PrdValidityCountingMin { get; set; }

	public int? PrdValidityCountingMinDefaultVal { get; set; }

	public bool? PrdValidityCountingMinNeedOrder { get; set; }

	public bool? PrdValidityCountingMinNoCheckRemain { get; set; }

	public double? PrdScore { get; set; }

	public string PrdFGName { get; set; }

	public string PrdSGName { get; set; }

	public string OrderOpr { get; set; }

	public long? ordNumber { get; set; }

	public string ordDate { get; set; }

	public DateTime? ordDateTime { get; set; }

	public int? ordProjectId { get; set; }

	public string ordProject { get; set; }

	public double ordIPrdValidityCountingNumTotal { get; set; }

	public double ordIPrdValidityCountingMinTotal { get; set; }

	public double ordIPrjPrdHRemainCount { get; set; }

	public double ordIPrjPrdHRemainDurationMin { get; set; }
}
