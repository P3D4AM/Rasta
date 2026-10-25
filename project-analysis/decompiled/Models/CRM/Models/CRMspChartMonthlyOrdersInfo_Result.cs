using System;

namespace CRM.Models;

public class CRMspChartMonthlyOrdersInfo_Result
{
	public string DateValue { get; set; }

	public string DateText { get; set; }

	public int? OrderId { get; set; }

	public DateTime? OrderDate { get; set; }

	public string OrderDateStr { get; set; }

	public long? OrderNumber { get; set; }

	public decimal? OrderTotalAmount { get; set; }

	public int? OprType { get; set; }

	public int? TotalCount { get; set; }

	public string GroupFieldText { get; set; }

	public int? GroupFieldValue { get; set; }

	public decimal? FilteredProductAmount { get; set; }

	public decimal? FilteredProductCount { get; set; }

	public decimal? FilteredProductDiscount { get; set; }

	public decimal? OrderTotalDiscount { get; set; }
}
