using System;

namespace CRMIdealApi.ApiModels;

public class InsertOrderCommissionViewModel : PublicParametersWithOutCenter
{
	public int? ApiOrderId { get; set; }

	public long? ApiOrdNumber { get; set; }

	public DateTime? ApiCommDate { get; set; }

	public int? ApiCommUserId { get; set; }

	public decimal? ApiCommBaseAmountDec { get; set; }

	public string ApiCommBaseAmountDecDesc { get; set; }

	public decimal ApiCommBaseAmount { get; set; }

	public double? ApiCommRate { get; set; }

	public string ApiCommRateDesc { get; set; }

	public decimal ApiCommAmount { get; set; }

	public DateTime? ApiCommEffectiveDate { get; set; }

	public int? ApiCommPayTypeId { get; set; }

	public int? ApiCommStatusId { get; set; }

	public string ApiCommDesc { get; set; }

	public bool? ApiCommIsVerified { get; set; }

	public int? ApiCommVerifierUserId { get; set; }

	public DateTime? ApiCommVerifiedDate { get; set; }

	public bool? ApiCommIsPaid { get; set; }

	public int? ApiCommIsPaidUserId { get; set; }

	public DateTime? ApiCommIsPaidDate { get; set; }

	public int? ApiCommIsPaidPayRollUserCycleId { get; set; }

	public int? ApiCommIsPaidPayRollUserCycleItemValueId { get; set; }

	public int? ApiCommAmountCurrUnId { get; set; }

	public double? ApiCommAmountCurrencyRate { get; set; }

	public decimal? ApiCommBaseAmountDecPercent { get; set; }

	public int ApiCommTypeId { get; set; }

	public int ApiCommKindId { get; set; }

	public int? ApiCommTypeCmpId { get; set; }

	public int? ApiCommTypeCmpNumber { get; set; }

	public string ApiCommTypeCmpCode { get; set; }

	public int? ApiCommTypePrsId { get; set; }
}
