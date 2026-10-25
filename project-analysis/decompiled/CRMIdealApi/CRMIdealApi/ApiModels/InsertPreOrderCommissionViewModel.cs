using System;

namespace CRMIdealApi.ApiModels;

public class InsertPreOrderCommissionViewModel : PublicParametersWithOutCenter
{
	public int? ApiPreOrderId { get; set; }

	public long? ApiPordNumber { get; set; }

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

	public int? ApiCommAmountCurrUnId { get; set; }

	public double? ApiCommAmountCurrencyRate { get; set; }
}
