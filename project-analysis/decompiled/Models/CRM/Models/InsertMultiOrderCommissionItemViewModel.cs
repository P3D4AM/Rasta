namespace CRM.Models;

public class InsertMultiOrderCommissionItemViewModel
{
	public int OrderCommissionId { get; set; }

	public int? CommUserId { get; set; }

	public double? CommRate { get; set; }

	public string CommRateDesc { get; set; }

	public decimal CommAmount { get; set; }

	public string CommEffectiveDatePersian { get; set; }

	public string CommEffectiveDateTime { get; set; }

	public int? CommPayTypeId { get; set; }

	public string CommDesc { get; set; }

	public int? CommAmountCurrUnId { get; set; }

	public double? CommAmountCurrencyRate { get; set; }

	public int? CommKindId { get; set; }

	public int? CommTypeId { get; set; }

	public int? CommTypeCmpId { get; set; }

	public int? CommTypePrsId { get; set; }

	public string CommRateDesc_Lang { get; set; }

	public string CommDesc_Lang { get; set; }
}
