using System;

namespace CRM.Models;

public class CRMspChartDailyOrdersExtraInfo_Result
{
	public int OrderId { get; set; }

	public DateTime? OrderDate { get; set; }

	public string OrderDateStr { get; set; }

	public long OrderNumber { get; set; }

	public decimal? OrderTotalAmount { get; set; }

	public decimal? OrderTotalDiscount { get; set; }

	public int? OprType { get; set; }

	public int? TotalCount { get; set; }

	public string XLabelValue { get; set; }

	public string XLabelText { get; set; }

	public decimal? FilteredProductAmount { get; set; }

	public double? FilteredProductCount { get; set; }

	public decimal? FilteredProductDiscount { get; set; }

	public string GroupFieldText { get; set; }

	public string GroupFieldValue { get; set; }

	public string AppliedFilters { get; set; }
}
