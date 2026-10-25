using System;

namespace Mobile.Models;

public class HRMMobPayRollspSelectUserCycleOrderCommissions_Result
{
	public int OrderCommissionId { get; set; }

	public DateTime CommDateTime { get; set; }

	public string CommDatePersian { get; set; }

	public int CommOrderId { get; set; }

	public int CommCmpId { get; set; }

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

	public int FirstRegisterUserId { get; set; }

	public DateTime FirstRegisterDate { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public int UserId { get; set; }

	public short Year1 { get; set; }

	public short Month1 { get; set; }

	public DateTime RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	public Guid GUId { get; set; }

	public string AppType { get; set; }

	public int LanguageID { get; set; }

	public bool? CommIsPaid { get; set; }

	public int? CommIsPaidUserId { get; set; }

	public DateTime? CommIsPaidDateTime { get; set; }

	public string CommIsPaidDatePersian { get; set; }

	public int? CommIsPaidPayRollUserCycleId { get; set; }

	public int? CommAmountCurrUnId { get; set; }

	public double? CommAmountCurrencyRate { get; set; }

	public int? PreOrderCommissionId { get; set; }

	public decimal? CommBaseAmountDecPercent { get; set; }

	public int? CommIsPaidPayRollUserCycleItemValueId { get; set; }

	public long? CommOrderNumber { get; set; }

	public string CommOrderDate { get; set; }

	public DateTime? CommOrderDateTime { get; set; }

	public string CommOrderOpr { get; set; }

	public decimal? CommOrderTotalAmount { get; set; }

	public string CommOrderCurrencyUnit { get; set; }

	public string CommOrderReferUser { get; set; }

	public string Company { get; set; }

	public string CommPayType { get; set; }

	public string CommUser { get; set; }

	public string FirstRegisterUser { get; set; }

	public string EditUser { get; set; }

	public string CommVerifierUser { get; set; }

	public string CommIsPaidUser { get; set; }

	public string CommIsPaidPayRollUserCycle { get; set; }

	public string CommAmountCurrUn { get; set; }
}
