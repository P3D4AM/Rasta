using System;

namespace Mobile.Models;

public class MobspSelectPreOrders_Result
{
	public long? Rownum { get; set; }

	public int PreOrderId { get; set; }

	public long pordNumber { get; set; }

	public string pordDate { get; set; }

	public DateTime? pordDateTime { get; set; }

	public int? pordCompanyId { get; set; }

	public string companyName { get; set; }

	public int? pordCompanyPersonId { get; set; }

	public string personName { get; set; }

	public int? pordProjectId { get; set; }

	public string projectName { get; set; }

	public decimal? pordTotalAmount { get; set; }

	public bool? pordIsVerified { get; set; }

	public bool? pordIsFixed { get; set; }

	public int? AllPage { get; set; }

	public long? pordNumberRevision { get; set; }
}
