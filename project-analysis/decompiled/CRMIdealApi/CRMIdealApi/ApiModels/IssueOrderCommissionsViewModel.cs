using System;

namespace CRMIdealApi.ApiModels;

public class IssueOrderCommissionsViewModel
{
	public DateTime? CommDateTime { get; set; }

	public string CommDatePersian { get; set; }

	public int? CommUserId { get; set; }

	public decimal? CommBaseAmountDec { get; set; }

	public string CommBaseAmountDecDesc { get; set; }

	public decimal CommBaseAmount { get; set; }

	public double? CommRate { get; set; }

	public string CommRateDesc { get; set; }

	public decimal CommAmount { get; set; }

	public DateTime? CommEffectiveDateTime { get; set; }

	public string CommEffectiveDatePersian { get; set; }

	public int? CommPayTypeId { get; set; }

	public int? CommStatusId { get; set; }

	public string CommDesc { get; set; }

	public bool? CommIsVerified { get; set; }

	public int? CommVerifierUserId { get; set; }

	public DateTime? CommVerifiedDateTime { get; set; }

	public string CommVerifiedDatePersian { get; set; }

	public bool? CommIsPaid { get; set; }

	public int? CommIsPaidUserId { get; set; }

	public DateTime? CommIsPaidDateTime { get; set; }

	public string CommIsPaidDatePersian { get; set; }

	public int? CommIsPaidPayRollUserCycleId { get; set; }

	public int? CommIsPaidPayRollUserCycleItemValueId { get; set; }

	public int? CommAmountCurrUnId { get; set; }

	public double? CommAmountCurrencyRate { get; set; }

	public decimal? CommBaseAmountDecPercent { get; set; }

	public int CommTypeId { get; set; }

	public int CommKindId { get; set; }

	public int? CommTypeCmpId { get; set; }

	public int? CommTypeCmpNumber { get; set; }

	public string CommTypeCmpCode { get; set; }

	public int? CommTypePrsId { get; set; }
}
