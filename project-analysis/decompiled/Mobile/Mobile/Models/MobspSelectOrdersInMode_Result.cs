using System;

namespace Mobile.Models;

public class MobspSelectOrdersInMode_Result
{
	public int OrderID { get; set; }

	public long ordNumber { get; set; }

	public DateTime? ordDateTime { get; set; }

	public int ordCompanyId { get; set; }

	public int? ordCompanyPersonId { get; set; }

	public int? ordProjectId { get; set; }

	public decimal? ordTotalAmount { get; set; }

	public bool? ordIsVerified { get; set; }

	public bool? ordIsFixed { get; set; }

	public int? ordReferUserId { get; set; }

	public string ordCompany { get; set; }

	public string ordCompanyPerson { get; set; }

	public string ordProject { get; set; }

	public string ordCurrencyUnit { get; set; }

	public bool? IsDecimal { get; set; }

	public string ordReferUser { get; set; }

	public long? TotalCount { get; set; }

	public long? RowNum { get; set; }

	public int AllPage { get; set; }

	public int? ordPrintFormatId { get; set; }

	public int? ordSaleAreaId { get; set; }

	public string ordSaleAreaName { get; set; }
}
