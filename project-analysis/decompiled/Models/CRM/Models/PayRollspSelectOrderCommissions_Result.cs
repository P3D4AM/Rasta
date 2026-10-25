using System;

namespace CRM.Models;

public class PayRollspSelectOrderCommissions_Result
{
	public int OrderCommissionId { get; set; }

	public DateTime CommDateTime { get; set; }

	public string CommDatePersian { get; set; }

	public int CommOrderId { get; set; }

	public long? CommOrderNumber { get; set; }

	public string CommOrderDate { get; set; }

	public DateTime? CommOrderDateTime { get; set; }

	public string CommOrderOpr { get; set; }

	public decimal? CommOrderTotalAmount { get; set; }

	public int CommCmpId { get; set; }

	public string Company { get; set; }

	public int? CommUserId { get; set; }

	public string CommUser { get; set; }

	public decimal? CommBaseAmountDec { get; set; }

	public string CommBaseAmountDecDesc { get; set; }

	public decimal CommBaseAmount { get; set; }

	public double? CommRate { get; set; }

	public string CommRateDesc { get; set; }

	public decimal CommAmount { get; set; }

	public int? CommIsPaidPayRollUserCycleId { get; set; }

	public int? CommAmountCurrUnId { get; set; }

	public string CommAmountCurrUn { get; set; }

	public double? CommAmountCurrencyRate { get; set; }

	public decimal? CommBaseAmountDecPercent { get; set; }

	public int? CommIsPaidPayRollUserCycleItemValueId { get; set; }

	public string CommOrderCurrencyUnit { get; set; }
}
