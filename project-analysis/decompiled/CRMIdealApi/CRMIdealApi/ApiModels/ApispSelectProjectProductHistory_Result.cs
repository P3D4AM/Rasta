using System;

namespace CRMIdealApi.ApiModels;

public class ApispSelectProjectProductHistory_Result
{
	public int ApiProjectProductHistoryId { get; set; }

	public int ApiPrjPrdHCompanyId { get; set; }

	public string ApiPrjPrdHCompany { get; set; }

	public int ApiPrjPrdHProjectId { get; set; }

	public string ApiPrjPrdHProject { get; set; }

	public int ApiPrjPrdHProductId { get; set; }

	public string ApiPrjPrdHProduct { get; set; }

	public string ApiPrjPrdHProductCode { get; set; }

	public int? ApiPrjPrdHOrderId { get; set; }

	public long? ApiOrderNumber { get; set; }

	public DateTime? ApiOrderDateTime { get; set; }

	public string ApiOrderOpr { get; set; }

	public int? ApiPrjPrdHOrderItemId { get; set; }

	public DateTime? ApiPrjPrdHSetDate { get; set; }

	public int? ApiPrjPrdHDoneStatus { get; set; }

	public string ApiPrjPrdHDoneStatusTitle { get; set; }

	public int? ApiPrjPrdHDoneStatusUserId { get; set; }

	public string ApiPrjPrdHDoneStatusUser { get; set; }

	public DateTime? ApiPrjPrdHDoneStatusDate { get; set; }

	public string ApiPrjPrdHDesc { get; set; }

	public double? ApiPrjPrdHScore { get; set; }

	public int? ApiPrjPrdHCount { get; set; }

	public int? ApiPrjPrdHDurationMin { get; set; }

	public bool? ApiPrjPrdHNoCalc { get; set; }

	public double? ApiOrderItemQuantity { get; set; }

	public int? ApiPrdValidityCountingNum { get; set; }

	public int? ApiPrdValidityCountingMin { get; set; }

	public double? ApiPrdValidityCountingNumTotal { get; set; }

	public double? ApiPrdValidityCountingMinTotal { get; set; }

	public double ApiPrjPrdHRemainCount { get; set; }

	public double ApiPrjPrdHRemainDurationMin { get; set; }

	public int ApiFirstRegisterUserId { get; set; }

	public string ApiFirstRegisterUser { get; set; }

	public DateTime ApiFirstRegisterDate { get; set; }

	public int ApiUserId { get; set; }

	public string ApiEditUser { get; set; }

	public DateTime ApiRegisterDate { get; set; }

	public bool? ApiPrdValidityCountingNumIsActive { get; set; }

	public bool? ApiPrdValidityCountingNumNeedOrder { get; set; }

	public int? ApiPrdValidityCountingNumDefaultVal { get; set; }

	public bool? ApiPrdValidityCountingNumNoCheckRemain { get; set; }

	public bool? ApiPrdValidityCountingMinIsActive { get; set; }

	public bool? ApiPrdValidityCountingMinNeedOrder { get; set; }

	public int? ApiPrdValidityCountingMinDefaultVal { get; set; }

	public bool? ApiPrdValidityCountingMinNoCheckRemain { get; set; }
}
