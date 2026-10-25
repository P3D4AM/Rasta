using System;

namespace Mobile.Models;

public class CrmProjectProductHistoryLanguageViewModel
{
	public int RowId { get; set; }

	public int ProjectProductHistoryId { get; set; }

	public int PrjPrdHCompanyId { get; set; }

	public string PrjPrdHCompany { get; set; }

	public int PrjPrdHProjectId { get; set; }

	public string PrjPrdHProject { get; set; }

	public int PrjPrdHProductId { get; set; }

	public string PrjPrdHProduct { get; set; }

	public string PrjPrdHProductCode { get; set; }

	public int? PrjPrdHOrderId { get; set; }

	public string PrjPrdHOrderOrderInfo { get; set; }

	public int? PrjPrdHOrderItemId { get; set; }

	public DateTime? PrjPrdHSetDate { get; set; }

	public string PrjPrdHSetDatePersian { get; set; }

	public int? PrjPrdHDoneStatus { get; set; }

	public string PrjPrdHDoneStatusTitle { get; set; }

	public int? PrjPrdHDoneStatusUserId { get; set; }

	public string PrjPrdHDoneStatusUser { get; set; }

	public DateTime? PrjPrdHDoneStatusDate { get; set; }

	public string PrjPrdHDoneStatusDatePersian { get; set; }

	public string PrjPrdHDesc { get; set; }

	public double? PrjPrdHScore { get; set; }

	public int? PrjPrdHCount { get; set; }

	public int? PrjPrdHDurationMin { get; set; }

	public bool? PrjPrdHNoCalc { get; set; }

	public double? OrderItemQuantity { get; set; }

	public int? PrdValidityCountingNum { get; set; }

	public int? PrdValidityCountingMin { get; set; }

	public double? PrdValidityCountingNumTotal { get; set; }

	public double? PrdValidityCountingMinTotal { get; set; }

	public double PrjPrdHRemainCount { get; set; }

	public double PrjPrdHRemainDurationMin { get; set; }

	public DateTime FirstRegisterDate { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public DateTime RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	public long? OrderNumber { get; set; }

	public string OrderDate { get; set; }

	public DateTime? OrderDateTime { get; set; }

	public string OrderOpr { get; set; }

	public string ErrorType { get; set; }

	public bool? PrdValidityCountingNumIsActive { get; set; }

	public bool? PrdValidityCountingNumNeedOrder { get; set; }

	public int? PrdValidityCountingNumDefaultVal { get; set; }

	public bool? PrdValidityCountingNumNoCheckRemain { get; set; }

	public bool? PrdValidityCountingMinIsActive { get; set; }

	public bool? PrdValidityCountingMinNeedOrder { get; set; }

	public int? PrdValidityCountingMinDefaultVal { get; set; }

	public bool? PrdValidityCountingMinNoCheckRemain { get; set; }

	public int FirstRegisterUserId { get; set; }

	public string FirstRegisterUser { get; set; }

	public string PrjPrdHDesc_Lang { get; set; }
}
