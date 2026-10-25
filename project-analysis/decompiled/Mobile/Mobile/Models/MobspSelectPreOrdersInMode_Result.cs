using System;

namespace Mobile.Models;

public class MobspSelectPreOrdersInMode_Result
{
	public int PreOrderId { get; set; }

	public long pordNumber { get; set; }

	public DateTime? pordDateTime { get; set; }

	public int? pordCompanyId { get; set; }

	public int? pordCompanyPersonId { get; set; }

	public int? pordProjectId { get; set; }

	public decimal? pordTotalAmount { get; set; }

	public bool? pordIsVerified { get; set; }

	public bool? pordIsFixed { get; set; }

	public long? pordNumberRevision { get; set; }

	public int? pordReferUserId { get; set; }

	public string pordCompany { get; set; }

	public string pordCompanyPerson { get; set; }

	public string pordProject { get; set; }

	public string pordCurrencyUnit { get; set; }

	public bool? IsDecimal { get; set; }

	public string pordReferUser { get; set; }

	public long? TotalCount { get; set; }

	public long? RowNum { get; set; }

	public int AllPage { get; set; }

	public long? LastPordNumberRevision { get; set; }

	public int? pordPrintFormatId { get; set; }

	public int? pordSaleAreaId { get; set; }

	public string pordSaleAreaName { get; set; }
}
