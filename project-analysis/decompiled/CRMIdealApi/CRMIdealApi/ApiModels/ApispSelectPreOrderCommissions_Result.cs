using System;

namespace CRMIdealApi.ApiModels;

public class ApispSelectPreOrderCommissions_Result
{
	public int ApiPreOrderCommissionId { get; set; }

	public DateTime ApiCommDateTime { get; set; }

	public int ApiCommPreOrderId { get; set; }

	public long? ApiPordNumber { get; set; }

	public int ApiCommCmpId { get; set; }

	public string ApiCommCmpName { get; set; }

	public int ApiCommUserId { get; set; }

	public string ApiCommUser { get; set; }

	public decimal? ApiCommBaseAmountDec { get; set; }

	public string ApiCommBaseAmountDecDesc { get; set; }

	public decimal ApiCommBaseAmount { get; set; }

	public double? ApiCommRate { get; set; }

	public string ApiCommRateDesc { get; set; }

	public decimal ApiCommAmount { get; set; }

	public DateTime? ApiCommEffectiveDateTime { get; set; }

	public int? ApiCommPayTypeId { get; set; }

	public string ApiCommPayType { get; set; }

	public int? ApiCommStatusId { get; set; }

	public string ApiCommDesc { get; set; }

	public bool? ApiCommIsVerified { get; set; }

	public int? ApiCommVerifierUserId { get; set; }

	public string ApiCommVerifierUser { get; set; }

	public DateTime? ApiCommVerifiedDateTime { get; set; }

	public int ApiFirstRegisterUserId { get; set; }

	public string ApiFirstRegisterUser { get; set; }

	public DateTime ApiFirstRegisterDate { get; set; }

	public int ApiUserId { get; set; }

	public string ApiEditUser { get; set; }

	public DateTime ApiRegisterDate { get; set; }

	public bool? ApiCommIsPaid { get; set; }

	public int? ApiCommIsPaidUserId { get; set; }

	public string ApiCommIsPaidUser { get; set; }

	public DateTime? ApiCommIsPaidDateTime { get; set; }

	public int? ApiCommIsPaidPayRollUserCycleId { get; set; }

	public int? ApiCommAmountCurrUnId { get; set; }

	public string ApiCommAmountCurrUn { get; set; }

	public double? ApiCommAmountCurrencyRate { get; set; }

	public int? ApiCommCId { get; set; }

	public string ApiCommCenterName { get; set; }
}
